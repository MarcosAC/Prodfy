using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Prodfy.Services.Dialog
{
    public class DialogService : IDialogService
    {
        public async Task AlertAsync(string title, string message, string cancel) 
            => await App.Current.MainPage.DisplayAlert(title, message, cancel);

        public async Task AlertAsync(string title, string message, string accept, string cancel) 
            => await App.Current.MainPage.DisplayAlert(title, message, accept, cancel);
    }
}
