using Prodfy.Models;
using Prodfy.Services;
using Prodfy.Services.Dialog;
using Prodfy.Services.Repository;
using Prodfy.Views;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class HistoricoViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
        private readonly IDialogService dialogService;

        private readonly HistoricoRepository historicoRepositorio;

        public ObservableCollection<ListaHistorico> ListaDeHistoricos { get; }

        public HistoricoViewModel()
        {
            Title = "Histórico";

            navigationService = new NavigationService();
            dialogService = new DialogService();

            historicoRepositorio = new HistoricoRepository();

            ListaDeHistoricos = new ObservableCollection<ListaHistorico>(Historicos());
            Historicos().Clear();
        }

        private Command _titleViewBotaoVoltarCommand;
        public Command TitleViewBotaoVoltarCommand =>
            _titleViewBotaoVoltarCommand ?? (_titleViewBotaoVoltarCommand = new Command(async () => await ExecuteTitleViewBotaoVoltarCommand()));

        private async Task ExecuteTitleViewBotaoVoltarCommand() => await navigationService.PopAsync();

        private Command _irParaCadastroHistoricoCommand;
        public Command IrParaCadastroHistoricoCommand => 
            _irParaCadastroHistoricoCommand ?? (_irParaCadastroHistoricoCommand = new Command(async () => await ExecuteIrParaCadastroHistoricoCommand()));

        private async Task ExecuteIrParaCadastroHistoricoCommand() => await navigationService.PushAsync(new CadastroHistoricoView());

        private Command _selecionarHistoricoCommand;
        public Command SelecionarHistoricoCommand =>
            _selecionarHistoricoCommand ?? (_selecionarHistoricoCommand = new Command<ListaHistorico>(async h => await ExecuteSelecionarHistoricoCommand(h)));

        private async Task ExecuteSelecionarHistoricoCommand(ListaHistorico historicoSelecionado)
        {
            if (historicoSelecionado == null)
                return;

            bool deleteAceite = await dialogService.AlertAsync($"LOTE {historicoSelecionado.Codigo}", "Deseja apagar este registro ?", "Sim", "Não");

            if (deleteAceite)
            {
                try
                {
                    historicoRepositorio.Deletar(historicoSelecionado.IdHistorico);
                    await dialogService.AlertAsync("", $"Histórico item {historicoSelecionado.IdHistorico} DELETADO!!", "Ok");
                }
                catch (System.Exception)
                {
                    await dialogService.AlertAsync("", $"Erro ao deletar item {historicoSelecionado.IdHistorico}", "Ok");
                }
            }
        }

        private List<ListaHistorico> Historicos()
        {
            List<ListaHistorico> listaDadosHistoricos = new List<ListaHistorico>();

            foreach (var item in historicoRepositorio.ListaDeHistoricos())
            {
                listaDadosHistoricos.Add(item);
            }

            return listaDadosHistoricos;            
        }
    }
}
