using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prodfy.Services
{
    public interface INavigationService
    {
        Task PushAsync(Page page);
        Task PushModalAsync(Page page);
        Task PushModalAsync();
        Task PopAsync();
    }
}
