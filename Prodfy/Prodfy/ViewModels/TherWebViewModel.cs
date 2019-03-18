using Prodfy.Services;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class TherWebViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;

        public TherWebViewModel(string nomePagina)
        {
            Title = Titulo(nomePagina);

            _navigationService = new NavigationService();         
        }

        private string _arquivoHtml;
        public string ArquivoHtml
        {
            get => _arquivoHtml;
            set => SetProperty(ref _arquivoHtml, value);
        }        

        private Command _navegacaoCommand;
        public Command NavegacaoCommand => _navegacaoCommand ?? (_navegacaoCommand = new Command(async () => await ExecuteNavegacaoCommand()));

        private async Task ExecuteNavegacaoCommand() => await _navigationService.PopAsync();

        private string Titulo(string nomePagina)
        {
            switch (nomePagina)
            {
                case "ajuda.htm":
                    return "AjudaFAQ";
                case "contato.htm":
                    return "Contato";                    
                case "termos.htm":
                    return "Termos de Uso";
                case "politica.htm":
                    return "Politica de Privacidade";
            }
            return string.Empty;
        }
    }
}
