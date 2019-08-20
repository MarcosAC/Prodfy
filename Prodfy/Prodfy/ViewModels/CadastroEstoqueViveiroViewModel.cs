using Prodfy.Services.Dialog;
using Prodfy.Services.Navigation;
using Prodfy.Services.Repository;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class CadastroEstoqueViveiroViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
        private readonly IDialogService dialogService;

        private readonly EstoqueViveiroRepository estoqueViveiroRepositorio;

        public CadastroEstoqueViveiroViewModel()
        {
            Title = "Estoque Viveiro";

            navigationService = new NavigationService();
            dialogService = new DialogService();

            estoqueViveiroRepositorio = new EstoqueViveiroRepository();
        }

        private Command _titleViewBotaoVoltarCommand;
        public Command TitleViewBotaoVoltarCommand =>
            _titleViewBotaoVoltarCommand ?? (_titleViewBotaoVoltarCommand = new Command(async () => await ExecuteTitleViewBotaoVoltarCommand()));

        private async Task ExecuteTitleViewBotaoVoltarCommand() => await navigationService.PopAsync();

        private Command _pesquisarEstoqueViveiroCommand;
        public Command PesquisarEstoqueViveiroCommand =>
            _pesquisarEstoqueViveiroCommand ?? (_pesquisarEstoqueViveiroCommand = new Command(() => ExecutePesquisarEstoqueViveiroCommand()));

        private void ExecutePesquisarEstoqueViveiroCommand() => estoqueViveiroRepositorio.ListaLotesEstoqueViveiro();
    }
}
