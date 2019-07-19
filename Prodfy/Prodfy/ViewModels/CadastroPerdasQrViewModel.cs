using Prodfy.Models;
using Prodfy.Services.Dialog;
using Prodfy.Services.Navigation;
using Prodfy.Services.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class CadastroPerdasQrViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
        private readonly IDialogService dialogService;

        private readonly LoteRepository loteRepositorio;
        private readonly PerdaRepository perdaRepositorio;
        private readonly MudaRepository mudaRepositorio;
        private readonly PontoControleRepository pontoControleRepositorio;
        private readonly EstagioRepository estagioRepositorio;
        private readonly PerdaMotivoRepository perdaMotivoRepositorio;
        private readonly UserRepository userRepositorio;

        private User user;
        private CarregarDadosPerdaQr _dadosPerdaQr;

        public List<Lote> listaLotes { get; set; }
        public List<Muda> listaMudas { get; set; }
        public List<Ponto_Controle> listaPontoControle { get; set; }
        public List<Estagio> listaEstagios { get; set; }
        public List<Perda_Motivo> listaPerdaMotivo { get; set; }

        public CadastroPerdasQrViewModel(CarregarDadosPerdaQr dadosPerdaQr)
        {
            Title = "Perdas";

            navigationService = new NavigationService();
            dialogService = new DialogService();

            loteRepositorio = new LoteRepository();
            perdaRepositorio = new PerdaRepository();
            mudaRepositorio = new MudaRepository();
            pontoControleRepositorio = new PontoControleRepository();
            estagioRepositorio = new EstagioRepository();
            perdaMotivoRepositorio = new PerdaMotivoRepository();
            userRepositorio = new UserRepository();

            _dadosPerdaQr = dadosPerdaQr;

            Lotes();
            Mudas();
            PontoControles();
            Estagios();
            PerdaMotivo();
        }

        public int LoteSelecionadoIndex { get => Index("Lote"); }

        private Lote _loteSelecionado;
        public Lote LoteSelecionado
        {
            get => _loteSelecionado;
            set => SetProperty(ref _loteSelecionado, value);
        }

        public int MudaSelecionadaIndex { get => Index("Muda"); }

        private Muda _mudaSelecionada;
        public Muda MudaSelecionada
        {
            get => _mudaSelecionada;
            set => SetProperty(ref _mudaSelecionada, value);
        }

        public int PontoControleSelecionadoIndex { get => Index("PontoControle"); }

        private Ponto_Controle _pontoControleSelecionado;
        public Ponto_Controle PontoControleSelecionado
        {
            get => _pontoControleSelecionado;
            set => SetProperty(ref _pontoControleSelecionado, value);
        }

        public int EstagioSelecionadoIndex { get => Index("Estagio"); }

        private Estagio _estagioSelecionado;
        public Estagio EstagioSelecionado
        {
            get => _estagioSelecionado;
            set => SetProperty(ref _estagioSelecionado, value);
        }

        public int PerdaMotivoSelecionadoIndex { get => Index("PerdaMotivo"); }

        private Perda_Motivo _motivoSelecionado;
        public Perda_Motivo MotivoSelecionado
        {
            get => _motivoSelecionado;
            set => SetProperty(ref _motivoSelecionado, value);
        }

        private DateTime _data;
        public DateTime Data
        {
            get => _data = DateTime.Today;
            set => SetProperty(ref _data, value);
        }

        private string _qtde;
        public string Qtde
        {
            get
            {
                if (!string.IsNullOrEmpty(_dadosPerdaQr.Oquantidade))
                {
                    _qtde = _dadosPerdaQr.Oquantidade;
                }

                return _qtde;
            } 

            set
            {
                if (!string.IsNullOrEmpty(_dadosPerdaQr.Oquantidade))
                {
                    _dadosPerdaQr.Oquantidade = value;
                    OnPropertyChanged();
                }

                SetProperty(ref _qtde, value);
            }
        }

        private string _indSinc;
        public string IndSinc
        {
            get => _indSinc;
            set => SetProperty(ref _indSinc, value);
        }

        private Command _titleViewBotaoVoltarCommand;
        public Command TitleViewBotaoVoltarCommand =>
            _titleViewBotaoVoltarCommand ?? (_titleViewBotaoVoltarCommand = new Command(async () => await ExecuteTitleViewBotaoVoltarCommand()));

        private async Task ExecuteTitleViewBotaoVoltarCommand() => await navigationService.PopAsync();

        private Command _leitorQRCommand;
        public Command LeitorQRCommand => _leitorQRCommand ?? (_leitorQRCommand = new Command(async () => await ExecuteLeitorQRCommand()));

        private async Task ExecuteLeitorQRCommand()
        {
            var scanner = new ZXing.Mobile.MobileBarcodeScanner();
            var result = await scanner.Scan();
        }

        private Command _cancelarCadastroCommand;
        public Command CancelarCadastroCommand =>
            _cancelarCadastroCommand ?? (_cancelarCadastroCommand = new Command(async () => await ExecuteCancelarCadastroCommand()));

        private Task ExecuteCancelarCadastroCommand()
        {
            throw new NotImplementedException();
        }

        private Command _salvarCadastroCommand;
        public Command SalvarCadastroCommand =>
            _salvarCadastroCommand ?? (_salvarCadastroCommand = new Command(async () => await ExecuteSalvarCadastroCommand()));

        private async Task ExecuteSalvarCadastroCommand()
        {
            try
            {
                await ValidarCampos();

                var perda = new Perda
                {
                    disp_id = ObterDispositivoId().disp_id,
                    lote_id = LoteSelecionado.lote_id,
                    muda_id = MudaSelecionada.muda_id,
                    produto_id = LoteSelecionado.produto_id,
                    ponto_controle_id = PontoControleSelecionado.ponto_controle_id,
                    estagio_id = EstagioSelecionado.estagio_id,
                    motivo_id = MotivoSelecionado.idPerda_Motivo,
                    data = Data,
                    qtde = Convert.ToInt32(Qtde),
                    last_update = DateTime.Now
                };

                bool perdasAceite = await dialogService.AlertAsync("PERDAS", "Deseja salvar os dados informados?", "Sim", "Não");

                if (perdasAceite)
                {
                    try
                    {
                        perdaRepositorio.Adicionar(perda);
                        await dialogService.AlertAsync("PERDAS", "Dados salvos com sucesso!", "Ok");
                    }
                    catch (Exception)
                    {
                        await dialogService.AlertAsync("PERDAS", "Erro ao salvar dados!", "Ok");
                    }
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        private List<Lote> Lotes()
        {
            return listaLotes = loteRepositorio.ObterTodos();
        }

        private List<Muda> Mudas()
        {
            return listaMudas = mudaRepositorio.ObterTodos();
        }

        private List<Ponto_Controle> PontoControles()
        {
            return listaPontoControle = pontoControleRepositorio.ObterTodos();
        }

        private List<Estagio> Estagios()
        {
            return listaEstagios = estagioRepositorio.ObterTodos();
        }

        private List<Perda_Motivo> PerdaMotivo()
        {
            return listaPerdaMotivo = perdaMotivoRepositorio.ObterTodos();
        }

        private User ObterDispositivoId()
        {
            List<User> dispositivoId = new List<User>();
            dispositivoId = userRepositorio.ObterDispositivoId();

            foreach (var item in dispositivoId)
            {
                user = new User
                {
                    disp_id = item.disp_id
                };
            }
            return user;
        }

        private int Index(string objeto)
        {
            int index = -1;

            switch (objeto)
            {
                case "Lote":
                    var listaLotes = Lotes();
                    index = listaLotes.FindIndex(l => l.codigo == _dadosPerdaQr.OloteCodigo);
                    break;
                case "Muda":
                    var listaMudas = Mudas();
                    index = listaMudas.FindIndex(m => m.muda_id == int.Parse(_dadosPerdaQr.OmudaId));
                    break;
                case "PontoControle":
                    var listaPontoControles = PontoControles();
                    index = listaPontoControles.FindIndex(p => p.ponto_controle_id == int.Parse(_dadosPerdaQr.OpontoControleId));
                    break;
                case "Estagio":
                    var listaEstagios = Estagios();
                    index = listaEstagios.FindIndex(e => e.estagio_id == int.Parse(_dadosPerdaQr.OestagioId));
                    break;

                case "PerdaMotivo":
                    var listaMotivos = PerdaMotivo();
                    index = listaMotivos.FindIndex(p => p.perda_motivo_id == int.Parse(_dadosPerdaQr.OPerdaMotivoId));
                    break;
            }
            return index;
        }

        private async Task ValidarCampos()
        {
            if (Data == null)
            {
                await dialogService.AlertAsync("ALERTA", "O campo DATA é obrigatório!", "Ok");
                return;
            }

            if (LoteSelecionado == null)
            {
                await dialogService.AlertAsync("ALERTA", "O campo LOTE é obrigatório!", "Ok");
                return;
            }

            if (MudaSelecionada == null)
            {
                await dialogService.AlertAsync("ALERTA", "O campo MUDA é obrigatório!", "Ok");
                return;
            }

            if (PontoControleSelecionado == null)
            {
                await dialogService.AlertAsync("ALERTA", "O campo PONTO DE CONTROLE é obrigatório!", "Ok");
                return;
            }

            if (EstagioSelecionado == null)
            {
                await dialogService.AlertAsync("ALERTA", "O campo ESTÁGIO é obrigatório!", "Ok");
                return;
            }

            if (string.IsNullOrEmpty(Qtde))
            {
                await dialogService.AlertAsync("ALERTA", "O campo QUANTIDADE é obrigatório!", "Ok");
                return;
            }

            if (MotivoSelecionado == null)
            {
                await dialogService.AlertAsync("ALERTA", "O campo MOTIVO é obrigatório!", "Ok");
                return;
            }
        }
    }
}
