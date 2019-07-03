using Prodfy.Models;
using Prodfy.Services;
using Prodfy.Services.Dialog;
using Prodfy.Services.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class CadastroPerdasViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
        private readonly IDialogService dialogService;

        private readonly LoteRepository loteRepositorio;
        private readonly PerdaRepository perdaRepositorio;
        private readonly MudaRepository mudaRepositorio;
        private readonly PontoControleRepository pontoControleRepositorio;
        private readonly EstagioRepository estagioRepositorio;
        private readonly PerdaMotivoRepository perdaMotivoRepositorio;

        public CadastroPerdasViewModel()
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

            Lotes();
            Mudas();
            PontoControle();
            Estagios();
            PerdaMotivo();
        }

        public List<Lote> listaLotes { get; set; }
        public List<Muda> listaMudas { get; set; }
        public List<Ponto_Controle> listaPontoControle { get; set; }
        public List<Estagio> listaEstagios { get; set; }
        public List<Perda_Motivo> listaPerdaMotivo { get; set; }        

        private string _dispId;
        public string DispId
        {
            get => _dispId;
            set => SetProperty(ref _dispId, value);
        }

        private string _loteId;
        public string LoteId
        {
            get => _loteId;
            set => SetProperty(ref _loteId, value);
        }

        private string _mudaId;
        public string MudaId
        {
            get => _mudaId;
            set => SetProperty(ref _mudaId, value);
        }

        private string _produtoId;
        public string ProdutoId
        {
            get => _produtoId;
            set => SetProperty(ref _produtoId, value);
        }

        private string _pontoControleId;
        public string PontoControleId
        {
            get => _pontoControleId;
            set => SetProperty(ref _pontoControleId, value);
        }

        private string _estagioId;
        public string EstagioId
        {
            get => _estagioId;
            set => SetProperty(ref _estagioId, value);
        }

        private string _motivoId;
        public string MotivoId
        {
            get => _motivoId;
            set => SetProperty(ref _motivoId, value);
        }

        private DateTime _data;
        public DateTime Data
        {
            get => _data;
            set => SetProperty(ref _data, value);
        }

        private string _qtde;
        public string Qtde
        {
            get => _qtde;
            set => SetProperty(ref _qtde, value);
        }

        private string _lastUpdate;
        public string LastUpdate
        {
            get => _lastUpdate;
            set => SetProperty(ref _lastUpdate, value);
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
                var perda = new Perda
                {
                    data = Data,
                    lote_id = Convert.ToInt32(LoteId),
                    muda_id = Convert.ToInt32(MudaId),
                    ponto_controle_id = Convert.ToInt32(PontoControleId),
                    estagio_id = Convert.ToInt32(EstagioId),
                    qtde = Convert.ToInt32(Qtde),
                    motivo_id = Convert.ToInt32(MotivoId)
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

                throw;
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

        private List<Ponto_Controle> PontoControle()
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
    }
}
