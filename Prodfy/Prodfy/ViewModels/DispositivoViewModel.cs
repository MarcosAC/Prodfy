using Prodfy.Models;
using Prodfy.Services.API;
using Prodfy.Services.Dialog;
using Prodfy.Services.Navigation;
using Prodfy.Services.Repository;
using Prodfy.Utils;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class DispositivoViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
        private readonly IDialogService dialogService;
        private readonly ConfiguracaoDispositivoService configuracaoDispositivoService;

        private UserRepository userRepository;
        private User _dadosUsuario = null;

        public DispositivoViewModel()
        {
            Title = "Dispositivo";

            navigationService = new NavigationService();
            dialogService = new DialogService();
            configuracaoDispositivoService = new ConfiguracaoDispositivoService();
            userRepository = new UserRepository();            
        }

        public int? NumeroDispositivo { get => _dadosUsuario?.disp_num; }
        public string Usuario { get => _dadosUsuario?.nome; }
        public string Empresa { get => _dadosUsuario?.empresa; }

        private Command _navegacaoCommand;
        public Command NavegacaoCommand => _navegacaoCommand ?? (_navegacaoCommand = new Command(async () => await ExecuteNavegacaoCommand()));

        private async Task ExecuteNavegacaoCommand() => await navigationService.PopAsync();

        private Command _leitorQRCommand;
        public Command LeitorQRCommand => _leitorQRCommand ?? (_leitorQRCommand = new Command(async () => await ExecuteLeitorQRCommand()));

        // ToDo refatorar função.
        private async Task ExecuteLeitorQRCommand()
        {
            if (VerificaConexaoInternet.VerificaConexao())
            {
                bool configuracaoAceita = await dialogService.AlertAsync
                                               ("Dispositivo", 
                                                "Ao configurar o dispositivo todos os dados não sincronizados serão descartados. Confirma?", 
                                                "Sim", "Não");
                if (configuracaoAceita)
                {                    
                    userRepository.DeletarTodasTabelas();

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
                            qrKey = resultadoQR[0],
                            qrLang = resultadoQR[2]
                        };

                        scanner.Cancel(); //=> Faz parte do scanner de QR.

                        /**********************************************************/

                        try
                        {
                            IsBusy = true;

                            var dadosConfiguracaoDispositivo = await configuracaoDispositivoService.ObterDadosConfiguracaoDispositivo(dadosQR.qrKey, dadosQR.qrLang);

                            var usuario = new User
                            {
                                disp_id = dadosConfiguracaoDispositivo.disp_id,
                                disp_num = dadosConfiguracaoDispositivo.disp_num,
                                senha = dadosConfiguracaoDispositivo.senha,
                                nome = dadosConfiguracaoDispositivo.nome,
                                sobrenome = dadosConfiguracaoDispositivo.sobrenome,
                                empresa = dadosConfiguracaoDispositivo.empresa,
                                autosinc = dadosConfiguracaoDispositivo.autosinc,
                                autosinc_time = dadosConfiguracaoDispositivo.autosinc_time,
                                sinc_url = dadosConfiguracaoDispositivo.sinc_url,
                                app_key = dadosConfiguracaoDispositivo.app_key,
                                lang = dadosConfiguracaoDispositivo.lang,
                                ind_ident = dadosConfiguracaoDispositivo.ind_ident,
                                ind_mov = dadosConfiguracaoDispositivo.ind_mov,
                                ind_per = dadosConfiguracaoDispositivo.ind_per,
                                ind_hist = dadosConfiguracaoDispositivo.ind_hist,
                                ind_mnt = dadosConfiguracaoDispositivo.ind_mnt,
                                ind_exp = dadosConfiguracaoDispositivo.ind_exp,
                                ind_atv = dadosConfiguracaoDispositivo.ind_atv,
                                uso_liberado = dadosConfiguracaoDispositivo.uso_liberado
                            };

                            if (usuario != null)
                            {
                                userRepository.Adicionar(usuario);

                                OnPropertyChanged(nameof(NumeroDispositivo));
                                OnPropertyChanged(nameof(Usuario));
                                OnPropertyChanged(nameof(Empresa));

                                await dialogService.AlertAsync("Configuração", "Configuração básica recebida com sucesso!", "Ok");
                            }

                            IsBusy = false;

                            return;
                        }
                        catch (Exception)
                        {
                            await dialogService.AlertAsync("Configuração", "Erro ao configurar!", "Ok");
                        }                       
                    }
                }                
            }
            else
            {
                await dialogService.AlertAsync("Erro", "Sem conexão com a internet!", "Ok");
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
                var dadosDispositivo = userRepository.ObterDados();

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