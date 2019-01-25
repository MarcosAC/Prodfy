using Prodfy.Services;
using Prodfy.Views;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class SobreViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;

        public SobreViewModel()
        {
            _navigationService = new NavigationService();
        }        

        private Command _irTherWebView;
        public Command IrTherWebView =>
            _irTherWebView ?? (_irTherWebView = new Command<string>(async p => await ExecuteIrTherWebViewCommand(p)));

        private async Task ExecuteIrTherWebViewCommand(string nomePagina)
        {
            switch (nomePagina)
            {
                case "AjudaFAQ":
                    await _navigationService.PushAsync(new TherWebView("ajuda.htm"));
                    break;
                case "Contato":
                    await _navigationService.PushAsync(new TherWebView("contato.htm"));
                    break;
                case "TermosUso":
                    await _navigationService.PushAsync(new TherWebView("thermos.htm"));
                    break;
                case "PoliticaPrivacidade":
                    await _navigationService.PushAsync(new TherWebView("politica.htm"));
                    break;
            }
        }

        private Command _irContato;
        public Command IrContato =>
            _irContato ?? (_irContato = new Command(async () => await ExecuteIrContatoCommand()));

        private Task ExecuteIrContatoCommand()
        {
            throw new NotImplementedException();
        }

        private Command _irTermosUso;
        public Command IrTermosUso =>
            _irTermosUso ?? (_irTermosUso = new Command(async () => await ExecuteTermosUsoCommand()));

        private Task ExecuteTermosUsoCommand()
        {
            throw new NotImplementedException();
        }

        private Command _irPoliticaPrivacidade;
        public Command IrPoliticaUso =>
            _irPoliticaPrivacidade ?? (_irPoliticaPrivacidade = new Command(async () => await ExecuteIrPoliticaPrivacidadeCommand()));

        private Task ExecuteIrPoliticaPrivacidadeCommand()
        {
            throw new NotImplementedException();
        }
    }
}
