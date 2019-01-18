using Prodfy.Services;
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

        private Command _navegacaoCommand;
        public Command NavegacaoCommand => _navegacaoCommand ?? (_navegacaoCommand = new Command(async () => await ExecuteNavegacaoCommand()));

        private async Task ExecuteNavegacaoCommand() => await _navigationService.PopAsync();
    }
}
