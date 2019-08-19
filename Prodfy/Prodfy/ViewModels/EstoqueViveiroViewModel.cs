﻿using Prodfy.Services.Dialog;
using Prodfy.Services.Navigation;
using Prodfy.Views;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.ViewModels
{
    public class EstoqueViveiroViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
        private readonly IDialogService dialogService;

        public EstoqueViveiroViewModel()
        {
            Title = "Estoque Viveiro";

            navigationService = new NavigationService();
            dialogService = new DialogService();
        }

        private Command _titleViewBotaoVoltarCommand;
        public Command TitleViewBotaoVoltarCommand =>
            _titleViewBotaoVoltarCommand ?? (_titleViewBotaoVoltarCommand = new Command(async () => await ExecuteTitleViewBotaoVoltarCommand()));

        private async Task ExecuteTitleViewBotaoVoltarCommand() => await navigationService.PopAsync();        

        private Command _irParaCadastroEstoqueViveiroCommand;
        public Command IrParaCadastroEstoqueViveiroCommand =>
            _irParaCadastroEstoqueViveiroCommand ?? (_irParaCadastroEstoqueViveiroCommand = new Command(async () => await ExecuteIrParaCadastroEstoqueViveiroCommand()));

        private async Task ExecuteIrParaCadastroEstoqueViveiroCommand() => await navigationService.PushAsync(new CadastroEstoqueViveiroView());
    }
}
