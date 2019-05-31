using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prodfy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PaginaHtmlIdentificacaoView : ContentPage
	{
		public PaginaHtmlIdentificacaoView (string codigoHtml)
		{
			InitializeComponent ();

            NavigationPage.SetHasBackButton(this, false);

            var conteudoHtml = new HtmlWebViewSource();

            conteudoHtml.Html = @codigoHtml;

            IdentificacaoHtml.Source = conteudoHtml;
        }
	}
}