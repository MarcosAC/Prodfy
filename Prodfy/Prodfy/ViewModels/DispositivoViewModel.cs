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

        private Command _leitorQRCommand;
        public Command LeitorQRCommand => _leitorQRCommand ?? (_leitorQRCommand = new Command(async () => await ExecuteLeitorQRCommand()));

        private async Task ExecuteLeitorQRCommand()
        {
            var scanner = new ZXing.Mobile.MobileBarcodeScanner();
            var result = await scanner.Scan();

            if (result != null)
            {
                await App.Current.MainPage.DisplayAlert("Valor", $"Leitura do codigo: {result.Text}", "OK");
            }
        }
    }
}
