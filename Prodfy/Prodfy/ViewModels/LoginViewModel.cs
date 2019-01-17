using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _dispositivoId;
        public string DispositivoId
        {
            get => _dispositivoId;
            set => SetProperty(ref _dispositivoId, value);
        }

        private string _usuario;
        public string Usuario
        {
            get => _usuario;
            set => SetProperty(ref _usuario, value);
        }    

        private Command _loginCommand;
        public Command LoginCommand =>
            _loginCommand ?? (_loginCommand = new Command(async () => await ExecuteLoginCommand()));

        private Task ExecuteLoginCommand()
        {
            throw new NotImplementedException();
        }
    }
}
