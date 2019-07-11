using Prodfy.Models;
using Prodfy.Services;
using Prodfy.Services.Dialog;
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

        public ObservableCollection<ListaPerdas> ListaDePerdas { get; }

        public PerdasViewModel()
        {
            Title = "Perdas";

            navigationService = new NavigationService();
            dialogService = new DialogService();

            perdaRepositorio = new PerdaRepository();
            loteRepositorio = new LoteRepository();
            mudaRepositorio = new MudaRepository();

            ListaDePerdas = new ObservableCollection<ListaPerdas>(Perdas());
        }

        private string _filtro;
        public string Filtro
        {
            get { return _filtro; }
            set
            {
                SetProperty(ref _filtro, value);
                //Atividades(_filtro);
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

                string[] resultadoQR = result.Text.Split('|');

                if (resultadoQR.Count() < 8)
                {
                    await dialogService.AlertAsync("Etiqueta QR", "Etiqueta incompatível! Gere uma nova etiqueta QR!", "Ok");

                    IsBusy = false;

                    return;
                }

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

                //LOTE
                if (!string.IsNullOrEmpty(dadosQR.qrLoteCod))
                {
                    //Lote ID
                    string loteInfo = loteRepositorio.ObterLotePorId(dadosQR.qrLoteCod);
                    var tmpLoteInfo = loteInfo.Split('|');

                    if (tmpLoteInfo[0] == "0")
                    {
                        await dialogService.AlertAsync("Etiqueta QR", "Lote indicado no QR inexistente! Sincronize o dispositivo.", "Ok");
                        return;
                    }

                    //Lote Produto ID
                    string loteProdutoInfo = loteRepositorio.ObterLoteProdutoPorId(dadosQR.qrLoteCod);
                    var tmpLoteprodutoInfo = loteProdutoInfo.Split('|');

                    if (tmpLoteprodutoInfo[0] == "0")
                    {
                        await dialogService.AlertAsync("Etiqueta QR", "Produto associado ao Lote indicado no QR inexistente! Sincronize o dispositivo.", "Ok");
                        return;
                    }
                }

                //MUDA
                if (!string.IsNullOrEmpty(dadosQR.qrMudaId))
                {
                    //Muda Nome Comum
                    string mudaIndo = mudaRepositorio.ObterInformacoesParaIdentificacao(int.Parse(dadosQR.qrMudaId));
                    var tmpMudainfo = mudaIndo.Split('|');

                    if (tmpMudainfo[0] == "0")
                    {
                        await dialogService.AlertAsync("Etiqueta QR", "Muda indicada no QR inexistente! Sincronize o dispositivo.", "Ok");
                        return;
                    }
                }

                if (dadosQR.qrTipoEtiqueta == null || dadosQR.qrTipoEtiqueta != "1")
                {
                    await dialogService.AlertAsync("Etiqueta QR", "Etiqueta incompatível! Gere uma nova etiqueta QR!", "Ok");
                    return;
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
                    await dialogService.AlertAsync("", $"Perda item {perdaSelecionado.idperda} DELETADO!!", "Ok");
                }
                catch (Exception)
                {
                    await dialogService.AlertAsync("", $"Erro ao deletar item {perdaSelecionado.idperda}", "Ok");
                }
            }
        }

        private List<ListaPerdas> Perdas(string filtro = null)
        {
            if (!string.IsNullOrEmpty(filtro))
            {
                var listaDadosPerdas = new List<ListaPerdas>();

                foreach (var item in perdaRepositorio.ListaDePerdas(filtro))
                {
                    listaDadosPerdas.Add(item);
                }
            }

            return perdaRepositorio.ListaDePerdas(filtro);
        }
    }
}
