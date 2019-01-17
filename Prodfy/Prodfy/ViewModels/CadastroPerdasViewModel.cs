using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class CadastroPerdasViewModel : BaseViewModel
    {
        public CadastroPerdasViewModel()
        {
            Title = "Perdas";
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

        private string _mudaId;
        public string MudaId
        {
            get => _mudaId;
            set => SetProperty(ref _mudaId, value);
        }

        private string _produtoId;
        public string ProdutoId
        {
            get => _produtoId;
            set => SetProperty(ref _produtoId, value);
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

        private string _motivoId;
        public string MotivoId
        {
            get => _motivoId;
            set => SetProperty(ref _motivoId, value);
        }

        private string _data;
        public string Data
        {
            get => _data;
            set => SetProperty(ref _data, value);
        }

        private string _qtde;
        public string Qtde
        {
            get => _qtde;
            set => SetProperty(ref _qtde, value);
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
