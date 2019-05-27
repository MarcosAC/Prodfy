using Prodfy.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prodfy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PaginaHtmlIdentificacaoView : ContentPage
	{
		public PaginaHtmlIdentificacaoView ()
		{
			InitializeComponent ();

            BindingContext = new IdentificacaoViewModel();

            //BindingContext = new IdentificacaoViewModel();

            //var browser = new WebView();

            //var conteudoHtml = new HtmlWebViewSource();

            //conteudoHtml.Html = @"";
		}
	}
}