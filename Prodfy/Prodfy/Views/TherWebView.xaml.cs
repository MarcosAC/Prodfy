using Prodfy.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prodfy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TherWebView : ContentPage
	{
		public TherWebView (string paginaHtml)
		{
			InitializeComponent ();

            NavigationPage.SetHasBackButton(this, false);

            BindingContext = new TherWebViewModel(paginaHtml);

            therWebView.Source = "file:///android_asset/" + paginaHtml;            
        }
    }
}