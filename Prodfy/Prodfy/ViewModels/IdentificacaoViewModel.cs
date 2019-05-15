using Prodfy.Models;
using Prodfy.Services;
using Prodfy.Services.Dialog;
using Prodfy.Services.Repository;
using System;
using System.Collections.Generic;
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
        private readonly EstaqRepository estaqRepository;
        private readonly PontoControleRepository pontoControleRepository;
        private readonly EstagioRepository estagioRepository;

        public IdentificacaoViewModel()
        {
            navigationService = new NavigationService();
            dialogService = new DialogService();

            loteRepositorio = new LoteRepository();
            mudaRepository = new MudaRepository();
            produtoRepositorio = new ProdutoRepository();
            estaqRepository = new EstaqRepository();
            pontoControleRepository = new PontoControleRepository();
            estagioRepository = new EstagioRepository();

            CapturarCoordenadasGPS();
        }

        #region Variáveis do método ObterInformacoesLote
        private string stat;
        private string msg;
        private int infoLoteId;
        private string infoLoteCodigo;
        private string infoLoteObejetivo;
        private string infoLoteCliente;
        private string infoLoteProduto;
        #endregion

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

                if (resultadoQR.Count() < 10)
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
                    qrColaboradorId = resultadoQR[7],
                    qrLivre = resultadoQR[8],
                    qrTipoEtiqueta = resultadoQR[9]
                };

                if (dadosQR.qrTipoEtiqueta == null || dadosQR.qrTipoEtiqueta != "1")
                {
                    await dialogService.AlertAsync("Etiqueta QR", "Etiqueta incompatível! Gere uma nova etiqueta QR!", "Ok");
                    return;
                }

                try
                {
                    ObterInformacoesLote(dadosQR.qrLoteCod);
                    ObterInformacoesMuda(Convert.ToInt32(dadosQR.qrMudaId));
                    ListaDatasEstaqueamentoColaborador(infoLoteId, Convert.ToInt32(dadosQR.qrMudaId), Convert.ToDateTime(dadosQR.qrDataEstaq));

                    var listaPontoControle = await ListaLocalPontoControle(infoLoteId, Convert.ToInt32(dadosQR.qrMudaId), Convert.ToDateTime(dadosQR.qrDataEstaq));

                    //for (int i = 0; i < listaPontoControle.Count; i++)
                    //{
                    //    string locais = $"<li>{listaPontoControle[i]}:";
                    //}

                    await dialogService.AlertAsync("DEBUG", "Idetificação funciou :D", "Ok");
                }
                catch (Exception ex)
                {

                    await dialogService.AlertAsync("DEBUG", "ERRO => "+ ex.ToString(), "Ok");
                }
                

                IsBusy = false;
            }
        }        

        private void CapturarCoordenadasGPS()
        {
            var request = new GeolocationRequest(GeolocationAccuracy.High);
            var localizacao = Geolocation.GetLocationAsync(request);
        }        

        private async void ObterInformacoesLote(string loteCod)
        {
            var temp = loteRepositorio.ObterInformacoesParaIdentificacao(loteCod);
            var infoLote = temp.Split('|');

            if (infoLote[0] == "0")
            {
                await dialogService.AlertAsync("Etiqueta QR", "Lote indicado no QR inexistente! Sincronize o dispositivo.", "Ok");
                return;
            }

            stat = infoLote[0];
            msg = infoLote[1];
            infoLoteId = Convert.ToInt32(infoLote[2]);
            infoLoteCodigo = infoLote[3];
            infoLoteObejetivo = infoLote[4];
            infoLoteCliente = infoLote[5];
            infoLoteProduto = infoLote[6];
        }

        private async void ObterInformacoesMuda(int mudaId)
        {            
            var temp = mudaRepository.ObterInformacoesParaIdentificacao(mudaId);
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
        
        private void ListaDatasEstaqueamentoColaborador(int infoLoteId, int mudaId, DateTime dataEstaq)
        {
            var listaEstaqueamento = estaqRepository.ListaDadosEstaqueamento(infoLoteId, mudaId, dataEstaq);
        }

        private async Task<List<Ponto_Controle>> ListaLocalPontoControle(int infoLoteId, int mudaId, DateTime dataEstaq)
        {
            List<Ponto_Controle> listaLocalPontoControle = await pontoControleRepository.ListaDadosPontoControle(infoLoteId, mudaId, dataEstaq);

            return listaLocalPontoControle;
        }

        private async Task<List<Estagio>> ListaLocalEstagio(int pontoControleId, int loteId, int mudaId, DateTime dataEstaq)
        {
            List<Estagio> ListaLocalEstagio = await estagioRepository.ListaLocalEstagio(pontoControleId, infoLoteId, mudaId, dataEstaq);

            return ListaLocalEstagio;
        }
    }
}