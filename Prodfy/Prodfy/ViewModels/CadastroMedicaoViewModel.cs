using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    class CadastroMedicaoViewModel : BaseViewModel
    {
        public CadastroMedicaoViewModel()
        {
            Title = "Medições";
        }

        private string _dispId;
        public string DispId
        {
            get => _dispId;
            set => SetProperty(ref _dispId, value);
        }

        private string _monitId;
        public string MonitId
        {
            get => _monitId;
            set => SetProperty(ref _monitId, value);
        }

        private string _data;
        public string DataId
        {
            get => _data;
            set => SetProperty(ref _data, value);
        }

        private string _parcela;
        public string Parcela
        {
            get => _parcela;
            set => SetProperty(ref _parcela, value);
        }

        private string _codArv;
        public string CodArv
        {
            get => _codArv;
            set => SetProperty(ref _codArv, value);
        }

        private string _altura;
        public string Altura
        {
            get => _altura;
            set => SetProperty(ref _altura, value);
        }

        private string _cap;
        public string Cap
        {
            get => _cap;
            set => SetProperty(ref _cap, value);
        }

        private string _dap;
        public string Dap
        {
            get => _dap;
            set => SetProperty(ref _dap, value);
        }

        private string _falhaDiag;
        public string FalhaDiag
        {
            get => _falhaDiag;
            set => SetProperty(ref _falhaDiag, value);
        }

        private string _falhaLat;
        public string FalhaLat
        {
            get => _falhaLat;
            set => SetProperty(ref _falhaLat, value);
        }

        private string _falhaCol;
        public string FalhaCol
        {
            get => _falhaCol;
            set => SetProperty(ref _falhaCol, value);
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
