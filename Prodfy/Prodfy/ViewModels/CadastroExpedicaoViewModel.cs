using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class CadastroExpedicaoViewModel : BaseViewModel
    {
        public CadastroExpedicaoViewModel()
        {
            Title = "Expedição";
        }

        private string _dispId;
        public string DispId
        {
            get => _dispId;
            set => SetProperty(ref _dispId, value);
        }

        private string _loteId;
        public string LoteId
        {
            get => _loteId;
            set => SetProperty(ref _loteId, value);
        }

        private string _pontoControleId;
        public string PontoControleId
        {
            get => _pontoControleId;
            set => SetProperty(ref _pontoControleId, value);
        }

        private string _estagioId;
        public string EstagioId
        {
            get => _estagioId;
            set => SetProperty(ref _estagioId, value);
        }

        private string _mudaId;
        public string MudaId
        {
            get => _mudaId;
            set => SetProperty(ref _mudaId, value);
        }

        private string _dataSelecao;
        public string DataSelecao
        {
            get => _dataSelecao;
            set => SetProperty(ref _dataSelecao, value);
        }

        private string _dataEstaq;
        public string DataEstaq
        {
            get => _dataEstaq;
            set => SetProperty(ref _dataEstaq, value);
        }

        private string _qtdeEstaq;
        public string QtdeEstaq
        {
            get => _qtdeEstaq;
            set => SetProperty(ref _qtdeEstaq, value);
        }

        private string _qtdeComTubete;
        public string QtdeComTubete
        {
            get => _qtdeComTubete;
            set => SetProperty(ref _qtdeComTubete, value);
        }

        private string _qtdeSemTubete;
        public string QtdeSemTubetel
        {
            get => _qtdeSemTubete;
            set => SetProperty(ref _qtdeSemTubete, value);
        }

        private string _qtde;
        public string Qtde
        {
            get => _qtde;
            set => SetProperty(ref _qtde, value);
        }

        private string _colaboradorId;
        public string ColaboradorId
        {
            get => _colaboradorId;
            set => SetProperty(ref _colaboradorId, value);
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

        private string _expedDestId;
        public string ExpedDestId
        {
            get => _expedDestId;
            set => SetProperty(ref _expedDestId, value);
        }

        private string _obs;
        public string Obs
        {
            get => _obs;
            set => SetProperty(ref _obs, value);
        }

        private string _latitude;
        public string Latitude
        {
            get => _latitude;
            set => SetProperty(ref _latitude, value);
        }

        private string _longitude;
        public string Longitude
        {
            get => _longitude;
            set => SetProperty(ref _longitude, value);
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
        public Command CancelarCadastroCommand =>
            _cancelarCadastroCommand ?? (_cancelarCadastroCommand = new Command(async () => await ExecuteCancelarCadastroCommand()));

        private Task ExecuteCancelarCadastroCommand()
        {
            throw new NotImplementedException();
        }

        private Command _salvarCadastroCommand;
        public Command SalvarCadastroCommand =>
            _salvarCadastroCommand ?? (_salvarCadastroCommand = new Command(async () => await ExecuteSalvarCadastroCommand()));

        private Task ExecuteSalvarCadastroCommand()
        {
            throw new NotImplementedException();
        }
    }
}
