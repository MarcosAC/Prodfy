using Prodfy.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prodfy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SincronismoView : ContentPage
	{
		public SincronismoView ()
		{
			InitializeComponent ();

            NavigationPage.SetHasNavigationBar(this, false);

            BindingContext = new SincronismoViewModel();
        }
    }
}