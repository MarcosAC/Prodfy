using Prodfy.Models;
using Prodfy.Services;
using Prodfy.Services.API;
using Prodfy.Services.Dialog;
using Prodfy.Services.Repository;
using Prodfy.Utils;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class DispositivoViewModel : BaseViewModel
    {
        private readonly INavigationService _navigationService;
        private readonly IDialogService _dialogService;

        private UserRepository _userRepository;
        private User _dadosUsuario = null;

        public DispositivoViewModel()
        {
            Title = "Dispositivo";

            _navigationService = new NavigationService();

            _dialogService = new DialogService();

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
            if (VerificaConexaoInternet.VerificaConexao())
            {
                bool configuracaoAceita = await _dialogService.AlertAsync("Dispositivo", 
                                                                          "Ao configurar o dispositivo todos os dados não sincronizados serão descartados. Confirma?", 
                                                                          "Sim", "Não");
                if (configuracaoAceita)
                {                    
                    _userRepository.DeletarTodasTabelas();

                    /*
                     *  ToDo - Refatarar leitor de QR
                     *  Criar uma variável que recebe os dados 
                     *  lidos da classe de leitor de QR.
                     */                    

                    var scanner = new ZXing.Mobile.MobileBarcodeScanner();
                    var result = await scanner.Scan();

                    if (result != null)
                    {
                        string[] resultadoQR = result.Text.Split('|');

                        var dadosQR = new
                        {
                            appKey = resultadoQR[0],
                            idioma = resultadoQR[2]
                        };

                        scanner.Cancel(); //=> Faz parte do scanner de QR.

                        /**********************************************************/

                        try
                        {
                            IsBusy = true;

                            await Task.Delay(3000);

                            _dadosUsuario = ConfiguracaoDispositivoService.ObterDadosConfiguracaoDispositivo(dadosQR.appKey, dadosQR.idioma);

                            _userRepository.Adicionar(_dadosUsuario);

                            _dadosUsuario = new User
                            {
                                idUser = _dadosUsuario.idUser,
                                disp_num = _dadosUsuario.disp_num,
                                nome = _dadosUsuario.nome,
                                empresa = _dadosUsuario.empresa
                            };

                            OnPropertyChanged(nameof(NumeroDispositivo));
                            OnPropertyChanged(nameof(Usuario));
                            OnPropertyChanged(nameof(Empresa));

                            IsBusy = false;                            

                            await _dialogService.AlertAsync("Sincronizar", "Sincronização realizada com sucesso!", "Ok");
                        }
                        catch (Exception)
                        {
                            await _dialogService.AlertAsync("Sincronizar", "Erro ao sincronizar!", "Ok");
                        }                       
                    }
                }                
            }
            else
            {
                await _dialogService.AlertAsync("Erro", "Sem conexão com a internet!", "Ok");
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
                var dadosDispositivo = _userRepository.ObterDados();

                if (dadosDispositivo != null)
                {
                    _dadosUsuario = new User
                    {
                        disp_num = dadosDispositivo.disp_num,
                        nome = dadosDispositivo.nome,
                        empresa = dadosDispositivo.empresa
                    };

                    OnPropertyChanged(nameof(NumeroDispositivo));
                    OnPropertyChanged(nameof(Usuario));
                    OnPropertyChanged(nameof(Empresa));
                }
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}