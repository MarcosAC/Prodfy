using Prodfy.ViewModels;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prodfy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PaginaHtmlIdentificacaoView : PopupPage
    {
		public PaginaHtmlIdentificacaoView (string codigoHtml)
		{
			InitializeComponent ();

            NavigationPage.SetHasBackButton(this, false);

            BindingContext = new IdentificacaoViewModel();

            var conteudoHtml = new HtmlWebViewSource
            {
                Html = @codigoHtml
            };

            IdentificacaoHtml.Source = conteudoHtml;
        }
    }
}