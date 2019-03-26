using Prodfy.Services;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class TherWebViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;

        public TherWebViewModel(string titulo)
        {
            Title = Titulo(titulo);

            _navigationService = new NavigationService();         
        }

        private string _url;
        public string Url
        {
            get => _url;
            set => SetProperty(ref _url, value);
        }        

        private Command _navegacaoCommand;
        public Command NavegacaoCommand => _navegacaoCommand ?? (_navegacaoCommand = new Command(async () => await ExecuteNavegacaoCommand()));

        private async Task ExecuteNavegacaoCommand() => await _navigationService.PopAsync();

        private string Titulo(string titulo)
        {
            switch (titulo)
            {
                case "https://www.prodfy.com.br/plantas/ajuda/manual_app_ios.htm":
                    return "Ajuda";
                case "https://www.prodfy.com.br":
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
