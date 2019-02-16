using Prodfy.Models;
using Prodfy.Services.Repository;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly UserRepository userRepository;

        private User dadosLogin = null;                

        public LoginViewModel()
        {
            userRepository = new UserRepository();
        }

        private bool _logado;
        public bool Logado { get => _logado = VerificarUsuarioLogado(); }

        private string _senha;
        public string Senha
        {
            get => _senha;
            set => SetProperty(ref _senha, value);
        }

        public string DispNum { get => dadosLogin?.disp_num; }
        public string Nome { get => dadosLogin?.nome; }
        public string Empresa { get => dadosLogin?.nome; }

        private bool VerificarUsuarioLogado()
        {
            if (dadosLogin?.senha != null)
                if (Senha == dadosLogin?.senha)
                    return true;

            return false;              
        }

        private Command _loginCommand;
        public Command LoginCommand =>
            _loginCommand ?? (_loginCommand = new Command(async () => await ExecuteLoginCommand()));
        
        private Task ExecuteLoginCommand()
        {
            // ToDo Botão Login //
            throw new NotImplementedException();
        }

        private Command _RefreshCommand;
        public Command RefreshCommand => _RefreshCommand ?? (_RefreshCommand = new Command(async () => await RefreshCommandExecute()));

        private async Task RefreshCommandExecute()
        {
            await Task.FromResult<object>(null);

            RefreshCommand.ChangeCanExecute();

            try
            {
                var dadosUsuario = userRepository.ObterDados();

                if (dadosUsuario != null)
                {
                    dadosLogin = new User
                    {
                        disp_num = dadosUsuario.disp_num,
                        nome = dadosUsuario.nome,
                        senha = dadosLogin.senha
                    };

                    OnPropertyChanged(nameof(DispNum));
                    OnPropertyChanged(nameof(Nome));
                    OnPropertyChanged(nameof(Empresa));
                    OnPropertyChanged(nameof(Senha));                    
                }

                VerificarUsuarioLogado();
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
