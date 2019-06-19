using Prodfy.Services;
using Prodfy.Services.Dialog;
using Prodfy.Services.Repository;
using Prodfy.Views;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class AtividadeViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
        private readonly IDialogService dialogService;

        private readonly AtividadeRepository atividadeRepositorio;

        public AtividadeViewModel()
        {
            Title = "Atividades";

            navigationService = new NavigationService();
            dialogService = new DialogService();

            atividadeRepositorio = new AtividadeRepository();
        }

        private string _colaborador;
        public string Colaborador
        {
            get => _colaborador;
            set => SetProperty(ref _colaborador, value);
        }

        private string _atividade;
        public string Atividade
        {
            get => _atividade;
            set => SetProperty(ref _atividade, value);
        }

        private string _dataInicio;
        public string DataInicio
        {
            get => _dataInicio;
            set => SetProperty(ref _dataInicio, value);
        }

        private string _dataFim;
        public string DataFim
        {
            get => _dataFim;
            set => SetProperty(ref _dataFim, value);
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
    }
}
