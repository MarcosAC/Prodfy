using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class AtividadeViewModel : BaseViewModel
    {
        public AtividadeViewModel()
        {
            Title = "Atividades";
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

        private Command _deletarAtividadeListaCommand;
        public Command DeletarAtividadeListaCommand =>
            _deletarAtividadeListaCommand ?? (_deletarAtividadeListaCommand = new Command(async () => await ExecuteDeletarAtividadeListaCommand()));

        private Task ExecuteDeletarAtividadeListaCommand()
        {
            throw new NotImplementedException();
        }
    }
}
