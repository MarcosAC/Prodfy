using Prodfy.Models;
using Prodfy.Services.Dialog;
using Prodfy.Services.Navigation;
using Prodfy.Services.Repository;
using Prodfy.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class PesquisarEstoqueViveiroViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
        private readonly IDialogService dialogService;

        private readonly LoteRepository loteRepositorio;
        private readonly MudaRepository mudaRepositorio;
        private readonly QualidadeRepository qualidadeRepositorio;
        private readonly InvItemRepository invItemRepositorio;
        private readonly PontoControleRepository pontoControleRepositorio;

        public List<LotesEstoqueViveiro> listaLotes { get; set; }

        public PesquisarEstoqueViveiroViewModel()
        {
            Title = "Estoque Viveiro";

            navigationService = new NavigationService();
            dialogService = new DialogService();

            loteRepositorio = new LoteRepository();
            mudaRepositorio = new MudaRepository();
            qualidadeRepositorio = new QualidadeRepository();
            invItemRepositorio = new InvItemRepository();
            pontoControleRepositorio = new PontoControleRepository();

            Lotes();
        }

        #region Propriedades

        private bool _visibleLabel = true;
        public bool VisibleLabel
        {
            get => _visibleLabel;
            set => SetProperty(ref _visibleLabel, value);
        }

        private bool _visibleCampos = false;
        public bool VisibleCampos
        {
            get => _visibleCampos;
            set => SetProperty(ref _visibleCampos, value);
        }

        private bool _visibleMuda = true;
        public bool VisibleMuda
        {
            get => _visibleMuda;
            set => SetProperty(ref _visibleMuda, value);
        }

        private bool _visibleQualidade = true;
        public bool VisibleQualidade
        {
            get => _visibleQualidade;
            set => SetProperty(ref _visibleQualidade, value);
        }

        private bool _visibleDataEstaquemento = true;
        public bool VisibleDataEstaquemento
        {
            get => _visibleDataEstaquemento;
            set => SetProperty(ref _visibleDataEstaquemento, value);
        }

        private bool _visibleDataSelecao = true;
        public bool VisibleDataSelecao
        {
            get => _visibleDataSelecao;
            set => SetProperty(ref _visibleDataSelecao, value);
        }

        private bool _visibleHTML = false;
        public bool VisibleHTML
        {
            get => _visibleHTML;
            set => SetProperty(ref _visibleHTML, value);
        }

        private int _loteSelecionadoIndex = -1;
        public int LoteSelecionadoIndex
        {
            get => _loteSelecionadoIndex;
            set => SetProperty(ref _loteSelecionadoIndex, value);
        }

        private LotesEstoqueViveiro _loteSelecionado;
        public LotesEstoqueViveiro LoteSelecionado
        {
            get => _loteSelecionado;
            set
            {
                SetProperty(ref _loteSelecionado, value);

                if (_loteSelecionado != null)
                {
                    _listaMudas = Mudas();
                    VisibleMuda = false;
                }
            }
        }

        private MudasEstoqueViveiro _mudaSelecionada;
        public MudasEstoqueViveiro MudaSelecionada
        {
            get => _mudaSelecionada;
            set
            {
                SetProperty(ref _mudaSelecionada, value);

                if (_mudaSelecionada != null)
                {
                    _listaQualidades = Qualidades();
                    VisibleQualidade = false;
                }
            }
        }

        private List<MudasEstoqueViveiro> _listaMudas;
        public List<MudasEstoqueViveiro> ListaMudas
        {
            get => _listaMudas;
            set => SetProperty(ref _listaMudas, value);
        }

        private QualidadeEstoqueViveiro _qualidadeSelecionada;
        public QualidadeEstoqueViveiro QualidadeSelecionada
        {
            get => _qualidadeSelecionada;
            set
            {
                SetProperty(ref _qualidadeSelecionada, value);

                if (_qualidadeSelecionada != null)
                {
                    _listaDataEstaqueamentos = DatasEstaqueamentos();
                    VisibleDataEstaquemento = false;
                }
            }
        }

        private List<QualidadeEstoqueViveiro> _listaQualidades;
        public List<QualidadeEstoqueViveiro> ListaQualidades
        {
            get => _listaQualidades;
            set => SetProperty(ref _listaQualidades, value);
        }

        private string _dataEstaqueamentoSelecionada;
        public string DataEstaqueamentoSelecionada
        {
            get => _dataEstaqueamentoSelecionada;
            set
            {
                SetProperty(ref _dataEstaqueamentoSelecionada, value);

                if (_dataEstaqueamentoSelecionada != null)
                {
                    _listaDataSelecao = DatasSelecao();
                    VisibleDataSelecao = false;
                }
            }
        }

        private List<string> _listaDataEstaqueamentos;
        public List<string> ListaDataEstaqueamentos
        {
            get => _listaDataEstaqueamentos;
            set => SetProperty(ref _listaDataEstaqueamentos, value);
        }

        private string _dataSelecaoSelecionada;
        public string DataSelecaoSelecionada
        {
            get => _dataSelecaoSelecionada;
            set => SetProperty(ref _dataSelecaoSelecionada, value);
        }

        private List<string> _listaDataSelecao;
        public List<string> ListaDataSelecao
        {
            get => _listaDataSelecao;
            set => SetProperty(ref _listaDataSelecao, value);
        }

        private string _codigoHTML;
        public string CodigoHTML
        {
            get => _codigoHTML;
            set => SetProperty(ref _codigoHTML, value);
        }
        #endregion

        #region Comandos

        private Command _titleViewBotaoVoltarCommand;
        public Command TitleViewBotaoVoltarCommand =>
            _titleViewBotaoVoltarCommand ?? (_titleViewBotaoVoltarCommand = new Command(async () => await ExecuteTitleViewBotaoVoltarCommand()));

        private async Task ExecuteTitleViewBotaoVoltarCommand() => await navigationService.PopAsync();        

        private Command _pesquisaEstoqueViveiroCommand;
        public Command PesquisaEstoqueViveiroCommand =>
            _pesquisaEstoqueViveiroCommand ?? (_pesquisaEstoqueViveiroCommand = new Command(() => ExecutePesquisaEstoqueViveiroCommand()));

        private void ExecutePesquisaEstoqueViveiroCommand()
        {
            VisibleCampos = true;
            VisibleLabel = false;
        }

        private Command _tappedMudaCommand;
        public Command TappedMudaCommand =>
            _tappedMudaCommand ?? (_tappedMudaCommand = new Command(async () => await ExecuteVerificaPickerMudasCommand()));

        // Verifica se os dados do picker e nulo e envia a mensagem.
        private async Task ExecuteVerificaPickerMudasCommand()
        {
            if (_listaMudas == null || _listaMudas.Count == 0)
                await dialogService.AlertAsync("ALERTA", "Selecione um LOTE para gerar a lista de MUDAS!", "Ok");
        }

        private Command _tappedQualidadeCommand;
        public Command TappedQualidadeCommand =>
            _tappedQualidadeCommand ?? (_tappedQualidadeCommand = new Command(async () => await ExecuteVerificaPickerQualidadesCommand()));

        private async Task ExecuteVerificaPickerQualidadesCommand()
        {
            if (_listaQualidades == null || _listaQualidades.Count == 0)
                await dialogService.AlertAsync("ALERTA", "Selecione uma MUDA para gerar a lista de QUALIDADES!", "Ok");
        }

        private Command _tappedDataEstaqueamentoCommand;
        public Command TappedDataEstaqueamentoCommand =>
            _tappedDataEstaqueamentoCommand ?? (_tappedDataEstaqueamentoCommand = new Command(async () => await ExecuteVerificaPickerDataEstaqueamentoCommand()));
       
        private async Task ExecuteVerificaPickerDataEstaqueamentoCommand()
        {
            if (_listaDataEstaqueamentos == null || _listaDataEstaqueamentos.Count == 0)
                await dialogService.AlertAsync("ALERTA", "Selecione uma QUALIDADE para gerar a lista de DATAS DE ESTAQUEAMENTO!", "Ok");
        }

        private Command _tappedDataSelecaoCommand;
        public Command TappedDataSelecaoCommand =>
            _tappedDataSelecaoCommand ?? (_tappedDataSelecaoCommand = new Command(async () => await ExecuteVerificaPickerDataSelecaoCommand()));

        private async Task ExecuteVerificaPickerDataSelecaoCommand()
        {
            if (_listaDataSelecao == null || _listaDataSelecao.Count == 0)
                await dialogService.AlertAsync("ALERTA", "Selecione uma DATA DE ESTAQUEAMENTO para gerar a lista de DATAS DE SELEÇÃO!", "Ok");
        }

        private Command _localizarCommand;
        public Command LocalizarCommand =>
            _localizarCommand ?? (_localizarCommand = new Command(() => ExecuteLocalizarCommand()));

        private void ExecuteLocalizarCommand()
        {
            ValidarCampos();            
            PaginaHTML();
            VisibleCampos = false;
            VisibleHTML = true;
        }

        private Command _limparCamposCommand;
        public Command LimparCamposCommand =>
            _limparCamposCommand ?? (_limparCamposCommand = new Command(() => ExecuteLimparCamposCommand()));

        private void ExecuteLimparCamposCommand()
        {
            LoteSelecionadoIndex = -1;

            var listaMudas = new List<MudasEstoqueViveiro>();
            var listaQualidades = new List<QualidadeEstoqueViveiro>();
            var listaDataEstaqueamento = new List<string>();
            var listdaDataSelecao = new List<string>();

            #region Verifica se listas estão vazias

            if (listaMudas != null || listaMudas.Count > 0)
            {
                listaMudas.Clear();
                ListaMudas = listaMudas;
                VisibleMuda = true;
            }

            if (listaQualidades != null || listaQualidades.Count > 0)
            {
                listaQualidades.Clear();
                ListaQualidades = listaQualidades;
                VisibleQualidade = true;
            }            

            if (listaDataEstaqueamento != null || listaDataEstaqueamento.Count > 0)
            {
                listaDataEstaqueamento.Clear();
                ListaDataEstaqueamentos = listaDataEstaqueamento;
                VisibleDataEstaquemento = true;
            }

            if (listdaDataSelecao != null || listdaDataSelecao.Count > 0)
            {
                listdaDataSelecao.Clear();
                ListaDataSelecao = listdaDataSelecao;
                VisibleDataSelecao = true;
            }
            #endregion
        }
        #endregion

        #region Métodos e Funções

        private List<LotesEstoqueViveiro> Lotes()
        {
            return listaLotes = loteRepositorio.ObterLotesEstoqueViveiro();
        }

        private List<MudasEstoqueViveiro> Mudas()
        {
            return ListaMudas = mudaRepositorio.ObterMudasEstoqueViveiro(LoteSelecionado.lote_id);
        }

        private List<QualidadeEstoqueViveiro> Qualidades()
        {
            return ListaQualidades = qualidadeRepositorio.ObterQualidadeEstoqueViveiro(LoteSelecionado.lote_id, MudaSelecionada.muda_id);
        }

        private List<string> DatasEstaqueamentos()
        {
            var datasEstaqueamentos = invItemRepositorio.ObterDataEstaquemento(LoteSelecionado.lote_id, MudaSelecionada.muda_id, QualidadeSelecionada.qualidade_id);
            List<string> listaDataEstaqueamento = new List<string>();

            foreach (var item in datasEstaqueamentos)
            {
                int totalDias = int.Parse(CalculaIdade.CalcularPorDataIniciaDataFinal(item.data_estaq, DateTime.Now));

                if (totalDias <= 0 || totalDias > 1)
                    listaDataEstaqueamento.Add(item.data_estaq.ToString($"dd/MM/yyyy ({totalDias} Dia's')"));
                else
                    listaDataEstaqueamento.Add(item.data_estaq.ToString($"dd/MM/yyyy ({totalDias} Dia)"));
            }

            return ListaDataEstaqueamentos = listaDataEstaqueamento; 
        }

        private List<string> DatasSelecao()
        {
            var datasSelecao = invItemRepositorio.ObterDataSelecao(LoteSelecionado.lote_id, MudaSelecionada.muda_id, QualidadeSelecionada.qualidade_id, DataEstaqueamentoSelecionada.Substring(0, 10));
            List<string> listaDataSelecao = new List<string>();

            foreach (var item in datasSelecao)
            {
                int totalDias = int.Parse(CalculaIdade.CalcularPorDataIniciaDataFinal(item.data_selecao, DateTime.Now));

                if (totalDias <= 0 || totalDias > 1)
                    listaDataSelecao.Add(item.data_selecao.ToString($"dd/MM/yyyy ({totalDias} Dia's')"));
                else
                    listaDataSelecao.Add(item.data_selecao.ToString($"dd/MM/yyyy ({totalDias} Dia)"));
            }

            return ListaDataSelecao = listaDataSelecao;
        }        

        private void PaginaHTML()
        {
            string codigoHtml = string.Empty;
            string tmp = string.Empty;

            #region Lote

            string info_lote_id = string.Empty;
            string info_lote_codigo = string.Empty;
            string info_lote_objetivo = string.Empty;
            string info_lote_cliente = string.Empty;
            string info_lote_titulo = string.Empty;            
            string lote_txt = string.Empty;

            if (LoteSelecionado != null && LoteSelecionado.lote_id > 0)
            {
                tmp = loteRepositorio.ObterLoteInfoPorId(LoteSelecionado.lote_id.ToString());
                var infoLote = tmp.Split('|');

                if (infoLote[0] == "1")
                {
                    info_lote_id = infoLote[2];
                    info_lote_codigo = infoLote[3];
                    info_lote_objetivo = infoLote[4];
                    info_lote_cliente = infoLote[5];
                    info_lote_titulo = infoLote[6];
                }

                lote_txt = $"<b>{info_lote_codigo}";

                if (!string.IsNullOrEmpty(info_lote_titulo))
                    lote_txt += $" (<small>{info_lote_titulo}</small>)";

                lote_txt += "</br>";
            }
            else
            {
                lote_txt += "<small><b>GERAL</b></small>";
            }

            #endregion Lote

            #region Muda

            string info_muda_id = string.Empty;
            string info_muda_nome_interno = string.Empty;
            string info_muda_nome = string.Empty;
            string info_muda_especie = string.Empty;
            string info_muda_origem = string.Empty;
            string info_muda_viveiro = string.Empty;
            string info_muda_canaletao = string.Empty;
            string info_muda_linha = string.Empty;
            string info_muda_coluna = string.Empty;
            string info_muda_qtde = string.Empty;
            string planta_txt = string.Empty;

            if (MudaSelecionada != null || MudaSelecionada.muda_id > 0)
            {
                var dadosMuda = mudaRepositorio.ObterMudaInfo(MudaSelecionada.muda_id.ToString());
                var infoMuda = dadosMuda.Split('|');

                if (infoMuda[0] == "1")
                {
                    info_muda_id = infoMuda[2];
                    info_muda_nome_interno = infoMuda[3];
                    info_muda_nome = infoMuda[4];
                    info_muda_especie = infoMuda[5];
                    info_muda_origem = infoMuda[8];
                    info_muda_viveiro = infoMuda[9];
                    info_muda_canaletao = infoMuda[10];
                    info_muda_linha = infoMuda[11];
                    info_muda_coluna = infoMuda[12];
                    info_muda_qtde = infoMuda[13];
                }

                planta_txt = $"<b>{info_muda_nome_interno}";

                if (!string.IsNullOrEmpty(info_muda_especie))
                    planta_txt += $" - <small><i>{info_muda_especie}</i></small>";
                else if (!string.IsNullOrEmpty(info_muda_nome))
                    planta_txt += $" - <small><i>{info_muda_nome}</i></small>";

                planta_txt += "</br>";
            }
            else
            {
                planta_txt += "<small>GERAL</small>";
            }

            #endregion Muda

            #region Qualidade

            string info_qualidade_id = string.Empty;
            string info_qualidade_codigo = string.Empty;
            string info_qualidade_titulo = string.Empty;
            string qualidade_txt = string.Empty;

            if (QualidadeSelecionada != null || QualidadeSelecionada.qualidade_id > 0)
            {
                var dadosQualidade = qualidadeRepositorio.ObterQualidadeInfo(QualidadeSelecionada.qualidade_id);
                var infoQualidade = dadosQualidade.Split('|');

                if (infoQualidade[0] == "1")
                {
                    info_qualidade_id = infoQualidade[2];
                    info_qualidade_codigo = infoQualidade[3];
                    info_qualidade_titulo = infoQualidade[4];
                }

                qualidade_txt = $"<b>{info_qualidade_titulo}";
            }
            else
            {
                qualidade_txt += "<small>GERAL</small>";
            }

            #endregion Qualidade

            #region Data Estaqueamento

            string data_estaq_txt = string.Empty;

            if (!string.IsNullOrEmpty(DataEstaqueamentoSelecionada))
            {
                data_estaq_txt = $"<b>{DataEstaqueamentoSelecionada}</b>";
            }
            else
            {
                data_estaq_txt += "<small>GERAL</small>";
            }

            #endregion Data Estaqueamento

            #region Data Seleção

            string data_selecao_txt = string.Empty;

            if (!string.IsNullOrEmpty(DataSelecaoSelecionada))
            {
                data_selecao_txt = $"<b>{DataSelecaoSelecionada}</b>";
            }
            else
            {
                data_selecao_txt += "<small>GERAL</small>";
            }

            #endregion Data Seleção

            #region Locais

            string locais = string.Empty;
            string locaisEstagios = string.Empty;
            string listaPontoControle = string.Empty;
            string listaPontoControleEstagio = string.Empty;
            string pontoControleEstagioQuantidade = string.Empty;
            string dataEstaqueamento = null;
            string dataSelecao = null;

            if (DataSelecaoSelecionada != null)
                dataSelecao = DataSelecaoSelecionada.Substring(0, 10);

            var dadosPontoControle = pontoControleRepositorio.ObterEstoqueViveiroPontoControle(LoteSelecionado.lote_id, 
                                                                                               MudaSelecionada.muda_id, 
                                                                                               QualidadeSelecionada.qualidade_id,
                                                                                               dataEstaqueamento,
                                                                                               dataSelecao);

            #endregion Locais

            #region Codigo HTML

            /*
             * Retirei o padding: 15px; -> 10px e alterei o text-indent: 30px; -> 20px, dessa linha CSS:   
             * .info-table td { width: 400px; font-size: 18px; text-align: left; vertical-align: top; color:#0000ff; text-indent: 20px; }
             * 
             * Alterei o tamanho da fonte para 18px
             */
            codigoHtml = "<html><head><title>Prodfy APP</title></head>";
            codigoHtml += "<style type='text/css'>";
            codigoHtml += "body { background-color: transparent; font-family: Helvetica; font-size: 60px; margin:10px 0; padding:0; text-align:center; margin-left: 15px; margin-right: 15px; margin-top: 15px; }";
            codigoHtml += ".info-table { width: 100%; } .info-table th { width: 60px; font-size: 18px; text-align: left; vertical-align: top; padding: 10px; color:black; white-space: nowrap; } .info-table td { width: 400px; font-size: 18px; text-align: left; vertical-align: top; color:#0000ff; text-indent: 20px; }";
            codigoHtml += ".font-size-70 { font-size: 70%; }";
            codigoHtml += "</style><body><center>";
            codigoHtml += "<table class='info-table'>";

            if (!string.IsNullOrEmpty(info_lote_id))
                codigoHtml += $"<tr><th><br/><b>Lote:</b></th></tr><tr><td><small>{lote_txt}</small></td></tr>";

            if (!string.IsNullOrEmpty(info_muda_id))
                codigoHtml += $"<tr><th><br/><b>Planta:</b></th></tr><tr><td><small>{planta_txt}</small></td></tr>";

            if (!string.IsNullOrEmpty(info_qualidade_id))
                codigoHtml += $"<tr><th><br/><b>Qualidade:</b></th></tr><tr><td><small>{qualidade_txt}</small></td></tr>";

            if (!string.IsNullOrEmpty(DataEstaqueamentoSelecionada))
                codigoHtml += $"<tr><th><br/><b>Estaqueamento:</b></th></tr><tr><td><small>{data_estaq_txt}</small></td></tr>";

            if (!string.IsNullOrEmpty(DataSelecaoSelecionada))
                codigoHtml += $"<tr><th><br/><b>Seleção:</b></th></tr><tr><td><small>{data_selecao_txt}</small></td></tr>";

            codigoHtml += "</table><br/><br/></center></body></html>";

            CodigoHTML = codigoHtml;

            VisibleCampos = false;
            VisibleHTML = true;

            #endregion Codigo HTML
        }

        private void ValidarCampos()
        {
            if (LoteSelecionado == null)
            {
                dialogService.AlertAsync("ALERTA", "O campo LOTE é obrigatório!", "Ok");
                return;
            }
        }
        #endregion
    }
}
