using Prodfy.Models;
using Prodfy.Services;
using Prodfy.Services.Dialog;
using Prodfy.Services.Repository;
using Prodfy.Views;
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

        #region Variáveis ObterInformacoesLote/QtdeEstaq/Localizacao
        private string stat;
        private string msg;
        private int infoLoteId;
        private string infoLoteCodigo;
        private string infoLoteObejetivo;
        private string infoLoteCliente;
        private string infoLoteProduto;

        //QtdeEstaq
        private double contadorQuantidade;
        private string estaqueamento = string.Empty;

        //Localizacao
        private string locais = string.Empty;
        #endregion

        private string _conteudoHtml;
        public string ConteudoHtml
        {
            get => _conteudoHtml;
            set => SetProperty(ref _conteudoHtml, value);
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

                #region Código de geração de html antigo
                /* try
                 {
                     infoLoteId = Convert.ToInt32(ObterInformacoesLote(dadosQR.qrLoteCod));
                     //await ObterInformacoesMuda(Convert.ToInt32(dadosQR.qrMudaId));

                     #region Gera Lista de Locais onde existe Lote/Muda/Estaq
                     // Refatorar código
                     List<Estaq> dadosEstaqueamento = await ListaDatasEstaqueamentoColaborador(infoLoteId, Convert.ToInt32(dadosQR.qrMudaId), Convert.ToDateTime(dadosQR.qrDataEstaq));

                     #region Lista Colaboradores Responsaveis Por Estaqueamento de Lote/Muda/Estaq
                     for (int i = 0; i < dadosEstaqueamento.Count; i++)
                     {
                         //List<Estaq> listaEstaqueamento = new List<Estaq>();                       

                         if (dadosEstaqueamento[i].qtde != null)
                         {
                             contadorQuantidade = contadorQuantidade + Convert.ToDouble(dadosEstaqueamento[i].qtde);
                             estaqueamento = $"<li>{dadosEstaqueamento[i].colab_estaq} - <b style='color:#ff7b00;'>{dadosEstaqueamento[i].qtde}</b><li>";
                         }
                     }
                     #endregion

                     List<Ponto_Controle> dadosLocalPontoControle = await ListaLocalPontoControle(infoLoteId, Convert.ToInt32(dadosQR.qrMudaId), Convert.ToDateTime(dadosQR.qrDataEstaq));

                     List<Ponto_Controle> listaLocalPontoControle = new List<Ponto_Controle>();

                     for (int i = 0; i < dadosLocalPontoControle.Count; i++)
                     {
                         string listaPontoControleEstagio = string.Empty;
                         string pontoControleEstagioQuantidade = string.Empty;

                         string titulo = listaLocalPontoControle[i].titulo;

                         locais = $"<li>{titulo}: {listaPontoControleEstagio}</li>";

                         List<Estagio> listaLocalEstagio = await estagioRepository.ListaLocalEstagio(listaLocalPontoControle[i].ponto_controle_id, infoLoteId, Convert.ToInt32(dadosQR.qrMudaId), Convert.ToDateTime(dadosQR.qrDataEstaq));

                         for (int j = 0; j < listaLocalEstagio.Count; j++)
                         {
                             pontoControleEstagioQuantidade = await estagioRepository.LocalQuantidadeMudasNoEstagio(listaLocalPontoControle[i].ponto_controle_id, infoLoteId, Convert.ToInt32(dadosQR.qrMudaId), Convert.ToDateTime(dadosQR.qrDataEstaq));
                             listaPontoControleEstagio = $"<li>{listaLocalEstagio[j].titulo}: <b style='color:#ff7b00;'>{pontoControleEstagioQuantidade}</b></li>";
                         }

                         if (string.IsNullOrEmpty(pontoControleEstagioQuantidade) && string.IsNullOrEmpty(listaPontoControleEstagio))
                             locais = $"<li>{titulo}: <ul style='list-style-image: url((BASE64_IMG_SRC_LISTDOT_ESTAGIO));'>{listaPontoControleEstagio}</ul></li>";
                     }
                     #endregion

                     PaginaHtmlIdentificao(await ObterInformacoesMuda(Convert.ToInt32(dadosQR.qrMudaId)), dadosEstaqueamento, await ObterInformacoesLote(dadosQR.qrLoteCod));

                     await dialogService.AlertAsync("DEBUG", "Idetificação funciou :D", "Ok");
                 }
                 catch (Exception ex)
                 {

                     await dialogService.AlertAsync("DEBUG", "ERRO => "+ ex.ToString(), "Ok");
                 }*/
                #endregion

                #region Lote
                var temp = loteRepositorio.ObterInformacoesParaIdentificacao(dadosQR.qrLoteCod);
                var infoLote = temp.Split('|');

                if (infoLote[0] == "0")
                {
                    await dialogService.AlertAsync("Etiqueta QR", "Lote indicado no QR inexistente! Sincronize o dispositivo.", "Ok");
                }

                var informacoesLote = new
                {
                    stat = infoLote[0],
                    msg = infoLote[1],
                    infoLoteId = Convert.ToInt32(infoLote[2]),
                    infoLoteCodigo = infoLote[3],
                    infoLoteObejetivo = infoLote[4],
                    infoLoteCliente = infoLote[5],
                    infoLoteProduto = infoLote[6],
                };

                #endregion

                IsBusy = false;

                await navigationService.PushAsync(new PaginaHtmlIdentificacaoView());
            }
        }        

        private void CapturarCoordenadasGPS()
        {
            var request = new GeolocationRequest(GeolocationAccuracy.High);
            var localizacao = Geolocation.GetLocationAsync(request);
        }

        private async Task<string> ObterInformacoesLote(string loteCod)
        {
            var temp = loteRepositorio.ObterInformacoesParaIdentificacao(loteCod);
            var infoLote = temp.Split('|');

            if (infoLote[0] == "0")
            {
                await dialogService.AlertAsync("Etiqueta QR", "Lote indicado no QR inexistente! Sincronize o dispositivo.", "Ok");
            }

            var informacoesLote = new
            {
                stat = infoLote[0],
                msg = infoLote[1],
                infoLoteId = Convert.ToInt32(infoLote[2]),
                infoLoteCodigo = infoLote[3],
                infoLoteObejetivo = infoLote[4],
                infoLoteCliente = infoLote[5],
                infoLoteProduto = infoLote[6],
            };

            return informacoesLote.ToString();
        }

        private async Task<List<string>> ObterInformacoesMuda(int mudaId)
        {            
            var temp = mudaRepository.ObterInformacoesParaIdentificacao(mudaId);
            var infoMuda = temp.Split('|');

            List<string> listaMuda = new List<string>();

            listaMuda = infoMuda.ToList<string>();

            if (infoMuda[0] == "0")
            {
                await dialogService.AlertAsync("Etiqueta QR", "Muda indicada no QR inexistente! Sincronize o dispositivo.", "Ok");
            }

            return listaMuda;

            //var info_muda_id = infoMuda[2];
            //var info_muda_nome_interno = infoMuda[3];
            //var info_muda_nome = infoMuda[4];
            //var info_muda_especie = infoMuda[5];
            //var info_muda_origem = infoMuda[8];
            //var info_muda_viveiro = infoMuda[9];
            //var info_muda_canaletao = infoMuda[10];
            //var info_muda_linha = infoMuda[11];
            //var info_muda_coluna = infoMuda[12];
            //var info_muda_qtde = infoMuda[13];
        }  
        
        private async Task<List<Estaq>> ListaDatasEstaqueamentoColaborador(int infoLoteId, int mudaId, DateTime dataEstaq)
        {
            var listaEstaqueamento = await estaqRepository.ListaDadosEstaqueamento(infoLoteId, mudaId, dataEstaq);

            return listaEstaqueamento;
        }

        private async Task<List<Ponto_Controle>> ListaLocalPontoControle(int infoLoteId, int mudaId, DateTime dataEstaq)
        {
            List<Ponto_Controle> listaLocalPontoControle = await pontoControleRepository.ListaDadosPontoControle(infoLoteId, mudaId, dataEstaq);

            return listaLocalPontoControle;
        }

        private async Task<List<Estagio>> ListaLocalEstagio(int pontoControleId, int loteId, int mudaId, DateTime dataEstaq)
        {
            List<Estagio> listaLocalEstagio = await estagioRepository.ListaLocalEstagio(pontoControleId, infoLoteId, mudaId, dataEstaq);            

            return listaLocalEstagio;
        }

        private string PaginaHtmlIdentificao(List<string> infoMuda, List<Estaq> quantidadeEstaqueamento, string infoLote)
        {            
            //string codigoHtml = string.Empty;

            var stat = infoLote[0].ToString();
            var msg = infoLote[1];

            if (stat == "1")
            {
                var lote = infoLote[3].ToString();
                var produto = infoLote[6].ToString();
                var objetivo = infoLote[4];
                var cliente = infoLote[5];

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

                #region Planta
                string planta = $"<b>{info_muda_nome_interno}";

                if (!string.IsNullOrEmpty(info_muda_especie))
                    planta = planta + " - <small><i>{info_muda_especie}</li></small></b>";
                else
                    planta += " - <small><i>{info_muda_nome}</i></small></b>";

                string local = $"Linha: {info_muda_linha}, Coluna: {info_muda_coluna}, Qtde: {info_muda_qtde}";

                if (!string.IsNullOrEmpty(planta))
                {
                    //Origem
                    planta = planta + "<br/><b>Origem:</b> ";
                    if (!string.IsNullOrEmpty(info_muda_origem))
                        planta += $"<small>{info_muda_origem}</small>";
                    else
                        planta += $"<small><i style='color:#ff0000;'>Indefinido!</i></small>";

                    //Viveiro
                    planta = "<br/><b>Viiro:</b> ";
                    if (!string.IsNullOrEmpty(info_muda_viveiro))
                        planta += $"<small>{info_muda_viveiro}</small>";
                    else
                        planta += "<small><i style='color:#ff0000;'>Indefinido!</i></small>";

                    //Caneletao
                    planta = "<br/><b>Caneletão:</b> ";
                    if (!string.IsNullOrEmpty(info_muda_canaletao))
                        planta += $"<small>{info_muda_canaletao}</small>";
                    else
                        planta += "<small><i style='color:#ff0000;'>Indefinido!</i></small>";

                    //Local
                    planta += "<br/><b>Local:</b> <small>";
                    planta += "Linha: ";
                    if (!string.IsNullOrEmpty(info_muda_coluna))
                        planta += $"<small>{info_muda_coluna}</small>";
                    else
                        planta += "<small><i style='color:#ff0000;'>Indefinido!</i></small>";

                    planta = ", Coluna: ";
                    if (!string.IsNullOrEmpty(info_muda_coluna))
                        planta += $"<small>{info_muda_coluna}</small>";
                    else
                        planta += "<small><i style='color:#ff0000;'>Indefinido!</i></small>";

                    planta = "<br/><b>Caneletão:</b> ";
                    if (!string.IsNullOrEmpty(info_muda_canaletao))
                        planta += $"<small>{info_muda_canaletao}</small>";
                    else
                        planta += "<small><i style='color:#ff0000;'>Indefinido!</i></small>";
                }
                #endregion

                #region Lote
                string loteTxt = lote;

                if (string.IsNullOrEmpty(produto))
                {
                    loteTxt += $" (<small>{produto}</small>)";
                }
                #endregion

                #region QtdeEstaq
                string qtdeEstaq = Convert.ToString(contadorQuantidade);

                List<Estaq> listaEstaqueamento = new List<Estaq>();

                for (int i = 0; i < quantidadeEstaqueamento.Count; i++)
                {
                    listaEstaqueamento[i].qtde = quantidadeEstaqueamento[i].qtde;
                    listaEstaqueamento[i].data_estaq = quantidadeEstaqueamento[i].data_estaq;
                }

                string estaqs = string.Empty;

                if (!string.IsNullOrEmpty(estaqueamento))
                    estaqs = $"<div class='font-size-70'><ul style='list-style-image: url(BASE64_IMG_SRC_LISTDOT2);';>(oESTAQS!)</ul></div>";

                /*codigoHtml*/ ConteudoHtml= "<html><head><title>Prodfy APP</title></head>";
                /*codigoHtml*/ ConteudoHtml+= "body { background-color: transparent; font-family: Helvetica; font-size: 60px; margin:10px 0; padding:0; text-align:center; margin-left: 15px; margin-right: 15px; margin-top: 15px; }";
                /*codigoHtml*/ ConteudoHtml+= ".info-table { width: 100%; } .info-table th { width: 60px; font-size: 60px; text-align: left; vertical-align: top; padding: 10px; color:black; white-space: nowrap; } .info-table td { width: 400px; font-size: 60px; text-align: left; vertical-align: top; padding: 10px; color:#0000ff; }";
                /*codigoHtml*/ ConteudoHtml+= ".font-size-70 { font-size: 70%; }";
                /*codigoHtml*/ ConteudoHtml+= "</style><body><center>";
                /*codigoHtml*/ ConteudoHtml+= "<table class='info-table'>";
                /*codigoHtml*/ ConteudoHtml+= $"<tr><th><b>Planta:</b></th></tr><tr><td><small>{planta}</small></td></tr>";
                /*codigoHtml*/ ConteudoHtml+= $"<tr><th><br/><b>Lote:</b></th></tr><tr><td>{loteTxt}</td></tr>";
                /*codigoHtml*/ ConteudoHtml+= $"<tr><th><br/><b>Objetivo:</b></th></tr><tr><td><small>{objetivo}</small></td></tr>";
                /*codigoHtml*/ ConteudoHtml+= $"<tr><th><br/><b>Cliente:</b></th></tr><tr><td><small>{cliente}</small></td></tr>";
                /*codigoHtml*/ ConteudoHtml+= $"<tr><th><br/><b>Estaqueamento:</b></th></tr><tr><td>{quantidadeEstaqueamento[0].data_estaq} - <b style='color:#ff7b00;'>{quantidadeEstaqueamento[0].qtde}</b> ((idade_estaq) Dias)</td></tr>";
                /*codigoHtml*/ ConteudoHtml += $"<tr><th><br/><b>Colaboradores:</b></th></tr><tr><td>{estaqs}</td></tr>";
                #endregion

                #region Localizacao
                string localTxt = string.Empty;

                if (!string.IsNullOrEmpty(locais))
                    localTxt += $"<ul style='font-size:70%; list-style-image: url((BASE64_IMG_SRC_LISTDOT_PONTO_CONTROLE));'>{localTxt}</ul>";

                string cap = string.Empty;

                if (string.IsNullOrEmpty(estaqs))
                    cap = "<br/>";

                ConteudoHtml += $"<tr><th>{cap}<b>Localização:</b></th></tr><tr><td>{localTxt}</td></tr>";
                ConteudoHtml += "</table><br/><br/></center></body></html>";

                #endregion
            }
            else
            {
                ConteudoHtml = "<html>" +
                                "<head>" +
                                    $"<title>Prodfy APP</title>" +
                                "</head>" +
                                    "<style type='text/css'>" +
                                        "body " +
                                            "{ background-color: transparent;" +
                                              "font-family: Helvetica;" +
                                              "font-size: 60px;" +
                                              "margin:10px 0;" +
                                              " padding:0;" +
                                              "text-align:center;" +
                                            "}" +
                                        ".info-table { width: 100%; }" +
                                        ".info-table th { width: 60px;" +
                                                         "font-size: 60px;" +
                                                         "text-align: right;" +
                                                         "vertical-align: top;" +
                                                         "padding: 10px;" +
                                                         "color:black;" +
                                                         "white-space: nowrap;" +
                                                       "}"+
                                        ".info-table td { width: 400px;" +
                                                         "font-size: 60px;" +
                                                         "text-align: left;" +
                                                         "vertical-align: top;" +
                                                         "padding: 10px;" +
                                                         "color:#0000ff;" +
                                                       "}" +
                                        ".colab_list { font-size: 70%; }" +
                                    "</style>" +
                                "<body>" +
                                    $"<center><h3 style='color: red;'>{msg}</h3></center>" +
                                "</body>" +
                             "</html>";
            }
            return ConteudoHtml;
        }
    }
}