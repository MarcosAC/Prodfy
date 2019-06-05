using Prodfy.Models;
using Prodfy.Services;
using Prodfy.Services.Dialog;
using Prodfy.Services.Repository;
using Prodfy.Utils;
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
            Title = "Identificação";

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
                    infoLoteObjetivo = infoLote[4],
                    infoLoteCliente = infoLote[5],
                    infoLoteProduto = infoLote[6],
                };

                #endregion

                #region Muda
                var temp2 = mudaRepository.ObterInformacoesParaIdentificacao(Convert.ToInt32(dadosQR.qrMudaId));
                var infoMuda = temp2.Split('|');

                List<string> listaMuda = new List<string>();

                listaMuda = infoMuda.ToList<string>();

                if (infoMuda[0] == "0")
                {
                    await dialogService.AlertAsync("Etiqueta QR", "Muda indicada no QR inexistente! Sincronize o dispositivo.", "Ok");
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
                #endregion

                #region Obtem Lista de Datas de Estaqueamento com colaborador e qualidade
                string lote = string.Empty;
                string muda = string.Empty;
                string dataEstqueamento = string.Empty;
                string quantidade = string.Empty;
                string qualidade = string.Empty;
                string colaboradorEstaqueamento = string.Empty;
                string estaqueamentos = string.Empty;
                double contadorQuantidade;

                contadorQuantidade = 0;

                // Lista Colaboradores Responsaveis Por Estaqueamento de Lote/Muda/Estaq
                var listaEstaqueamento = await estaqRepository.ListaDadosEstaqueamento(informacoesLote.infoLoteId, Convert.ToInt32(dadosQR.qrMudaId), Convert.ToDateTime(dadosQR.qrDataEstaq));

                foreach (var item in listaEstaqueamento)
                {
                    if (item.qtde != null)
                    {
                        contadorQuantidade = contadorQuantidade + Convert.ToDouble(item.qtde);
                        estaqueamentos += $"<li>{item.colab_estaq} - <b style='color:#ff7b00;'>{item.qtde}</b></li>";
                    }
                }
                #endregion

                #region Lista Colaboradores Responsaveis Por Estaqueamento de Lote/Muda/Estaq
                string locais = string.Empty;
                string listaPontoControle = string.Empty;
                string listaPontoControleEstaqueamento = string.Empty;
                string quantidadePontoControleEstaqueamento = string.Empty;

                List<Ponto_Controle> listaLocalPontoControle = await pontoControleRepository.ListaDadosPontoControle(informacoesLote.infoLoteId, Convert.ToInt32(dadosQR.qrMudaId), Convert.ToDateTime(dadosQR.qrDataEstaq));

                foreach (var pontoControle in listaLocalPontoControle)
                {
                    locais += $"{pontoControle.titulo}";

                    // Lista Estagios do Ponto de Controle onde existe Lote/Muda/Estaq
                    List<Estagio> listaLocalEstagio = await estagioRepository.ListaLocalEstagio(pontoControle.ponto_controle_id, informacoesLote.infoLoteId, Convert.ToInt32(dadosQR.qrMudaId), Convert.ToDateTime(dadosQR.qrDataEstaq));

                    foreach (var pontoControleEstaqueamento in listaLocalEstagio)
                    {
                        quantidadePontoControleEstaqueamento = await estagioRepository.LocalQuantidadeMudasNoEstagio(pontoControle.ponto_controle_id, informacoesLote.infoLoteId, Convert.ToInt32(dadosQR.qrMudaId), Convert.ToDateTime(dadosQR.qrDataEstaq));
                        listaPontoControleEstaqueamento += $"<li>{pontoControleEstaqueamento.titulo}: <b style='color:#ff7b00;'>{quantidadePontoControleEstaqueamento}</b></li>";
                    }

                    if (!string.IsNullOrEmpty(listaPontoControleEstaqueamento))
                        locais += $"<ul style='list-style-image: url((BASE64_IMG_SRC_LISTDOT_ESTAGIO));'>{listaPontoControleEstaqueamento}</ul>";

                    locais += "</li>";
                }
                #endregion

                #region Pagina HTML
                string codigoHtml = string.Empty;

                if (informacoesLote.stat == "1")
                {
                    #region Planta
                    string plantaHtml = $"<b>{info_muda_nome_interno}";

                    if (!string.IsNullOrEmpty(info_muda_especie))
                        plantaHtml += $" - <small><i>{info_muda_especie}</i></small>";
                    else if (!string.IsNullOrEmpty(info_muda_especie))
                        plantaHtml += $" - <small><i>{info_muda_nome}</i></small>";

                    plantaHtml += "</b><br/>";

                    string origem = $"{infoMuda[8]}";
                    string viveiro = $"{infoMuda[9]}";
                    string canaletao = $"{infoMuda[10]}";
                    string linha = $"{infoMuda[11]}";
                    string coluna = $"{infoMuda[12]}";
                    string qtde = $"{infoMuda[13]}";
                    string local = $"Linha: {linha}, Coluna: {coluna}, Qtde: {qtde}";

                    if (!string.IsNullOrEmpty(plantaHtml))
                    {
                        //Origem
                        plantaHtml += "<br/><b>Origem:</b> ";
                        if (!string.IsNullOrEmpty(info_muda_origem))
                            plantaHtml += $"<small>{info_muda_origem}</small>";
                        else
                            plantaHtml += $"<small><i style='color:#ff0000;'>Indefinido!</i></small>";

                        //Viveiro
                        plantaHtml += "<br/><b>Viveiro:</b> ";
                        if (!string.IsNullOrEmpty(info_muda_viveiro))
                            plantaHtml += $"<small>{info_muda_viveiro}</small>";
                        else
                            plantaHtml += "<small><i style='color:#ff0000;'>Indefinido!</i></small>";

                        //Caneletao
                        plantaHtml += "<br/><b>Caneletão:</b> ";
                        if (!string.IsNullOrEmpty(info_muda_canaletao))
                            plantaHtml += $"<small>{info_muda_canaletao}</small>";
                        else
                            plantaHtml += "<small><i style='color:#ff0000;'>Indefinido!</i></small>";

                        //Local
                        plantaHtml += "<br/><b>Local:</b> <small>";
                        plantaHtml += "Linha: ";
                        if (!string.IsNullOrEmpty(info_muda_coluna))
                            plantaHtml += $"<small>{info_muda_coluna}</small>";
                        else
                            plantaHtml += "<small><i style='color:#ff0000;'>Indefinido!</i></small>";

                        plantaHtml += ", Coluna: ";
                        if (!string.IsNullOrEmpty(info_muda_coluna))
                            plantaHtml += $"<small>{info_muda_coluna}</small>";
                        else
                            plantaHtml += "<small><i style='color:#ff0000;'>Indefinido!</i></small>";

                        plantaHtml += ", Qtde: ";
                        if (!string.IsNullOrEmpty(info_muda_qtde))
                            plantaHtml += $"{info_muda_qtde}";
                        else
                            plantaHtml += "<small><i style='color:#ff0000;'>Indefinido!</i></small>";

                        plantaHtml += "</small>";
                    }
                    #endregion

                    #region Lote
                    string loteHtml = informacoesLote.infoLoteCodigo;

                    if (!string.IsNullOrEmpty(informacoesLote.infoLoteProduto))
                        loteHtml += $" (<small>{informacoesLote.infoLoteProduto}</small>)";
                    #endregion

                    #region Quantida de Estaqueamento
                    string quantidadeEstaquamento = Convert.ToString(contadorQuantidade);

                    string estaqs = string.Empty;

                    if (!string.IsNullOrEmpty(estaqueamentos))
                        estaqs = $"<div class='font-size-70'><ul style='list-style-image: url((BASE64_IMG_SRC_LISTDOT2));';>{estaqueamentos}</ul></div>";
                    #endregion                    

                    codigoHtml = "<html><head><title>Prodfy APP</title></head>";
                    codigoHtml += "<style type='text/css'>";
                    codigoHtml += "body { background-color: transparent; font-family: Helvetica; font-size: 18px; margin:10px 0; padding:0; text-align:center; margin-left: 15px; margin-right: 15px; margin-top: 15px; }";
                    codigoHtml += ".info-table { width: 100%; } .info-table th { width: 60px; font-size: 18px; text-align: left; vertical-align: top; padding: 10px; color:black; white-space: nowrap; } .info-table td { width: 400px; font-size: 18px; text-align: left; vertical-align: top; padding: 10px; color:#0000ff; }";
                    codigoHtml += ".font-size-70 { font-size: 70%; }";
                    codigoHtml += "</style><body><center>";
                    codigoHtml += "<table class='info-table'>";
                    codigoHtml += $"<tr><th><b>Planta:</b></th></tr><tr><td><small>{plantaHtml}</small></td></tr>";
                    codigoHtml += $"<tr><th><br/><b>Lote:</b></th></tr><tr><td>{loteHtml}</td></tr>";
                    codigoHtml += $"<tr><th><br/><b>Objetivo:</b></th></tr><tr><td><small>{informacoesLote.infoLoteObjetivo}</small></td></tr>";
                    codigoHtml += $"<tr><th><br/><b>Cliente:</b></th></tr><tr><td><small>{informacoesLote.infoLoteCliente}</small></td></tr>";
                    codigoHtml += $"<tr><th><br/><b>Estaqueamento:</b></th></tr><tr><td>{Convert.ToDateTime(dadosQR.qrDataEstaq).ToShortDateString()} - <b style='color:#ff7b00;'>{quantidadeEstaquamento}</b> ({CalculaIdade.CalcularPorDataIniciaDataFinal(Convert.ToDateTime(dadosQR.qrDataEstaq), DateTime.Now)} Dias)</td></tr>";
                    codigoHtml += $"<tr><th><br/><b>Colaboradores:</b></th></tr><tr><td>{estaqs}</td></tr>";
                    codigoHtml += "</style><body><center>";

                    #region Localização
                    string localHtml = string.Empty;

                    if (!string.IsNullOrEmpty(locais))
                        localHtml += locais;
                    #endregion

                    string cap = string.Empty;

                    if (string.IsNullOrEmpty(estaqs))
                        cap = "<br/>";

                    codigoHtml += $"<tr><th>{cap}<b>Localização:</b></th></tr><tr><td>{localHtml}</td></tr>";
                    codigoHtml += "</table><br/><br/></center></body></html>";
                }
                else
                {
                    codigoHtml = "<html>" +
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
                                                       "}" +
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
                                    $"<center><h3 style='color: red;'>{informacoesLote.msg}</h3></center>" +
                                "</body>" +
                             "</html>";
                }
                #endregion

                IsBusy = false;

                await navigationService.PushAsync(new PaginaHtmlIdentificacaoView(codigoHtml));
            }
        }

        private Command _testePopUp;
        public Command TestePopUp => _testePopUp ?? (_testePopUp = new Command(async () => await ExecuteTestePopUpCommand()));

        private async Task ExecuteTestePopUpCommand()
        {
            await navigationService.PushAsync(new Teste());
        }

        private void CapturarCoordenadasGPS()
        {
            var request = new GeolocationRequest(GeolocationAccuracy.High);
            var localizacao = Geolocation.GetLocationAsync(request);
        }
    }
}