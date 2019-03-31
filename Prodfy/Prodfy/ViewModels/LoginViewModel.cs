using Prodfy.Models;
using Prodfy.Services.Dialog;
using Prodfy.Services.Repository;
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
        public static bool estaLogado = false;

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

        private Command _loginCommand;
        public Command LoginCommand =>
            _loginCommand ?? (_loginCommand = new Command(() => ExecuteLoginCommand()));
        
        private async void ExecuteLoginCommand()
        {
            if (Senha != null)
            {
                var dadosUsuario = userRepository.ObterDados();

                if (dadosUsuario?.senha == Senha)
                {
                    estaLogado = true;

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

                        OnPropertyChanged(nameof(Empresa));
                        OnPropertyChanged(nameof(Logado));
                    }                    
                }
                else
                {
                    await dialogService.AlertAsync("Login", "Senha inválida!", "Ok");
                }   
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
                    };

                    OnPropertyChanged(nameof(DispNum));
                    OnPropertyChanged(nameof(Nome));                   

                    if (estaLogado == false)
                    {
                        if (dadosUsuario?.senha == Senha)
                        {
                            estaLogado = true;

                            OnPropertyChanged(nameof(Empresa));
                            OnPropertyChanged(nameof(Logado));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.Write("Erro -> ", ex.ToString());
            }            
        }
    }
}
