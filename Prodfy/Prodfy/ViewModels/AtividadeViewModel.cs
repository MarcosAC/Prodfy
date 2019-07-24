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
    public class AtividadeViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
        private readonly IDialogService dialogService;

        private readonly AtividadeRepository atividadeRepositorio;

        public ObservableCollection<ListaAtividades> ListaDeAtividades { get; }        

        public AtividadeViewModel()
        {
            Title = "Atividades";

            navigationService = new NavigationService();
            dialogService = new DialogService();

            atividadeRepositorio = new AtividadeRepository();

            ListaDeAtividades = new ObservableCollection<ListaAtividades>(Atividades());            
        }

        private string _filtro;
        public string Filtro
        {
            get { return _filtro; }
            set
            {
                SetProperty(ref _filtro, value);
                Atividades(_filtro);
            }
        }

        private Command _titleViewBotaoVoltarCommand;
        public Command TitleViewBotaoVoltarCommand =>
            _titleViewBotaoVoltarCommand ?? (_titleViewBotaoVoltarCommand = new Command(async () => await ExecuteTitleViewBotaoVoltarCommand()));

        private async Task ExecuteTitleViewBotaoVoltarCommand() => await navigationService.PopAsync();

        private Command _irParaCadastroAtividadeCommand;
        public Command IrParaCadastroHistoricoCommand =>
            _irParaCadastroAtividadeCommand ?? (_irParaCadastroAtividadeCommand = new Command(async () => await ExecuteIrParaCadastroAtividadeCommand()));

        private async Task ExecuteIrParaCadastroAtividadeCommand() => await navigationService.PushAsync(new CadastroAtividadeView());

        private Command _selecionarAtividadeCommand;
        public Command SelecinarAtividadeCommand =>
            _selecionarAtividadeCommand ?? (_selecionarAtividadeCommand = new Command<ListaAtividades>(async a => await ExecuteSelecionarAtividadeListaCommand(a)));

        private async Task ExecuteSelecionarAtividadeListaCommand(ListaAtividades atividadeSelecionada)
        {
            if (atividadeSelecionada == null)
                return;

            bool deleteAceite = await dialogService.AlertAsync($"ATIVIDADE {atividadeSelecionada.codigo}", "Deseja apagar este registro ?", "Sim", "Não");

            if (deleteAceite)
            {
                try
                {
                    atividadeRepositorio.Deletar(atividadeSelecionada.idatividade);
                    await RefreshCommandExecute();
                }
                catch (Exception)
                {
                    await dialogService.AlertAsync("", $"Erro ao deletar item {atividadeSelecionada.idatividade}", "Ok");
                }
            }
        }

        private Command _RefreshCommand;
        public Command RefreshCommand => _RefreshCommand ?? (_RefreshCommand = new Command(async () => await RefreshCommandExecute()));

        private async Task RefreshCommandExecute()
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;
                RefreshCommand.ChangeCanExecute();

                ListaDeAtividades.Clear();

                foreach (var item in atividadeRepositorio.ObterTodasAtividades())
                {
                    ListaDeAtividades.Add(item);
                }
            }
            catch (Exception)
            {
                await dialogService.AlertAsync("Erro", "Erro ao listar Atividades", "Ok");
            }
            finally
            {
                IsBusy = false;
                RefreshCommand.ChangeCanExecute();
            }
        }

        private List<ListaAtividades> Atividades(string filtro = null)
        {
            if (filtro != null)
            {
                var listaAtividades = atividadeRepositorio.ListaDeAtividades(filtro.ToUpper());

                ListaDeAtividades.Clear();

                foreach (var item in listaAtividades)
                {
                    ListaDeAtividades.Add(item);
                }
            }

            return atividadeRepositorio.ObterTodasAtividades();
        }
    }
}
