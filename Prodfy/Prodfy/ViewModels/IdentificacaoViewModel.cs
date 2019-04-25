using Prodfy.Services;
using Prodfy.Services.Dialog;
using Prodfy.Services.Repository;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class IdentificacaoViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
        private readonly IDialogService dialogService;

        private readonly LoteRepository loteRepositorio;
        private readonly MudaRepository mudaRepository;
        private readonly ProdutoRepository produtoRepositorio;

        public IdentificacaoViewModel()
        {
            navigationService = new NavigationService();
            dialogService = new DialogService();

            loteRepositorio = new LoteRepository();
            mudaRepository = new MudaRepository();
            produtoRepositorio = new ProdutoRepository();

            CapturarCoordenadasGPS();
        }

        private Command _titleViewBotaoVoltarCommand;
        public Command TitleViewBotaoVoltarCommand => 
            _titleViewBotaoVoltarCommand ?? (_titleViewBotaoVoltarCommand = new Command(async () => await ExecuteTitleViewBotaoVoltarCommand()));

        private async Task ExecuteTitleViewBotaoVoltarCommand() => await navigationService.PopAsync();

        private Command _leitorQRCommand;
        public Command LeitorQRCommand => _leitorQRCommand ?? (_leitorQRCommand = new Command(async () => await ExecuteLeitorQRCommand()));

        private async Task ExecuteLeitorQRCommand()
        {
            var scanner = new ZXing.Mobile.MobileBarcodeScanner();
            var result = await scanner.Scan();

            scanner.Cancel();

            if (result != null)
            {
                IsBusy = true;

                string[] resultadoQR = result.Text.Split('|');

                if (resultadoQR.Count() < 8)
                {
                    await dialogService.AlertAsync("Etiqueta QR", "Etiqueta incompatível! Gere uma nova etiqueta QR!", "Ok");

                    IsBusy = false;

                    return;
                }

                /*
                    A sequencia do QR novo é a seguinte: 
                    lote_codigo|muda_id|qtde|data_estaq|band_dens|ponto_controle_id|estagio_id|colab_id|livre|tipo_etiqueta|

                    A sequencia do QR em produção:
                    lote_codigo|muda_id|qtde|data_estaq|band_dens|ponto_controle_id|estagio_id|colab_id|  
                 */

                var dadosQR = new
                {
                    qrLoteCod = resultadoQR[0],
                    qrMudaId = resultadoQR[1],
                    qrQtd = resultadoQR[2],
                    qrDataEstaq = resultadoQR[3],
                    qrDensidade = resultadoQR[4],
                    qrPontoControle = resultadoQR[5],
                    qrEstagioId = resultadoQR[6],
                    qrColaboradorId = resultadoQR[7]

                    #region Nova Versão
                    /* Nova Versão
                     * qrLivre = resultadoQR[8],
                     * qrTipoEtiqueta = resultadoQR[9]
                     */
                    #endregion
                };

                #region Nova Versão
                //if (qrTipoEtiqueta == null || qrTipoEtiqueta != 1)
                //   {
                //       await dialogService.AlertAsync("Etiqueta QR", "Etiqueta incompatível! Gere uma nova etiqueta QR!", "Ok");
                //       return;
                //   }
                #endregion

                ObterInformacoesLote(dadosQR.qrLoteCod);
                ObterInformacoesMuda(dadosQR.qrMudaId);

                IsBusy = false;
            }
        }

        private void CapturarCoordenadasGPS()
        {
            var request = new GeolocationRequest(GeolocationAccuracy.High);
            var localizacao = Geolocation.GetLocationAsync(request);
        }  
        
        private async void ObterInformacoesLote(string dadosQR)
        {
            var temp = loteRepositorio.ObterInformacoesParaIdentificacao(dadosQR);
            var infoLote = temp.Split('|');

            if (infoLote[0] == "0")
            {
                await dialogService.AlertAsync("Etiqueta QR", "Lote indicado no QR inexistente! Sincronize o dispositivo.", "Ok");
                return;
            }

            var stat = infoLote[0];
            var msg = infoLote[1];
            var info_lote_id = infoLote[2];
            var info_lote_codigo = infoLote[3];
            var info_lote_objetivo = infoLote[4];
            var info_lote_cliente = infoLote[5];
            var info_lote_produto = infoLote[6];
        }

        private async void ObterInformacoesMuda(string dadosQR)
        {
            var temp = mudaRepository.ObterInformacoesParaIdentificacao(dadosQR);
            var infoMuda = temp.Split('|');

            if (infoMuda[0] == "0")
            {
                await dialogService.AlertAsync("Etiqueta QR", "Muda indicada no QR inexistente! Sincronize o dispositivo.", "Ok");
                return;
            }

            var info_muda_id = infoMuda[2];
            var info_muda_nome_interno = infoMuda[3];
            var info_muda_nome = infoMuda[4];
            var info_muda_especie = infoMuda[5];
            var info_muda_origem = infoMuda[8];
            var info_muda_viveiro = infoMuda[9];
            var info_muda_canaletao = infoMuda[10];
            var info_muda_linha = infoMuda[11];
            var info_muda_coluna = infoMuda[12];
            var info_muda_qtde = infoMuda[13];
        }
    }
}