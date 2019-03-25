using Prodfy.Services;
using Prodfy.Views;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class ContatoViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;

        public ContatoViewModel()
        {
            Title = "Contato";

            _navigationService = new NavigationService();
        }

        private Command _navegacaoTitleVoltarCommand;
        public Command NavegacaoTitleVoltarCommand =>
            _navegacaoTitleVoltarCommand ?? (_navegacaoTitleVoltarCommand = new Command(async () => await ExecuteNavegacaoVoltarTitleCommand()));

        private async Task ExecuteNavegacaoVoltarTitleCommand() => await _navigationService.PopAsync();

        private Command _enviarEmailCommand;
        public Command EnviarEmailCommand =>
            _enviarEmailCommand ?? (_enviarEmailCommand = new Command(ExecuteEnviarEmailCommand));

        private void ExecuteEnviarEmailCommand() => Device.OpenUri(new Uri("mailto:contato@thersistemas.com.br"));

        private Command _irPaginaSiteCommand;
        public Command IrPaginaSiteCommand =>
            _irPaginaSiteCommand ?? (_irPaginaSiteCommand = new Command<string>(async u => await ExecuteIrPaginaSiteCommand(u)));

        private async Task ExecuteIrPaginaSiteCommand(string url) => await _navigationService.PushAsync(new TherWebView(url));        
    }
}
