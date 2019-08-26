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
        private readonly UserRepository userRepositorio;

        private User user;
        private readonly CarregarDadosPerdaQr _dadosPerdaQr;

        public List<Lote> listaLotes { get; set; }
        public List<Muda> listaMudas { get; set; }
        public List<Perda_Motivo> listaPerdaMotivo { get; set; }        

        public CadastroPerdasViewModel(CarregarDadosPerdaQr dadosPerdaQr)
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
            PerdaMotivo();
        }

        #region Propriedades
        private bool _visiblePontoControle = true;
        public bool VisiblePontoControle
        {
            get => _visiblePontoControle;
            set => SetProperty(ref _visiblePontoControle, value);
        }

        private bool _visibleEstagio = true;
        public bool VisibleEstagio
        {
            get => _visibleEstagio;
            set => SetProperty(ref _visibleEstagio, value);
        }

        //public int LoteSelecionadoIndex { get => Index("Lote"); }

        private Lote _loteSelecionado;
        public Lote LoteSelecionado
        {
            get => _loteSelecionado;
            set
            {
                SetProperty(ref _loteSelecionado, value);

                if (_loteSelecionado != null)
                {
                    _listaPonteControle = PontoControles();
                    VisiblePontoControle = false;
                }
            }
        }

        private List<Lote> _listaDeLotes;
        public List<Lote> ListaDeLotes
        {
            get => _listaDeLotes;
            set => SetProperty(ref _listaDeLotes, value);
        }

       //public int MudaSelecionadaIndex { get => Index("Muda"); }

        private Muda _mudaSelecionada;
        public Muda MudaSelecionada
        {
            get => _mudaSelecionada;
            set => SetProperty(ref _mudaSelecionada, value);
        }

        //public int PontoControleSelecionadoIndex { get => Index("PontoControle"); }

        private Ponto_Controle _pontoControleSelecionado;
        public Ponto_Controle PontoControleSelecionado
        {
            get => _pontoControleSelecionado;
            set
            {
                SetProperty(ref _pontoControleSelecionado, value);

                if (_pontoControleSelecionado != null)
                {
                    _listaDeEstagios = Estagios();
                    VisibleEstagio = false;
                }                    
            }
        }

        private List<Ponto_Controle> _listaPonteControle;
        public List<Ponto_Controle> ListaPontoControle
        {
            get => _listaPonteControle;
            set => SetProperty(ref _listaPonteControle, value);
        }

        //public int EstagioSelecionadoIndex { get => Index("Estagio"); }

        private Estagio _estagioSelecionado;
        public Estagio EstagioSelecionado
        {
            get => _estagioSelecionado;
            set => SetProperty(ref _estagioSelecionado, value);
        }

        private List<Estagio> _listaDeEstagios;
        public List<Estagio> ListaDeEstagios
        {
            get => _listaDeEstagios;
            set => SetProperty(ref _listaDeEstagios, value);
        }

        //public int PerdaMotivoSelecionadoIndex { get => Index("PerdaMotivo"); }

        private Perda_Motivo _motivoSelecionado;
        public Perda_Motivo MotivoSelecionado
        {
            get => _motivoSelecionado;
            set => SetProperty(ref _motivoSelecionado, value);
        }

        private DateTime _data = DateTime.Today;
        public DateTime Data
        {
            get => _data;
            set => SetProperty(ref _data, value);
        }

        private string _qtde;
        public string Qtde
        {
            get
            {
                if (_dadosPerdaQr != null)
                    if (!string.IsNullOrEmpty(_dadosPerdaQr.Oquantidade))
                        return _qtde = _dadosPerdaQr.Oquantidade; 

                return _qtde;
            }

            set
            {
                if (_dadosPerdaQr != null)
                    if (!string.IsNullOrEmpty(_dadosPerdaQr.Oquantidade))
                        _dadosPerdaQr.Oquantidade = value;

                SetProperty(ref _qtde, value);                
                OnPropertyChanged();
            }
        }

        private string _indSinc;
        public string IndSinc
        {
            get => _indSinc;
            set => SetProperty(ref _indSinc, value);
            
        }
        #endregion

        #region Commands
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
                    if (string.IsNullOrEmpty(dadosQR.qrPontoControleId))
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

                    await navigationService.PushAsync(new CadastroPerdasView(carregarCadastroPerdasQr));
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
                        await navigationService.PopAsync();
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

        private Command _tappedPontoControleCommand;
        public Command TappedPontoControleCommand =>
            _tappedPontoControleCommand ?? (_tappedPontoControleCommand = new Command(async () => await VerificaPickerPontoControle()));

        // Verifica se os dados do picker e nulo e não envia a mensagem.
        private async Task VerificaPickerPontoControle()
        {
            if (_listaPonteControle == null)
                await dialogService.AlertAsync("ALERTA", "Selecione um LOTE para gerar a lista de PONTOS DE CONTROLE", "Ok");
        }

        private Command _tappedEstagioCommand;
        public Command TappedEstagioCommand =>
            _tappedEstagioCommand ?? (_tappedEstagioCommand = new Command(async () => await VerificaPickerEstagios()));

        // Verifica se os dados do picker e nulo e não envia a mensagem.
        private async Task VerificaPickerEstagios()
        {
            if (_listaDeEstagios == null)
                await dialogService.AlertAsync("ALERTA", "Selecione um PONTO DE CONTROLE para gerar a lista de ESTÁGIOS", "Ok");
        }
        #endregion

        #region Métodos
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
            if (LoteSelecionado != null)
                return ListaPontoControle = pontoControleRepositorio.ObterTodos(LoteSelecionado.produto_id);

            return null;
        }

        private List<Estagio> Estagios()
        {
            if (PontoControleSelecionado != null)
                return ListaDeEstagios = estagioRepositorio.ObterTodos(PontoControleSelecionado.ponto_controle_id);

            return null;
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

        //private int Index(string objeto)
        //{
        //    int index = -1;

        //    switch (objeto)
        //    {
        //        case "Lote":
        //            var listaLotes = Lotes();
        //            if (_dadosPerdaQr != null)
        //                if (!string.IsNullOrEmpty(_dadosPerdaQr.OloteCodigo))
        //                    index = listaLotes.FindIndex(l => l.codigo == _dadosPerdaQr.OloteCodigo);
        //            break;
        //        case "Muda":
        //            var listaMudas = Mudas();
        //            if (_dadosPerdaQr != null)
        //                if (!string.IsNullOrEmpty(_dadosPerdaQr.OmudaId))
        //                    index = listaMudas.FindIndex(m => m.muda_id == int.Parse(_dadosPerdaQr.OmudaId));
        //            break;
        //        case "PontoControle":
        //            var listaPontoControles = PontoControles();
        //            if (_dadosPerdaQr != null)
        //                if (!string.IsNullOrEmpty(_dadosPerdaQr.OpontoControleId))
        //                    index = listaPontoControles.FindIndex(p => p.ponto_controle_id == int.Parse(_dadosPerdaQr.OpontoControleId));
        //            break;
        //        case "Estagio":
        //            var listaEstagios = Estagios();
        //            if (_dadosPerdaQr != null)
        //                if (!string.IsNullOrEmpty(_dadosPerdaQr.OestagioId))
        //                    index = listaEstagios.FindIndex(e => e.estagio_id == int.Parse(_dadosPerdaQr.OestagioId));
        //            break;
        //        case "PerdaMotivo":
        //            var listaMotivos = PerdaMotivo();
        //            if (_dadosPerdaQr != null)
        //                if (!string.IsNullOrEmpty(_dadosPerdaQr.OPerdaMotivoId))
        //                    index = listaMotivos.FindIndex(p => p.perda_motivo_id == int.Parse(_dadosPerdaQr.OPerdaMotivoId));
        //            break;
        //    }
        //    return index;
        //}

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
        #endregion
    }
}