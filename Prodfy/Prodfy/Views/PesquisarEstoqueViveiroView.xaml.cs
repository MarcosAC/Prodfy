using Prodfy.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prodfy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PesquisarEstoqueViveiroView : ContentPage
	{
		public PesquisarEstoqueViveiroView ()
		{
			InitializeComponent ();

            NavigationPage.SetHasBackButton(this, false);

            BindingContext = new PesquisarEstoqueViveiroViewModel();

            //var conteudoHtml = new HtmlWebViewSource
            //{
            //    Html = @"<html><body>
            //          <h1>Xamarin.Forms</h1>
            //          <p>Welcome to WebView.</p>
            //          </body></html>"
            //};

            //EstoqueViveiroHtml.Source = conteudoHtml;
        }
	}
}