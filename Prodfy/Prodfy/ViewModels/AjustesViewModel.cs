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

        private Command _irPaginaDispositivo;
        public Command IrPaginaDispositivo => 
            _irPaginaDispositivo ?? (_irPaginaDispositivo = new Command(async () => await ExecuteIrPaginaDispositivoCommand()));

        private async Task ExecuteIrPaginaDispositivoCommand() => await NavigationService.PushAsync(new DispositivoView());

        //private Command _PaginaSobre;
        //public Command PaginaSobrre =>
        //    _PaginaSobre ?? (_PaginaSobre = new Command(async () => await ExecutePaginaSobre()));

        //private async Task ExecutePaginaSobre() => await _navigationService.PushAsync(new SobreView());

        private Command _irPaginaConexao;
        public Command IrPaginaConexao =>
            _irPaginaConexao ?? (_irPaginaConexao = new Command(async () => await ExecuteIrPaginaConexaoCommand()));

        private async Task ExecuteIrPaginaConexaoCommand() => await NavigationService.PushAsync(new ConexaoView());

        private Command _irPaginaExportarDados;
        public Command IrPaginaExportarDados =>
            _irPaginaExportarDados ?? (_irPaginaExportarDados = new Command(async () => await ExecuteIrPaginaExportarDadosCommand()));

        private async Task ExecuteIrPaginaExportarDadosCommand() => await NavigationService.PushAsync(new ExportarDadosView());
    }
}
