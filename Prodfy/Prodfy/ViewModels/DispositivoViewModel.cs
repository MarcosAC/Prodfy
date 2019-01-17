using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class DispositivoViewModel : BaseViewModel
    {
        public DispositivoViewModel()
        {
            Title = "Dispositivo";
        }

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

        private string _empresa;
        public string Empresa
        {
            get => _empresa;
            set => SetProperty(ref _empresa, value);
        }

        private Command _lerCodigoQRCommand;
        public Command LerCodigoQRCommand =>
            _lerCodigoQRCommand ?? (_lerCodigoQRCommand = new Command(async () => await ExecuteLerCodigoQRCommand()));

        private Task ExecuteLerCodigoQRCommand()
        {
            throw new NotImplementedException();
        }
    }
}
