using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prodfy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TherWebView : ContentPage
	{
		public TherWebView (string nomePagina)
		{
			InitializeComponent ();

            NavigationPage.SetHasBackButton(this, false);            

            therWebView.Source = "file:///android_asset/" + nomePagina;            
        }
    }
}