using Prodfy.Services;
using Prodfy.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class IdentificacaoViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;

        public IdentificacaoViewModel()
        {
            _navigationService = new NavigationService();
        }

        private Command _irLeitorQR;
        public Command IrLeitorQRCommand => _irLeitorQR ?? (_irLeitorQR = new Command(async () => await ExecuteIrLeitorQRCommand()));

        private async Task ExecuteIrLeitorQRCommand() => await _navigationService.PushAsync(new LeitorQRView());
    }
}
