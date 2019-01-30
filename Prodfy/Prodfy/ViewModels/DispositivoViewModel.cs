using Prodfy.Helpers;
using Prodfy.Models;
using Prodfy.Services;
using Prodfy.Services.API;
using Prodfy.Services.Repository;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class DispositivoViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private UserRepository _userRepository;

        public DispositivoViewModel()
        {
            Title = "Dispositivo";

            _navigationService = new NavigationService();

            _userRepository = new UserRepository();
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

        private Command _navegacaoCommand;
        public Command NavegacaoCommand => _navegacaoCommand ?? (_navegacaoCommand = new Command(async () => await ExecuteNavegacaoCommand()));

        private async Task ExecuteNavegacaoCommand() => await _navigationService.PopAsync();

        private Command _leitorQRCommand;
        public Command LeitorQRCommand => _leitorQRCommand ?? (_leitorQRCommand = new Command(async () => await ExecuteLeitorQRCommand()));

        private async Task ExecuteLeitorQRCommand()
        {
            var scanner = new ZXing.Mobile.MobileBarcodeScanner();
            var result = await scanner.Scan();

            string[] dadosQR = result.Text.Split('|');

            var dados = new
            {
                appKey = dadosQR[0],
                idioma = dadosQR[2]
            };

            if (result != null)
            {
                var dadosUsuario = ConfiguracaoDispositivoService.DadosConfiguracaoDispositivo(dados.appKey, dados.idioma);

                _userRepository.Adicionar(dadosUsuario);
            }
        }
    }
}