using Prodfy.Models;
using Prodfy.Services.Navigation;
using Prodfy.Services.Repository;
using Prodfy.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class FuncoesViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;

        private User user;

        #region Repositórios
        private UserRepository userRepository;
        private LoteRepository loteRepository;
        private MonitoramentoRepository monitoramentoRepository;
        private MonitCodArvRepository monitCodArvRepositorio;
        #endregion

        public FuncoesViewModel()
        {
            _navigationService = new NavigationService();

            user = new User();

            userRepository = new UserRepository();
            loteRepository = new LoteRepository();
            monitoramentoRepository = new MonitoramentoRepository();
            monitCodArvRepositorio = new MonitCodArvRepository();            
        }

        private bool CanExecuteCommand()
        {
            var dataUltimoSincronismo = userRepository.ObterDados();

            if (LoginViewModel.estaLogado && dataUltimoSincronismo.dth_last_sincr != null)
            {
                if (loteRepository.ObterTotalDeRegistros() > 0 ||
                    monitoramentoRepository.ObterTotalDeRegistros() > 0 ||
                    monitCodArvRepositorio.ObterTotalDeRegistros() > 0)
                {
                    user = userRepository.ObterDados();
                    return true;
                }
            }

            return false;
        }

        #region Habilitar Botões Funções

        private bool CanExecuteFuncaoIdentificacaoCommand()
        {
            if (CanExecuteCommand())                
                if (user.ind_ident == 1)
                    return true;

            return false;
        }

        private bool CanExecuteFuncaoEstoqueViveiroCommand()
        {
            if (CanExecuteCommand())
                if (user.ind_atv == 1)
                    return true;

            return false;
        }

        private bool CanExecuteFuncaoAtividadeCommand()
        {            
            if (CanExecuteCommand())
                if (user.ind_atv == 1)
                    return true;

            return false;
        }

        private bool CanExecuteFuncaoInventarioCommand()
        {
            if (CanExecuteCommand())
                if (user.ind_inv == 1)
                    return true;

            return false;
        }

        private bool CanExecuteFuncaoMovimentacaoCommand()
        {
            if (CanExecuteCommand())
                if (user.ind_inv == 1)
                    return true;

            return false;
        }

        private bool CanExecuteFuncaoPerdasCommand()
        {
            if (CanExecuteCommand())
                if (user.ind_per == 1)
                    return true;

            return false;
        }

        private bool CanExecuteFuncaoHistoricoCommand()
        {
            if (CanExecuteCommand())
                if (user.ind_hist == 1)
                    return true;

            return false;
        }        

        private bool CanExecuteFuncaoExpedicaoCommand()
        {
            if (CanExecuteCommand())
                if (user.ind_exp == 1)
                    return true;

            return false;
        }

        //Monitoramento

        private bool CanExecuteFuncaoLocalizacaoCommand()
        {
            if (CanExecuteCommand())
                if (user.ind_mnt == 1)
                    return true;

            return false;
        }

        private bool CanExecuteFuncaoOcorrenciaCommand()
        {
            if (CanExecuteCommand())
                if (user.ind_mnt == 1)
                    return true;

            return false;
        }

        private bool CanExecuteFuncaoMedicaoCommand()
        {
            if (CanExecuteCommand())
                return true;

            return false;
        }

        #endregion

        private Command _irPaginaIdentificacaoCommand;
        public Command IrPaginaIdentificacaoCommand =>
            _irPaginaIdentificacaoCommand ?? (_irPaginaIdentificacaoCommand = new Command(async () => 
                await ExecuteIrPaginaIdentificacaoCommand(), CanExecuteFuncaoIdentificacaoCommand));

        private async Task ExecuteIrPaginaIdentificacaoCommand()
        {
            await _navigationService.PushAsync(new IdentificacaoView());
        }

        private Command _irPaginaAtividadeCommand;
        public Command IrPaginaAtividadeCommand =>
            _irPaginaAtividadeCommand ?? (_irPaginaAtividadeCommand = new Command(async () => 
                await ExecuteIrPaginaAtividadeCommand(), CanExecuteFuncaoAtividadeCommand));

        private async Task ExecuteIrPaginaAtividadeCommand()
        {
            await _navigationService.PushAsync(new AtividadeRealizadaView());
        }

        private Command _irPaginaInventarioCommand;
        public Command IrPaginaInventarioCommand =>
            _irPaginaInventarioCommand ?? (_irPaginaInventarioCommand = new Command(async () => 
                await ExecuteIrPaginaInventarioCommand(), CanExecuteFuncaoInventarioCommand));

        private async Task ExecuteIrPaginaInventarioCommand()
        {
            await _navigationService.PushAsync(new CadastroInventarioView());
        }

        private Command _irPaginaPerdasCommand;
        public Command IrPagianaPerdasCommand =>
            _irPaginaPerdasCommand ?? (_irPaginaPerdasCommand = new Command(async () => 
                await ExecuteIrPaginaPerdasComand(), CanExecuteFuncaoPerdasCommand));

        private async Task ExecuteIrPaginaPerdasComand()
        {
            await _navigationService.PushAsync(new PerdasView());
        }

        private Command _irPaginaHistoricoCommand;
        public Command IrPaginaHistoricoCommand =>
            _irPaginaHistoricoCommand ?? (_irPaginaHistoricoCommand = new Command(async () => 
                await ExecuteIrPaginaHistoricoCommand(), CanExecuteFuncaoHistoricoCommand));

        private async Task ExecuteIrPaginaHistoricoCommand()
        {
            await _navigationService.PushAsync(new HistoricoView());
        }

        private Command _irPaginaLoteCommand;
        public Command IrPaginaLoteCommand =>
            _irPaginaLoteCommand ?? (_irPaginaLoteCommand = new Command(async () => 
                await ExecuteIrPaginaLoteCommand(), CanExecuteFuncaoMovimentacaoCommand));

        private async Task ExecuteIrPaginaLoteCommand()
        {
            await _navigationService.PushAsync(new CadastroEvolucaoLoteView());
        }

        private Command _irPaginaExpedicaoCommand;
        public Command IrPaginaExpedicaoCommand =>
            _irPaginaExpedicaoCommand ?? (_irPaginaExpedicaoCommand = new Command(async () => 
                await ExecuteIrPaginaExpedicaoCommand(), CanExecuteFuncaoExpedicaoCommand));

        private async Task ExecuteIrPaginaExpedicaoCommand()
        {
            await _navigationService.PushAsync(new CadastroExpedicaoView());
        }

        private Command _irPaginaLocalizacaoCommand;
        public Command IrPaginaLocalizacaoCommand =>
            _irPaginaLocalizacaoCommand ?? (_irPaginaLocalizacaoCommand = new Command(async () => 
                await ExecuteIrPaginaLocalizacaoCommand(), CanExecuteFuncaoLocalizacaoCommand));

        private async Task ExecuteIrPaginaLocalizacaoCommand()
        {
            await _navigationService.PushAsync(new LocalizacaoView());
        }

        private Command _irPaginaOcorrenciaCommand;
        public Command IrPaginaOcorrenciaCommand =>
            _irPaginaOcorrenciaCommand ?? (_irPaginaOcorrenciaCommand = new Command(async () => 
                await ExecuteIrPaginaOcorrenciaCommand(), CanExecuteFuncaoOcorrenciaCommand));

        private async Task ExecuteIrPaginaOcorrenciaCommand()
        {
            await _navigationService.PushAsync(new CadastroOcorrenciaView());
        }

        private Command _irPaginaMedicaoCommand;
        public Command IrPaginaMedicaoCommand =>
            _irPaginaMedicaoCommand ?? (_irPaginaMedicaoCommand = new Command(async () => 
                await ExecuteIrPaginaMedicaoCommand(), CanExecuteFuncaoMedicaoCommand));

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
