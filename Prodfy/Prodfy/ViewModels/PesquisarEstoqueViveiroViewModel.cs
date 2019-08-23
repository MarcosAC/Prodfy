using Prodfy.Models;
using Prodfy.Services.Dialog;
using Prodfy.Services.Navigation;
using Prodfy.Services.Repository;
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

        public List<Lote> listaLotes { get; set; }
        public List<Muda> listaMudas { get; set; }
        public List<Qualidade> listaQualidade { get; set; }

        public PesquisarEstoqueViveiroViewModel()
        {
            Title = "Estoque Viveiro";

            navigationService = new NavigationService();
            dialogService = new DialogService();

            loteRepositorio = new LoteRepository();
            mudaRepositorio = new MudaRepository();
            qualidadeRepositorio = new QualidadeRepository();

            Lotes();
            Mudas();
            Qualidade();
        }        

        private bool _visible;
        public bool Visible
        {
            get => _visible;
            set => SetProperty(ref _visible, value);
        }

        private Lote _loteSelecionado;
        public Lote LoteSelecionado
        {
            get => _loteSelecionado;
            set
            {
                SetProperty(ref _loteSelecionado, value);

                //if (_loteSelecionado != null)
                //{
                //    _listaPonteControle = PontoControles();
                //    VisiblePontoControle = false;
                //}
            }
        }

        private List<Lote> _listaDeLotes;
        public List<Lote> ListaDeLotes
        {
            get => _listaDeLotes;
            set => SetProperty(ref _listaDeLotes, value);
        }

        private Muda _mudaSelecionada;
        public Muda MudaSelecionada
        {
            get => _mudaSelecionada;
            set => SetProperty(ref _mudaSelecionada, value);
        }

        private Qualidade _qualidadeSelecionada;
        public Qualidade QualidadeSelecionada
        {
            get => _qualidadeSelecionada;
            set => SetProperty(ref _qualidadeSelecionada, value);
        }

        private Command _titleViewBotaoVoltarCommand;
        public Command TitleViewBotaoVoltarCommand =>
            _titleViewBotaoVoltarCommand ?? (_titleViewBotaoVoltarCommand = new Command(async () => await ExecuteTitleViewBotaoVoltarCommand()));

        private async Task ExecuteTitleViewBotaoVoltarCommand() => await navigationService.PopAsync();        

        private Command _pesquisaEstoqueViveiroCommand;
        public Command PesquisaEstoqueViveiroCommand =>
            _pesquisaEstoqueViveiroCommand ?? (_pesquisaEstoqueViveiroCommand = new Command(() => ExecutePesquisaEstoqueViveiroCommand()));

        private void ExecutePesquisaEstoqueViveiroCommand() => Visible = true;

        private List<Lote> Lotes()
        {
            return listaLotes = loteRepositorio.ObterTodos();
        }

        private List<Muda> Mudas()
        {
            return listaMudas = mudaRepositorio.ObterTodos();
        }

        private List<Qualidade> Qualidade()
        {
            return listaQualidade = qualidadeRepositorio.ObterTodos();
        }
    }
}
