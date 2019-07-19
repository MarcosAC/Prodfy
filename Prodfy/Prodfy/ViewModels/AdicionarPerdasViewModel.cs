using Prodfy.Models;
using Prodfy.Services.Dialog;
using Prodfy.Services.Navigation;
using Prodfy.Services.Repository;
using Prodfy.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class AdicionarPerdasViewModel : BaseViewModel
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

        public List<Lote> listaLotes { get; set; }
        public List<Muda> listaMudas { get; set; }
        public List<Ponto_Controle> listaPontoControle { get; set; }
        public List<Estagio> listaEstagios { get; set; }
        public List<Perda_Motivo> listaPerdaMotivo { get; set; }

        public AdicionarPerdasViewModel()
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

            Lotes();
            Mudas();
            PontoControles();
            Estagios();
            PerdaMotivo();
        }

        private Lote _loteSelecionado;
        public Lote LoteSelecionado
        {
            get => _loteSelecionado;
            set => SetProperty(ref _loteSelecionado, value);
        }

        private Muda _mudaSelecionada;
        public Muda MudaSelecionada
        {
            get => _mudaSelecionada;
            set => SetProperty(ref _mudaSelecionada, value);
        }

        private Ponto_Controle _pontoControleSelecionado;
        public Ponto_Controle PontoControleSelecionado
        {
            get => _pontoControleSelecionado;
            set => SetProperty(ref _pontoControleSelecionado, value);
        }

        private Estagio _estagioSelecionado;
        public Estagio EstagioSelecionado
        {
            get => _estagioSelecionado;
            set => SetProperty(ref _estagioSelecionado, value);
        }

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
            get => _qtde;
            set => SetProperty(ref _qtde, value);
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
            await navigationService.PopAsync();

            var scanner = new ZXing.Mobile.MobileBarcodeScanner();
            var result = await scanner.Scan();

            scanner.Cancel();


            if (result != null)
            {
                IsBusy = true;

                string loteId = string.Empty;
                string loteCodigo = string.Empty;
                string loteProdutoId = string.Empty;
                string mudaId = string.Empty;
                string mudaNomeComum = string.Empty;
                string quantidade = string.Empty;
                string pontoControleId = string.Empty;
                string pontoControleCodigo = string.Empty;
                string pontoControleTitulo = string.Empty;
                string estagioId = string.Empty;
                string estagioCodigo = string.Empty;
                string estagioTitulo = string.Empty;

                string[] resultadoQR = result.Text.Split('|');

                if (resultadoQR.Count() < 8)
                {
                    await dialogService.AlertAsync("Etiqueta QR", "Etiqueta incompatível! Gere uma nova etiqueta QR!", "Ok");

                    IsBusy = false;
                }

                var dadosQR = new
                {
                    qrLoteCod = resultadoQR[0],
                    qrMudaId = resultadoQR[1],
                    qrQtd = resultadoQR[2],
                    qrDataEstaq = resultadoQR[3],
                    qrDensidade = resultadoQR[4],
                    qrPontoControleId = resultadoQR[5],
                    qrEstagioId = resultadoQR[6],
                    qrColaboradorId = resultadoQR[7],
                    qrLivre = resultadoQR[8],
                    qrTipoEtiqueta = resultadoQR[9]
                };

                #region Lote
                if (dadosQR.qrLoteCod != null)
                {
                    loteCodigo = dadosQR.qrLoteCod;
                    //Lote ID
                    string loteInfo = loteRepositorio.ObterLotePorId(dadosQR.qrLoteCod);
                    var tmpLoteInfo = loteInfo.Split('|');

                    if (tmpLoteInfo[0] == "0")
                    {
                        await dialogService.AlertAsync("Etiqueta QR", "Lote indicado no QR inexistente! Sincronize o dispositivo.", "Ok");
                    }
                    loteId = tmpLoteInfo[2];


                    //Lote Produto ID
                    string loteProdutoInfo = loteRepositorio.ObterLoteProdutoPorId(dadosQR.qrLoteCod);
                    var tmpLoteprodutoInfo = loteProdutoInfo.Split('|');

                    if (tmpLoteprodutoInfo[0] == "0")
                    {
                        await dialogService.AlertAsync("Etiqueta QR", "Produto associado ao Lote indicado no QR inexistente! Sincronize o dispositivo.", "Ok");
                    }

                    loteProdutoId = tmpLoteInfo[2];
                }
                #endregion

                #region Muda
                if (dadosQR.qrMudaId != null)
                {
                    mudaId = dadosQR.qrMudaId;

                    //Muda Nome Comum
                    string mudaIndo = mudaRepositorio.ObterInformacoesParaIdentificacao(int.Parse(dadosQR.qrMudaId));
                    var tmpMudainfo = mudaIndo.Split('|');

                    if (tmpMudainfo[0] == "0")
                    {
                        await dialogService.AlertAsync("Etiqueta QR", "Muda indicada no QR inexistente! Sincronize o dispositivo.", "Ok");
                    }

                    mudaNomeComum = tmpMudainfo[3];
                }
                #endregion

                #region Quantidade
                if (dadosQR.qrQtd != null)
                    quantidade = dadosQR.qrQtd;
                #endregion

                #region Ponto Controle
                if (resultadoQR.Count() >= 8)
                {
                    if (dadosQR.qrPontoControleId == null)
                    {

                        pontoControleId = string.Empty;
                        pontoControleCodigo = string.Empty;
                        pontoControleTitulo = string.Empty;
                    }
                    else
                    {
                        pontoControleId = dadosQR.qrPontoControleId;

                        //Ponto Controle Info
                        string pontoControleInfo = pontoControleRepositorio.ObterInformacoesParaIdentificacao(int.Parse(dadosQR.qrPontoControleId));
                        var tmpPontoControleInfo = pontoControleInfo.Split('|');

                        if (tmpPontoControleInfo[0] == "0")
                        {
                            pontoControleId = string.Empty;
                            pontoControleCodigo = string.Empty;
                            pontoControleTitulo = string.Empty;

                            await dialogService.AlertAsync("Etiqueta QR", "Ponto de Controle indicado não localizado!", "Ok");
                        }
                        else
                        {
                            pontoControleCodigo = tmpPontoControleInfo[4];
                            pontoControleTitulo = tmpPontoControleInfo[5];
                        }
                    }
                }
                #endregion

                #region Estagio
                if (!string.IsNullOrEmpty(pontoControleCodigo))
                {
                    if (dadosQR.qrEstagioId == null)
                    {
                        estagioId = string.Empty;
                        estagioCodigo = string.Empty;
                        estagioTitulo = string.Empty;
                    }
                    else
                    {
                        estagioId = dadosQR.qrEstagioId;

                        //Estagio Info
                        string estagioInfo = estagioRepositorio.ObterInformacoesParaIdentificacao(int.Parse(dadosQR.qrPontoControleId), int.Parse(dadosQR.qrEstagioId));
                        var tmpestagioInfo = estagioInfo.Split('|');

                        if (tmpestagioInfo[0] == "0")
                        {
                            estagioId = string.Empty;
                            estagioCodigo = string.Empty;
                            estagioTitulo = string.Empty;

                            await dialogService.AlertAsync("Etiqueta QR", "Estágio indicado não localizado!", "Ok");
                        }
                        else
                        {
                            estagioCodigo = tmpestagioInfo[5];
                            estagioTitulo = tmpestagioInfo[6];
                        }
                    }
                }
                #endregion

                if (!string.IsNullOrEmpty(loteId) &&
                    !string.IsNullOrEmpty(loteCodigo) &&
                    !string.IsNullOrEmpty(loteProdutoId) &&
                    !string.IsNullOrEmpty(mudaId) &&
                    !string.IsNullOrEmpty(mudaNomeComum) &&
                    !string.IsNullOrEmpty(quantidade))
                {
                    var carregarCadastroPerdasQr = new CarregarDadosPerdaQr
                    {
                        OloteId = loteId,
                        OloteCodigo = loteCodigo,
                        OloteProdutoId = loteProdutoId,
                        OmudaId = mudaId,
                        OmudaNomeComum = mudaNomeComum,
                        Oquantidade = quantidade,
                        OpontoControleId = pontoControleId,
                        OestagioId = estagioId
                    };

                    await navigationService.PushAsync(new CadastroPerdasQrView(carregarCadastroPerdasQr));
                }
                else
                {
                    await dialogService.AlertAsync("Etiqueta QR", "Etiqueta incompatível! Gere uma nova etiqueta QR!", "Ok");
                }

                if (dadosQR.qrTipoEtiqueta == null || dadosQR.qrTipoEtiqueta != "1")
                {
                    await dialogService.AlertAsync("ERRO", "Erro ao carregar dados", "Ok");
                }
            }
        }

        private Command _cancelarCadastroCommand;
        public Command CancelarCadastroCommand =>
            _cancelarCadastroCommand ?? (_cancelarCadastroCommand = new Command(async () => await ExecuteCancelarCadastroCommand()));

        private async Task ExecuteCancelarCadastroCommand() => await navigationService.PopAsync();

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
