using Prodfy.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class AjustesViewModel : BaseViewModel
    {
        //private readonly INavigationService _navigationService;

        public AjustesViewModel()
        {
            //_navigationService = new NavigationService();
        }

        private Command _PaginaDispositivo;
        public Command PaginaDispositivo => 
            _PaginaDispositivo ?? (_PaginaDispositivo = new Command(async () => await ExecutePaginaDispositivo()));

        private async Task ExecutePaginaDispositivo() => await NavigationService.PushAsync(new DispositivoView());

        //private Command _PaginaSobre;
        //public Command PaginaSobrre =>
        //    _PaginaSobre ?? (_PaginaSobre = new Command(async () => await ExecutePaginaSobre()));

        //private async Task ExecutePaginaSobre() => await _navigationService.PushAsync(new SobreView());

        private Command _PaginaConexao;
        public Command PaginaConexao =>
            PaginaConexao ?? (_PaginaConexao = new Command(async () => await ExecutePaginaConexao()));

        private async Task ExecutePaginaConexao() => await NavigationService.PushAsync(new ConexaoView());

        private Command _PaginaExportarDados;
        public Command PaginaExportarDados =>
            PaginaExportarDados ?? (_PaginaExportarDados = new Command(async () => await ExecutePaginaExportarDados()));

        private async Task ExecutePaginaExportarDados() => await NavigationService.PushAsync(new ExportarDadosView());
    }
}
