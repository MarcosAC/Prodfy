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
    public class PesquisarEstoqueViveiroViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
        private readonly IDialogService dialogService;

        private readonly LoteRepository loteRepositorio;
        private readonly MudaRepository mudaRepositorio;
        private readonly QualidadeRepository qualidadeRepositorio;
        private readonly InvItemRepository invItemRepositorio;

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

            Lotes();
        }

        #region Propriedades

        private bool _visibleCampos;
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
        #endregion

        #region Comandos

        private Command _titleViewBotaoVoltarCommand;
        public Command TitleViewBotaoVoltarCommand =>
            _titleViewBotaoVoltarCommand ?? (_titleViewBotaoVoltarCommand = new Command(async () => await ExecuteTitleViewBotaoVoltarCommand()));

        private async Task ExecuteTitleViewBotaoVoltarCommand() => await navigationService.PopAsync();        

        private Command _pesquisaEstoqueViveiroCommand;
        public Command PesquisaEstoqueViveiroCommand =>
            _pesquisaEstoqueViveiroCommand ?? (_pesquisaEstoqueViveiroCommand = new Command(() => ExecutePesquisaEstoqueViveiroCommand()));

        private void ExecutePesquisaEstoqueViveiroCommand() => VisibleCampos = true;

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
                var totalDias = DateTime.Now - item.data_estaq;           
                listaDataEstaqueamento.Add(item.data_estaq.ToString($"dd/MM/yyyy ({totalDias.Days} Dia's')"));
            }

            return ListaDataEstaqueamentos = listaDataEstaqueamento; 
        }

        private List<string> DatasSelecao()
        {
            var datasSelecao = invItemRepositorio.ObterDataSelecao(LoteSelecionado.lote_id, MudaSelecionada.muda_id, QualidadeSelecionada.qualidade_id, DataEstaqueamentoSelecionada.Substring(0, 10));
            List<string> listaDataSelecao = new List<string>();

            foreach (var item in datasSelecao)
            {
                var totalDias = DateTime.Now - item.data_selecao;
                listaDataSelecao.Add(item.data_selecao.ToString($"dd/MM/yyyy ({totalDias.Days} Dia's')"));
            }

            return ListaDataSelecao = listaDataSelecao;
        }        

        private async Task ValidarCampos()
        {
            if (LoteSelecionado == null)
            {
                await dialogService.AlertAsync("ALERTA", "O campo LOTE é obrigatório!", "Ok");
                return;
            }
        }
        #endregion
    }
}
