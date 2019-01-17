using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class CadastroInventarioViewModel : BaseViewModel
    {
        public CadastroInventarioViewModel()
        {
            Title = "Inventário";
        }

        private string _loteInventarioId;
        public string LoteInventarioId
        {
            get => _loteInventarioId;
            set => SetProperty(ref _loteInventarioId, value);
        }

        private string _loteId;
        public string LoteId
        {
            get => _loteId;
            set => SetProperty(ref _loteId, value);
        }

        private string _mudaId;
        public string MudaId
        {
            get => _mudaId;
            set => SetProperty(ref _mudaId, value);
        }

        private string _dataEstaq;
        public string DataEstaq
        {
            get => _dataEstaq;
            set => SetProperty(ref _dataEstaq, value);
        }

        private string _dataSelecao;
        public string DataSelecao
        {
            get => _dataSelecao;
            set => SetProperty(ref _dataSelecao, value);
        }

        private string _qtde;
        public string Qtde
        {
            get => _qtde;
            set => SetProperty(ref _qtde, value);
        }

        private string _colabEstaqId;
        public string ColabEstaqId
        {
            get => _colabEstaqId;
            set => SetProperty(ref _colabEstaqId, value);
        }

        private string _colabEstaq;
        public string ColabEstaq
        {
            get => _colabEstaq;
            set => SetProperty(ref _colabEstaq, value);
        }

        private string _colabSelecaoId;
        public string ColabSelecaoId
        {
            get => _colabSelecaoId;
            set => SetProperty(ref _colabSelecaoId, value);
        }

        private string _colabSelecao;
        public string ColabSelecao
        {
            get => _colabSelecao;
            set => SetProperty(ref _colabSelecao, value);
        }

        private string _qualidadeId;
        public string QualidadeId
        {
            get => _qualidadeId;
            set => SetProperty(ref _qualidadeId, value);
        }

        private string _qualidade;
        public string Qualidade
        {
            get => _qualidade;
            set => SetProperty(ref _qualidade, value);
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
