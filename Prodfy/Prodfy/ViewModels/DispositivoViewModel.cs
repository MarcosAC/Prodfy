﻿using Prodfy.Models;
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
        private User _dadosUsuario = null;

        public DispositivoViewModel()
        {
            Title = "Dispositivo";

            _navigationService = new NavigationService();

            _userRepository = new UserRepository();
        }
                
        public string NumeroDispositivo { get => _dadosUsuario?.disp_num; }
        public string Usuario { get => _dadosUsuario?.nome; }
        public string Empresa { get => _dadosUsuario?.empresa; }

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
                _dadosUsuario = ConfiguracaoDispositivoService.DadosConfiguracaoDispositivo(dados.appKey, dados.idioma);

                _userRepository.Adicionar(_dadosUsuario);

                _dadosUsuario = new User
                {
                    disp_num = _dadosUsuario.disp_num,
                    nome = _dadosUsuario.nome,
                    empresa = _dadosUsuario.empresa
                };

                OnPropertyChanged(nameof(NumeroDispositivo));
                OnPropertyChanged(nameof(Usuario));
                OnPropertyChanged(nameof(Empresa));
            }
        }
    }
}