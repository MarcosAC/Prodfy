using Prodfy.Models;
using Prodfy.Services.Dialog;
using Prodfy.Services.Navigation;
using Prodfy.Services.Repository;
using Prodfy.Views;
using System;
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
        }

        private string _filtro;
        public string Filtro
        {
            get { return _filtro; }
            set
            {
                SetProperty(ref _filtro, value);
                Historicos(_filtro);
            }
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
                    await RefreshCommandExecute();
                }
                catch (Exception)
                {
                    await dialogService.AlertAsync("", $"Erro ao deletar item {historicoSelecionado.IdHistorico}", "Ok");
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

                ListaDeHistoricos.Clear();

                foreach (var item in historicoRepositorio.ObterTodosHistoricos())
                {
                    ListaDeHistoricos.Add(item);
                }
            }
            catch (Exception)
            {
                await dialogService.AlertAsync("Erro", "Erro ao listar Historicos", "Ok");
            }
            finally
            {
                RefreshCommand.ChangeCanExecute();
            }
        }

        private List<ListaHistorico> Historicos(string filtro = null)
        {
            if (filtro != null)
            {
                var listaDadosHistoricos = historicoRepositorio.ListaDeHistoricos(filtro);

                ListaDeHistoricos.Clear();

                foreach (var item in listaDadosHistoricos)
                {
                    ListaDeHistoricos.Add(item);
                }
            }

            return historicoRepositorio.ObterTodosHistoricos();
        }
    }
}
