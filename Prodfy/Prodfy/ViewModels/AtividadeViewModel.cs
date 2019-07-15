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

        private Command _deletarAtividadeListaCommand;
        public Command DeletarAtividadeListaCommand =>
            _deletarAtividadeListaCommand ?? (_deletarAtividadeListaCommand = new Command(async () => await ExecuteDeletarAtividadeListaCommand()));

        private Task ExecuteDeletarAtividadeListaCommand()
        {
            throw new NotImplementedException();
        }

        private List<ListaAtividades> Atividades(string filtro = null)
        {
            if (!string.IsNullOrEmpty(filtro))
            {
                var listaAtividades = new List<ListaAtividades>();

                foreach (var item in atividadeRepositorio.ListaDeAtividades(filtro))
                {
                    listaAtividades.Add(item);
                }
            }

            return atividadeRepositorio.ListaDeAtividades(filtro);
        }
    }
}
