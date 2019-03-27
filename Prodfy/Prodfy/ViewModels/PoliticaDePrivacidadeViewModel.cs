using Prodfy.Services;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class PoliticaDePrivacidadeViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;

        public PoliticaDePrivacidadeViewModel()
        {
            Title = "Política de Privacidade";

            _navigationService = new NavigationService();
        }

        private Command _navegacaoTitleVoltarCommand;
        public Command NavegacaoTitleVoltarCommand => _navegacaoTitleVoltarCommand ?? (_navegacaoTitleVoltarCommand = new Command(async () => await ExecuteNavegacaoTitleVoltarCommand()));

        private async Task ExecuteNavegacaoTitleVoltarCommand() => await _navigationService.PopAsync();
    }
}