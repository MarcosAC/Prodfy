using System.Threading.Tasks;

namespace Prodfy.Services.Dialog
{
    public interface IDialogService
    {
        Task AlertAsync(string title, string message, string cancel);
        //Task AlertAsync(string title, string message, string accept, string cancel);
        Task<bool> AlertAsync(string title, string message, string ok, string cancel);
    }
}
