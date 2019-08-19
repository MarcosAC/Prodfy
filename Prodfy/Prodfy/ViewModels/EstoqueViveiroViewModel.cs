using Prodfy.Services.Dialog;
using Prodfy.Services.Navigation;

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
    }
}
