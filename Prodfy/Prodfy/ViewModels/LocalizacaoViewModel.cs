using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class LocalizacaoViewModel : BaseViewModel
    {
        public LocalizacaoViewModel()
        {
            Title = "Loclização";
        }

        private string _monitoramento;
        public string Monitoramento
        {
            get => _monitoramento;
            set => SetProperty(ref _monitoramento, value);
        }

        private string _plantio;
        public string Plantio
        {
            get => _plantio;
            set => SetProperty(ref _plantio, value);
        }

        private string _projeto;
        public string Projeto
        {
            get => _projeto;
            set => SetProperty(ref _projeto, value);
        }

        private string _objetivo;
        public string Objetivo
        {
            get => _objetivo;
            set => SetProperty(ref _objetivo, value);
        }

        private Command _irMapalocalizacaoCommand;
        public Command IrMapaLocalizacaoCommand =>
            _irMapalocalizacaoCommand ?? (_irMapalocalizacaoCommand = new Command(async () => await ExecuteLocalizacaoCommand()));

        private Task ExecuteLocalizacaoCommand()
        {
            throw new NotImplementedException();
        }
    }
}
