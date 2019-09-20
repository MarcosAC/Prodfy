using Prodfy.Models;
using Prodfy.Services.Dialog;
using Prodfy.Services.Navigation;
using Prodfy.Services.Repository;
using Prodfy.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class PerdasViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
        private readonly IDialogService dialogService;

        private readonly PerdaRepository perdaRepositorio;
        private readonly LoteRepository loteRepositorio;
        private readonly MudaRepository mudaRepositorio;
        private readonly PontoControleRepository pontoControleRepositorio;
        private readonly EstagioRepository estagioRepositorio;

        public ObservableCollection<ListaPerdas> ListaDePerdas { get; }

        public PerdasViewModel()
        {
            Title = "Perdas";

            navigationService = new NavigationService();
            dialogService = new DialogService();

            perdaRepositorio = new PerdaRepository();
            loteRepositorio = new LoteRepository();
            mudaRepositorio = new MudaRepository();
            pontoControleRepositorio = new PontoControleRepository();
            estagioRepositorio = new EstagioRepository();

            ListaDePerdas = new ObservableCollection<ListaPerdas>(Perdas());
        }

        private string _filtro;
        public string Filtro
        {
            get { return _filtro; }
            set
            {
                SetProperty(ref _filtro, value);
                Perdas(_filtro);
            }
        }

        private Command _titleViewBotaoVoltarCommand;
        public Command TitleViewBotaoVoltarCommand =>
            _titleViewBotaoVoltarCommand ?? (_titleViewBotaoVoltarCommand = new Command(async () => await ExecuteTitleViewBotaoVoltarCommand()));

        private async Task ExecuteTitleViewBotaoVoltarCommand() => await navigationService.PopAsync();

        private Command _irParaCadastroPerdasCommand;
        public Command IrParaCadastroPerdasCommand =>
            _irParaCadastroPerdasCommand ?? (_irParaCadastroPerdasCommand = new Command(async () => await ExecuteIrParaCadastroPerdasCommand()));

        private async Task ExecuteIrParaCadastroPerdasCommand() => await navigationService.PushAsync(new CadastroPerdasView());

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

                string loteId = string.Empty;
                string loteCodigo = string.Empty;
                string loteProdutoId = string.Empty;
                string mudaId = string.Empty;
                string mudaNomeComum = string.Empty;
                string quantidade = string.Empty;
                string pontoControleId = string.Empty;
                string pontoControleCodigo = string.Empty;
                string pontoControleTitulo = string.Empty;
                string estagioId = string.Empty;
                string estagioCodigo = string.Empty;
                string estagioTitulo = string.Empty;

                string[] resultadoQR = result.Text.Split('|');

                if (resultadoQR.Count() < 8)
                {
                    await dialogService.AlertAsync("Etiqueta QR", "Etiqueta incompatível! Gere uma nova etiqueta QR!", "Ok");

                    IsBusy = false;
                }

                var dadosQR = new
                {
                    qrLoteCod = resultadoQR[0],
                    qrMudaId = resultadoQR[1],
                    qrQtd = resultadoQR[2],
                    qrDataEstaq = resultadoQR[3],
                    qrDensidade = resultadoQR[4],
                    qrPontoControleId = resultadoQR[5],
                    qrEstagioId = resultadoQR[6],
                    qrColaboradorId = resultadoQR[7],
                    qrLivre = resultadoQR[8],
                    qrTipoEtiqueta = resultadoQR[9]
                };

                #region Lote
                if (dadosQR.qrLoteCod != null)
                {
                    loteCodigo = dadosQR.qrLoteCod;
                    //Lote ID
                    string loteInfo = loteRepositorio.ObterLoteId(dadosQR.qrLoteCod);
                    var tmpLoteInfo = loteInfo.Split('|');

                    if (tmpLoteInfo[0] == "0")
                    {
                        await dialogService.AlertAsync("Etiqueta QR", "Lote indicado no QR inexistente! Sincronize o dispositivo.", "Ok");
                    }
                    loteId = tmpLoteInfo[2];


                    //Lote Produto ID
                    string loteProdutoInfo = loteRepositorio.ObterLoteProdutoId(dadosQR.qrLoteCod);
                    var tmpLoteprodutoInfo = loteProdutoInfo.Split('|');

                    if (tmpLoteprodutoInfo[0] == "0")
                    {
                        await dialogService.AlertAsync("Etiqueta QR", "Produto associado ao Lote indicado no QR inexistente! Sincronize o dispositivo.", "Ok");
                    }

                    loteProdutoId = tmpLoteInfo[2];
                }
                #endregion

                #region Muda
                if (dadosQR.qrMudaId != null)
                {
                    mudaId = dadosQR.qrMudaId;

                    //Muda Nome Comum
                    string mudaIndo = mudaRepositorio.ObterMudaInfo(dadosQR.qrMudaId);
                    var tmpMudainfo = mudaIndo.Split('|');

                    if (tmpMudainfo[0] == "0")
                    {
                        await dialogService.AlertAsync("Etiqueta QR", "Muda indicada no QR inexistente! Sincronize o dispositivo.", "Ok");
                    }

                    mudaNomeComum = tmpMudainfo[3];
                }
                #endregion

                #region Quantidade
                if (dadosQR.qrQtd != null)
                    quantidade = dadosQR.qrQtd;
                #endregion

                #region Ponto Controle
                if (resultadoQR.Count() >= 8)
                {
                    if (string.IsNullOrEmpty(dadosQR.qrPontoControleId))
                    {
                        pontoControleId = string.Empty;
                        pontoControleCodigo = string.Empty;
                        pontoControleTitulo = string.Empty;
                    }
                    else
                    {
                        pontoControleId = dadosQR.qrPontoControleId;

                        //Ponto Controle Info
                        string pontoControleInfo = pontoControleRepositorio.ObterMudaInfo(int.Parse(dadosQR.qrPontoControleId));
                        var tmpPontoControleInfo = pontoControleInfo.Split('|');

                        if (tmpPontoControleInfo[0] == "0")
                        {
                            pontoControleId = string.Empty;
                            pontoControleCodigo = string.Empty;
                            pontoControleTitulo = string.Empty;

                            await dialogService.AlertAsync("Etiqueta QR", "Ponto de Controle indicado não localizado!", "Ok");
                        }
                        else
                        {
                            pontoControleCodigo = tmpPontoControleInfo[4];
                            pontoControleTitulo = tmpPontoControleInfo[5];
                        }
                    }
                }
                #endregion

                #region Estagio
                if (!string.IsNullOrEmpty(pontoControleCodigo))
                {
                    if (dadosQR.qrEstagioId == null)
                    {
                        estagioId = string.Empty;
                        estagioCodigo = string.Empty;
                        estagioTitulo = string.Empty;
                    }
                    else
                    {
                        estagioId = dadosQR.qrEstagioId;

                        //Estagio Info
                        string estagioInfo = estagioRepositorio.ObterInformacoesParaIdentificacao(int.Parse(dadosQR.qrPontoControleId), int.Parse(dadosQR.qrEstagioId));
                        var tmpestagioInfo = estagioInfo.Split('|');

                        if (tmpestagioInfo[0] == "0")
                        {
                            estagioId = string.Empty;
                            estagioCodigo = string.Empty;
                            estagioTitulo = string.Empty;

                            await dialogService.AlertAsync("Etiqueta QR", "Estágio indicado não localizado!", "Ok");
                        }
                        else
                        {
                            estagioCodigo = tmpestagioInfo[5];
                            estagioTitulo = tmpestagioInfo[6];
                        }
                    }
                }
                #endregion

                if (!string.IsNullOrEmpty(loteId) &&
                    !string.IsNullOrEmpty(loteCodigo) &&
                    !string.IsNullOrEmpty(loteProdutoId) &&
                    !string.IsNullOrEmpty(mudaId) &&
                    !string.IsNullOrEmpty(mudaNomeComum) &&
                    !string.IsNullOrEmpty(quantidade))
                {
                    var carregarCadastroPerdasQr = new CarregarDadosPerdaQr
                    {
                        OloteId = loteId,
                        OloteCodigo = loteCodigo,
                        OloteProdutoId = loteProdutoId,
                        OmudaId = mudaId,
                        OmudaNomeComum = mudaNomeComum,
                        Oquantidade = quantidade,
                        OpontoControleId = pontoControleId,
                        OestagioId = estagioId
                    };
                    
                    await navigationService.PushAsync(new CadastroPerdasView(carregarCadastroPerdasQr));
                }
                else
                {
                    await dialogService.AlertAsync("Etiqueta QR", "Etiqueta incompatível! Gere uma nova etiqueta QR!", "Ok");
                }                

                if (dadosQR.qrTipoEtiqueta == null || dadosQR.qrTipoEtiqueta != "1")
                {
                    await dialogService.AlertAsync("ERRO", "Erro ao carregar dados", "Ok");
                }
            }
        }

        private Command _selecionarPerdaCommand;
        public Command SelecionarPerdaCommand =>
            _selecionarPerdaCommand ?? (_selecionarPerdaCommand = new Command<ListaPerdas>(async p => await ExecuteSelecionarPerdaCommand(p)));

        private async Task ExecuteSelecionarPerdaCommand(ListaPerdas perdaSelecionado)
        {
            if (perdaSelecionado == null)
                return;

            bool deleteAceite = await dialogService.AlertAsync($"LOTE {perdaSelecionado.codigo}", "Deseja apagar este registro ?", "Sim", "Não");

            if (deleteAceite)
            {
                try
                {
                    perdaRepositorio.Deletar(perdaSelecionado.idperda);
                    await RefreshCommandExecute();
                }
                catch (Exception)
                {
                    await dialogService.AlertAsync("", $"Erro ao deletar item {perdaSelecionado.idperda}", "Ok");
                }
            }
        }

        private Command _RefreshCommand;
        public Command RefreshCommand => _RefreshCommand ?? (_RefreshCommand = new Command(async () => await RefreshCommandExecute()));

        private async Task RefreshCommandExecute()
        {
            try
            {
                RefreshCommand.ChangeCanExecute();

                ListaDePerdas.Clear();

                foreach (var item in perdaRepositorio.ObterTodasPerdas())
                {
                    ListaDePerdas.Add(item);
                }
            }
            catch (Exception)
            {
                await dialogService.AlertAsync("Erro", "Erro ao listar Atividades", "Ok");
            }
            finally
            {
                RefreshCommand.ChangeCanExecute();
            }
        }

        private List<ListaPerdas> Perdas(string filtro = null)
        {
            if (filtro != null)
            {
                var listaDadosPerdas = perdaRepositorio.ListaDePerdas(filtro);

                ListaDePerdas.Clear();

                foreach (var item in listaDadosPerdas)
                {
                    ListaDePerdas.Add(item);
                }
            }

            return perdaRepositorio.ObterTodasPerdas();
        }
    }
}
