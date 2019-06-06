using Prodfy.Services;
using Prodfy.Services.Dialog;
using Prodfy.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class HistoricoViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
        private readonly IDialogService dialogService;

        public HistoricoViewModel()
        {
            Title = "Histórico";

            navigationService = new NavigationService();
            dialogService = new DialogService();
        }

        private Command _titleViewBotaoVoltarCommand;
        public Command TitleViewBotaoVoltarCommand =>
            _titleViewBotaoVoltarCommand ?? (_titleViewBotaoVoltarCommand = new Command(async () => await ExecuteTitleViewBotaoVoltarCommand()));

        private async Task ExecuteTitleViewBotaoVoltarCommand() => await navigationService.PopAsync();

        private Command _irParaCadastroHistoricoCommand;
        public Command IrParaCadastroHistoricoCommand => 
            _irParaCadastroHistoricoCommand ?? (_irParaCadastroHistoricoCommand = new Command(async () => await ExecuteIrParaCadastroHistoricoCommand()));

        private async Task ExecuteIrParaCadastroHistoricoCommand() => await navigationService.PushAsync(new CadastroHistoricoView());
    }
}
