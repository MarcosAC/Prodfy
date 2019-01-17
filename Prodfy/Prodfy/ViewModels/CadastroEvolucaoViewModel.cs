using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class CadastroEvolucaoViewModel : BaseViewModel
    {
        public CadastroEvolucaoViewModel()
        {
            Title = "Evolução";
        }

        private string _data;
        public string Data
        {
            get => _data;
            set => SetProperty(ref _data, value);
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

        private string _indMudaTodas;
        public string IndMudaTdodas
        {
            get => _indMudaTodas;
            set => SetProperty(ref _indMudaTodas, value);
        }
        private string _dataEstaq;
        public string DataEstaq
        {
            get => _dataEstaq;
            set => SetProperty(ref _dataEstaq, value);
        }

        private string _qtdeTotal;
        public string QtdeTotal
        {
            get => _qtdeTotal;
            set => SetProperty(ref _qtdeTotal, value);
        }

        private string _qtde;
        public string Qtde
        {
            get => _qtde;
            set => SetProperty(ref _qtde, value);
        }

        private string _dataSelecao;
        public string DataSelecao
        {
            get => _dataSelecao;
            set => SetProperty(ref _dataSelecao, value);
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
