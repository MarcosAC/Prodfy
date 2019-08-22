using Prodfy.Services.Dialog;
using Prodfy.Services.Navigation;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class EstoqueViveiroViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
        private readonly IDialogService dialogService;

        public EstoqueViveiroViewModel()
        {
            Title = "Estoque Viveiro";

            navigationService = new NavigationService();
            dialogService = new DialogService();
        }

        private bool _visible;
        public bool Visible
        {
            get => _visible;
            set => SetProperty(ref _visible, value);
        }

        private Command _titleViewBotaoVoltarCommand;
        public Command TitleViewBotaoVoltarCommand =>
            _titleViewBotaoVoltarCommand ?? (_titleViewBotaoVoltarCommand = new Command(async () => await ExecuteTitleViewBotaoVoltarCommand()));

        private async Task ExecuteTitleViewBotaoVoltarCommand() => await navigationService.PopAsync();        

        private Command _pesquisaEstoqueViveiroCommand;
        public Command PesquisaEstoqueViveiroCommand =>
            _pesquisaEstoqueViveiroCommand ?? (_pesquisaEstoqueViveiroCommand = new Command(() => ExecutePesquisaEstoqueViveiroCommand()));

        private void ExecutePesquisaEstoqueViveiroCommand() => Visible = true;
    }
}
