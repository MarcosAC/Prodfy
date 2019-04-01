using Prodfy.Services;
using Prodfy.Services.Repository;
using Prodfy.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class FuncoesViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;

        private UserRepository userRepository;

        public FuncoesViewModel()
        {
            _navigationService = new NavigationService();

            userRepository = new UserRepository();
        }

        private bool CanExecuteCommand()
        {
            return LoginViewModel.estaLogado;
        }

        private Command _irPaginaIdentificacaoCommand;
        public Command IrPaginaIdentificacaoCommand =>
            _irPaginaIdentificacaoCommand ?? (_irPaginaIdentificacaoCommand = new Command(ExecuteIrPaginaIdentificacaoCommand, CanExecuteCommand));

        private async void ExecuteIrPaginaIdentificacaoCommand()
        {
            await _navigationService.PushAsync(new IdentificacaoView());
        }

        private Command _irPaginaAtividadeCommand;
        public Command IrPaginaAtividadeCommand =>
            _irPaginaAtividadeCommand ?? (_irPaginaAtividadeCommand = new Command(async () => await ExecuteIrPaginaAtividadeCommand(), CanExecuteCommand));

        private async Task ExecuteIrPaginaAtividadeCommand()
        {
            await _navigationService.PushAsync(new CadastroAtividadeView());
        }

        private Command _irPaginaInventarioCommand;
        public Command IrPaginaInventarioCommand =>
            _irPaginaInventarioCommand ?? (_irPaginaInventarioCommand = new Command(async () => await ExecuteIrPaginaInventarioCommand(), CanExecuteCommand));

        private async Task ExecuteIrPaginaInventarioCommand()
        {
            await _navigationService.PushAsync(new CadastroInventarioView());
        }

        private Command _irPaginaPerdasCommand;
        public Command IrPagianaPerdasCommand =>
            _irPaginaPerdasCommand ?? (_irPaginaPerdasCommand = new Command(async () => await ExecuteIrPaginaPerdasComand(), CanExecuteCommand));

        private async Task ExecuteIrPaginaPerdasComand()
        {
            await _navigationService.PushAsync(new CadastroPerdasView());
        }

        private Command _irPaginaHistoricoCommand;
        public Command IrPaginaHistoricoCommand =>
            _irPaginaHistoricoCommand ?? (_irPaginaHistoricoCommand = new Command(async () => await ExecuteIrPaginaHistoricoCommand(), CanExecuteCommand));

        private async Task ExecuteIrPaginaHistoricoCommand()
        {
            await _navigationService.PushAsync(new CadastroHistoricoView());
        }

        private Command _irPaginaLoteCommand;
        public Command IrPaginaLoteCommand =>
            _irPaginaLoteCommand ?? (_irPaginaLoteCommand = new Command(async () => await ExecuteIrPaginaLoteCommand(), CanExecuteCommand));

        private async Task ExecuteIrPaginaLoteCommand()
        {
            await _navigationService.PushAsync(new CadastroEvolucaoLoteView());
        }

        private Command _irPaginaExpedicaoCommand;
        public Command IrPaginaExpedicaoCommand =>
            _irPaginaExpedicaoCommand ?? (_irPaginaExpedicaoCommand = new Command(async () => await ExecuteIrPaginaExpedicaoCommand(), CanExecuteCommand));

        private async Task ExecuteIrPaginaExpedicaoCommand()
        {
            await _navigationService.PushAsync(new CadastroExpedicaoView());
        }

        private Command _irPaginaLocalizacaoCommand;
        public Command IrPaginaLocalizacaoCommand =>
            _irPaginaLocalizacaoCommand ?? (_irPaginaLocalizacaoCommand = new Command(async () => await ExecuteIrPaginaLocalizacaoCommand(), CanExecuteCommand));

        private async Task ExecuteIrPaginaLocalizacaoCommand()
        {
            await _navigationService.PushAsync(new LocalizacaoView());
        }

        private Command _irPaginaOcorrenciaCommand;
        public Command IrPaginaOcorrenciaCommand =>
            _irPaginaOcorrenciaCommand ?? (_irPaginaOcorrenciaCommand = new Command(async () => await ExecuteIrPaginaOcorrenciaCommand(), CanExecuteCommand));

        private async Task ExecuteIrPaginaOcorrenciaCommand()
        {
            await _navigationService.PushAsync(new CadastroOcorrencia());
        }

        private Command _irPaginaMedicaoCommand;
        public Command IrPaginaMedicaoCommand =>
            _irPaginaMedicaoCommand ?? (_irPaginaMedicaoCommand = new Command(async () => await ExecuteIrPaginaMedicaoCommand(), CanExecuteCommand));

        private async Task ExecuteIrPaginaMedicaoCommand()
        {
            await _navigationService.PushAsync(new CadastroMedicaoView());
        }

        private Command _refreshCommand;
        public Command RefreshCommand => _refreshCommand ?? (_refreshCommand = new Command(RefresCommandExecute));

        private void RefresCommandExecute()
        {
            IrPaginaIdentificacaoCommand.ChangeCanExecute();
            IrPaginaAtividadeCommand.ChangeCanExecute();
            IrPaginaInventarioCommand.ChangeCanExecute();
            IrPagianaPerdasCommand.ChangeCanExecute();
            IrPaginaHistoricoCommand.ChangeCanExecute();
            IrPaginaLoteCommand.ChangeCanExecute();
            IrPaginaExpedicaoCommand.ChangeCanExecute();
            IrPaginaLocalizacaoCommand.ChangeCanExecute();
            IrPaginaOcorrenciaCommand.ChangeCanExecute();
            IrPaginaMedicaoCommand.ChangeCanExecute();
        }
    }
}
