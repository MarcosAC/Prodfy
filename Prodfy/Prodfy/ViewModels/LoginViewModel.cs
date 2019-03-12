using Prodfy.Models;
using Prodfy.Services.Dialog;
using Prodfy.Services.Repository;
using Prodfy.Utils;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly UserRepository userRepository;
        private readonly IDialogService dialogService;

        private User dadosLogin = null;

        readonly bool estaLogado = Login.UsuarioEstaLogado();

        public LoginViewModel()
        {
            userRepository = new UserRepository();

            dialogService = new DialogService();
        }

        private bool _logado;
        public bool Logado { get => _logado = estaLogado; }

        private string _senha;
        public string Senha
        {
            get => _senha;
            set => SetProperty(ref _senha, value);
        }

        public string DispNum { get => dadosLogin?.disp_num; }
        public string Nome { get => dadosLogin?.nome; }
        public string Empresa { get => dadosLogin?.empresa; }

        private bool VerificarUsuarioLogado()
        {
            if (estaLogado)
            {
                switch (dadosLogin?.senha != null)
                {
                    case true:
                        if (Senha == dadosLogin?.senha)
                            return true;
                        break;

                    case false:
                        // if (estaLogado)
                        return estaLogado;
                }
            }
            return false;
        }

        private Command _loginCommand;
        public Command LoginCommand =>
            _loginCommand ?? (_loginCommand = new Command(() => ExecuteLoginCommand()));
        
        private async void ExecuteLoginCommand()
        {
            //await RefreshCommandExecute();

            if (Senha != null)
            {
                if (dadosLogin?.senha == Senha)
                    await RefreshCommandExecute();
            }
            else
            {
                await dialogService.AlertAsync("Login", "Senha inválida!", "Ok");
            }
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
                        empresa = dadosUsuario.empresa,
                        senha = dadosUsuario.senha                        
                    };

                    OnPropertyChanged(nameof(DispNum));
                    OnPropertyChanged(nameof(Nome));
                    OnPropertyChanged(nameof(Senha));
                }

                if (estaLogado)
                {
                    OnPropertyChanged(nameof(Empresa));
                    OnPropertyChanged(nameof(Senha));
                    OnPropertyChanged(nameof(Logado));
                }
            }
            catch (Exception ex)
            {
                Debug.Write("Erro -> ", ex.ToString());
            }
        }
    }
}
