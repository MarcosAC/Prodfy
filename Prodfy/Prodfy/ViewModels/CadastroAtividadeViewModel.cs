using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class CadastroAtividadeViewModel : BaseViewModel
    {
        public CadastroAtividadeViewModel()
        {
            Title = "Atividades";
        }

        private string _dispId;
        public string DispId
        {
            get => _dispId;
            set => SetProperty(ref _dispId, value);
        }

        private string _colaboradorId;
        public string ColaboradorId
        {
            get => _colaboradorId;
            set => SetProperty(ref _colaboradorId, value);
        }

        private string _listaAtvId;
        public string ListaAtvId
        {
            get => _listaAtvId;
            set => SetProperty(ref _listaAtvId, value);
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

        private string _obs;
        public string Obs
        {
            get => _obs;
            set => SetProperty(ref _obs, value);
        }

        private string _lastUpdate;
        public string LastUpdate
        {
            get => _lastUpdate;
            set => SetProperty(ref _lastUpdate, value);
        }

        private string _indSinc;
        public string IndSinc
        {
            get => _indSinc;
            set => SetProperty(ref _indSinc, value);
        }

        private Command _cancelarCadastroCommand;
        public Command CancelarCadastroComand =>
            _cancelarCadastroCommand ?? (_cancelarCadastroCommand = new Command(async () => await ExecuteCancelarCadastroCommand()));

        private Task ExecuteCancelarCadastroCommand()
        {
            throw new NotImplementedException();
        }

        private Command _salvarCadastroCommand;
        public Command SalvarCadastroComand =>
            _salvarCadastroCommand ?? (_salvarCadastroCommand = new Command(async () => await ExecuteSalvarCadastroComand()));

        private Task ExecuteSalvarCadastroComand()
        {
            throw new NotImplementedException();
        }
    }
}