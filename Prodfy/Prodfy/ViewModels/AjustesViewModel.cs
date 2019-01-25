using Prodfy.Services;
using Prodfy.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class AjustesViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;

        public AjustesViewModel()
        {
            _navigationService = new NavigationService();
        }

        private Command _irPaginaDispositivo;
        public Command IrPaginaDispositivo => 
            _irPaginaDispositivo ?? (_irPaginaDispositivo = new Command(async () => await ExecuteIrPaginaDispositivoCommand()));

        private async Task ExecuteIrPaginaDispositivoCommand() => await _navigationService.PushAsync(new DispositivoView());

        private Command _irPaginaSobre;
        public Command IrPaginaSobre =>
            _irPaginaSobre ?? (_irPaginaSobre = new Command(async () => await ExecutePaginaSobre()));

        private async Task ExecutePaginaSobre() => await _navigationService.PushAsync(new SobreView());

        private Command _irPaginaConexao;
        public Command IrPaginaConexao =>
            _irPaginaConexao ?? (_irPaginaConexao = new Command(async () => await ExecuteIrPaginaConexaoCommand()));

        private async Task ExecuteIrPaginaConexaoCommand() => await _navigationService.PushAsync(new ConexaoView());

        private Command _irPaginaExportarDados;
        public Command IrPaginaExportarDados =>
            _irPaginaExportarDados ?? (_irPaginaExportarDados = new Command(async () => await ExecuteIrPaginaExportarDadosCommand()));

        private async Task ExecuteIrPaginaExportarDadosCommand() => await _navigationService.PushAsync(new ExportarDadosView());
    }
}
