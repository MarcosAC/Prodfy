using Prodfy.Services.Repository;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class FuncoesViewModel : BaseViewModel
    {
        private UserRepository userRepository;       

        public FuncoesViewModel()
        {
            userRepository = new UserRepository();

            //HabilitarBotoesCommand = new Command();
        }

        private bool VerificarUsuarioLogado()
        {
            var dadosUser = userRepository.ObterDados();

            if (dadosUser?.senha != null)
                if (dadosUser?.senha == dadosUser?.senha)
                    return true;

            return false;
        }

        private bool CanExecuteCommand()
        {
            return VerificarUsuarioLogado() == true;
        }

        private bool _logado;
        public bool Logado
        {
            get { return _logado; }
            set { SetProperty(ref _logado, value); HabilitarBotoesCommand.ChangeCanExecute(); }
        }

        public Command HabilitarBotoesCommand { get; }

        private Command _irPaginaIdentificacaoCommand;
        public Command IrPaginaIdentificacaoCommand =>
            _irPaginaIdentificacaoCommand ?? (_irPaginaIdentificacaoCommand = new Command(async () => await ExecuteIrPaginaIdentificacaoCommand()));

        private Task ExecuteIrPaginaIdentificacaoCommand()
        {
            throw new NotImplementedException();
        }

        private Command _irPaginaAtividadeCommand;
        public Command IrPaginaAtividadeCommand =>
            _irPaginaAtividadeCommand ?? (_irPaginaAtividadeCommand = new Command(async () => await ExecuteIrPaginaAtividadeCommand()));

        private Task ExecuteIrPaginaAtividadeCommand()
        {
            throw new NotImplementedException();
        }

        private Command _irPaginaInventarioCommand;
        public Command IrPaginaInventarioCommand =>
            _irPaginaInventarioCommand ?? (_irPaginaInventarioCommand = new Command(async () => await ExecuteIrPaginaInventarioCommand()));

        private Task ExecuteIrPaginaInventarioCommand()
        {
            throw new NotImplementedException();
        }

        private Command _irPaginaPerdasCommand;
        public Command IrPagianaPerdasCommand =>
            _irPaginaPerdasCommand ?? (_irPaginaPerdasCommand = new Command(async () => await ExecuteIrPaginaPerdasComand()));

        private Task ExecuteIrPaginaPerdasComand()
        {
            throw new NotImplementedException();
        }

        private Command _irPaginaHistoricoCommand;
        public Command IrPaginaHistoricoCommand =>
            _irPaginaHistoricoCommand ?? (_irPaginaHistoricoCommand = new Command(async () => await ExecuteIrPaginaHistoricoCommand()));

        private Task ExecuteIrPaginaHistoricoCommand()
        {
            throw new NotImplementedException();
        }

        private Command _irPaginaLoteCommand;
        public Command IrPaginaLoteCommand =>
            _irPaginaLoteCommand ?? (_irPaginaLoteCommand = new Command(async () => await ExecuteIrPaginaLoteCommand()));

        private Task ExecuteIrPaginaLoteCommand()
        {
            throw new NotImplementedException();
        }

        private Command _irPaginaExpedicaoCommand;
        public Command IrPaginaExpedicaoCommand =>
            _irPaginaExpedicaoCommand ?? (_irPaginaExpedicaoCommand = new Command(async () => await ExecuteIrPaginaExpedicaoCommand()));

        private Task ExecuteIrPaginaExpedicaoCommand()
        {
            throw new NotImplementedException();
        }

        private Command _irPaginaLocalizacaoCommand;
        public Command IrPaginaLocalizacaoCommand =>
            _irPaginaLocalizacaoCommand ?? (_irPaginaLocalizacaoCommand = new Command(async () => await ExecuteIrPaginaLocalizacaoCommand()));

        private Task ExecuteIrPaginaLocalizacaoCommand()
        {
            throw new NotImplementedException();
        }

        private Command _irPaginaOcorrenciaCommand;
        public Command IrPaginaOcorrenciaCommand =>
            _irPaginaOcorrenciaCommand ?? (_irPaginaOcorrenciaCommand = new Command(async () => await ExecuteIrPaginaOcorrenciaCommand()));

        private Task ExecuteIrPaginaOcorrenciaCommand()
        {
            throw new NotImplementedException();
        }

        private Command _irPaginaMedicaoCommand;
        public Command IrPaginaMedicaoCommand =>
            _irPaginaMedicaoCommand ?? (_irPaginaMedicaoCommand = new Command(async () => await ExecuteIrPaginaMedicaoCommand()));

        private Task ExecuteIrPaginaMedicaoCommand()
        {
            throw new NotImplementedException();
        }
    }
}
