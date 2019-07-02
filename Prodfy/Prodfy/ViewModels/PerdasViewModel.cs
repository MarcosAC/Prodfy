using Prodfy.Services;
using Prodfy.Services.Dialog;
using Prodfy.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class PerdasViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
        private readonly IDialogService dialogService;

        public PerdasViewModel()
        {
            Title = "Perdas";

            navigationService = new NavigationService();
            dialogService = new DialogService();
        }

        private string _filtro;
        public string Filtro
        {
            get { return _filtro; }
            set
            {
                SetProperty(ref _filtro, value);
                //Atividades(_filtro);
            }
        }

        private Command _titleViewBotaoVoltarCommand;
        public Command TitleViewBotaoVoltarCommand =>
            _titleViewBotaoVoltarCommand ?? (_titleViewBotaoVoltarCommand = new Command(async () => await ExecuteTitleViewBotaoVoltarCommand()));

        private async Task ExecuteTitleViewBotaoVoltarCommand() => await navigationService.PopAsync();

        private Command _irParaCadastroPerdasCommand;
        public Command IrParaCadastroPerdasCommand =>
            _irParaCadastroPerdasCommand ?? (_irParaCadastroPerdasCommand = new Command(async () => await ExecuteIrParaCadastroPerdasCommand()));

        private async Task ExecuteIrParaCadastroPerdasCommand() => await navigationService.PushAsync(new CadastroPerdasView());

        private Command _leitorQRCommand;
        public Command LeitorQRCommand => _leitorQRCommand ?? (_leitorQRCommand = new Command(async () => await ExecuteLeitorQRCommand()));

        private async Task ExecuteLeitorQRCommand()
        {
            var scanner = new ZXing.Mobile.MobileBarcodeScanner();
            var result = await scanner.Scan();
        }
    }
}
