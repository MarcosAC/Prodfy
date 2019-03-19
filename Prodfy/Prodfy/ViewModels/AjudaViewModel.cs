using Prodfy.Services;
using Prodfy.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class AjudaViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;

        public AjudaViewModel(string url)
        {
            Title = "AjudaFAQ";

            _navigationService = new NavigationService();
        }

        private Command _navegacaoTitleCommand;
        public Command NavegacaoTitleVoltarCommand => 
            _navegacaoTitleCommand ?? (_navegacaoTitleCommand = new Command(async () => await ExecuteNavegacaoTitleCommand()));

        private async Task ExecuteNavegacaoTitleCommand() => await _navigationService.PopAsync();

        private Command _irPaginaAjudaCommand;
        public Command IrPaginaAjudaCommand =>
            _irPaginaAjudaCommand ?? (_irPaginaAjudaCommand = new Command<string>(async u => await ExecuteIrPaginaAjudaCommand(u)));

        private async Task ExecuteIrPaginaAjudaCommand(string url) => await _navigationService.PushAsync(new TherWebView(url));        
    }
}
