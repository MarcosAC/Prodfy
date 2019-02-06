using System.Threading.Tasks;

namespace Prodfy.Services.Dialog
{
    public class DialogService : IDialogService
    {
        public async Task AlertAsync(string title, string message, string cancel) 
            => await App.Current.MainPage.DisplayAlert(title, message, cancel);

        public async Task AlertAsync(string title, string message, string accept, string cancel) 
            => await App.Current.MainPage.DisplayAlert(title, message, accept, cancel);

        async Task<bool> IDialogService.AlertAsync(string title, string message, string ok, string cancel)
            => await App.Current.MainPage.DisplayAlert(title, message, ok, cancel);
    }
}
