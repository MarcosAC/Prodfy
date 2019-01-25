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

            NavigationPage.SetHasNavigationBar(this, false);

            //var htmlSource = new HtmlWebViewSource();

            //htmlSource.BaseUrl = DependencyService.Get<IBaseUrl>().Get();

            therWebView.Source = "file:///android_asset/" + nomePagina;            
		}
    }
}