using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    class CadastroOcorrenciaViewModel : BaseViewModel
    {
        public CadastroOcorrenciaViewModel()
        {
            Title = "Ocorrências";
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

        private string _rep;
        public string Rep
        {
            get => _rep;
            set => SetProperty(ref _rep, value);
        }

        private string _trat;
        public string Trat
        {
            get => _trat;
            set => SetProperty(ref _trat, value);
        }

        private string _descr;
        public string Descr
        {
            get => _descr;
            set => SetProperty(ref _descr, value);
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
