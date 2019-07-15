using Prodfy.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prodfy.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AdicionarPerdasView : ContentPage
	{
		public AdicionarPerdasView ()
		{
			InitializeComponent ();

            NavigationPage.SetHasBackButton(this, false);

            BindingContext = new AdicionarPerdasViewModel();
        }
	}
}