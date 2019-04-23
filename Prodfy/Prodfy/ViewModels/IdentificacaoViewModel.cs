﻿using Prodfy.Services;
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
        private readonly ProdutoRepository produtoRepositorio;

        public IdentificacaoViewModel()
        {
            navigationService = new NavigationService();
            dialogService = new DialogService();

            loteRepositorio = new LoteRepository();
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

                    /* Nova Versão
                     * qrLivre = resultadoQR[8],
                     * qrTipoEtiqueta = resultadoQR[9]
                     */
                };
                //string ret = $"{dadosQR}";

                ObterInformacoesLote(dadosQR.qrLoteCod);

                IsBusy = false;

                /* Nova Versão
                   if (qrTipoEtiqueta == null || qrTipoEtiqueta != 1)
                   {
                       await dialogService.AlertAsync("Etiqueta QR", "Etiqueta incompatível! Gere uma nova etiqueta QR!", "Ok");
                       return;
                   }
                */
            }
        }

        private void CapturarCoordenadasGPS()
        {
            var request = new GeolocationRequest(GeolocationAccuracy.High);
            var localizacao = Geolocation.GetLocationAsync(request);
        }  
        
        private async void ObterInformacoesLote(string dadosQR)
        {
            var temp = loteRepositorio.ObterDados(dadosQR);
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
    }
}