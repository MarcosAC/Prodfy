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

        public string DispNum { get => dadosLogin?.disp_num; }
        public string Nome { get => dadosLogin?.nome; }

        private Command _loginCommand;
        public Command LoginCommand =>
            _loginCommand ?? (_loginCommand = new Command(async () => await ExecuteLoginCommand()));

        private Task ExecuteLoginCommand()
        {
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
                        nome = dadosUsuario.nome
                    };

                    OnPropertyChanged(nameof(DispNum));
                    OnPropertyChanged(nameof(Nome));
                }
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}
