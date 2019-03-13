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

        public LoginViewModel()
        {
            userRepository = new UserRepository();

            dialogService = new DialogService();

            //estaLogado = Login.UsuarioEstaLogado();
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
        public string Empresa { get => dadosLogin?.empresa; }        

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
                else
                    await dialogService.AlertAsync("Login", "Senha inválida!", "Ok");
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

                if (Senha != null)
                {
                    if (Senha == dadosLogin?.senha)
                    {
                        OnPropertyChanged(nameof(Empresa));
                        OnPropertyChanged(nameof(Senha));
                        OnPropertyChanged(nameof(Logado));
                    }
                }
                
                //if (Logado)
                //{
                //    OnPropertyChanged(nameof(Empresa));
                //    OnPropertyChanged(nameof(Senha));
                //    OnPropertyChanged(nameof(Logado));
                //}
            }
            catch (Exception ex)
            {
                Debug.Write("Erro -> ", ex.ToString());
            }
        }

        private bool VerificarUsuarioLogado()
        {
            bool estaLogado = Login.UsuarioEstaLogado();

            if (estaLogado)
            {
                //if (dadosLogin?.senha != null)
                //{
                    //if (senha != null)
                    //{
                    //    if (senha == dadoslogin?.senha)
                    //    {
                    //        return true;
                    //    }
                    //    else
                    //    {
                    //        return false;
                    //    }
                    //}
                    //else if (senha == dadoslogin?.senha)
                    //{
                    //    return false;
                    //}
                //}
                return estaLogado;                
            }
            return false;

            //switch (dadosLogin?.senha != null)
            //{
            //    case true:
            //        if (Senha == dadosLogin?.senha)
            //            // quando carrega pagina novamente da falso pois a senha não foi digitada.
            //            return true;
            //        break;

            //    case false:
            //        // if (estaLogado)
            //        return true;
            //}
        }
    }
}
