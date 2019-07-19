using Prodfy.Models;
using Prodfy.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prodfy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CadastroPerdasQrView : ContentPage
	{
		public CadastroPerdasQrView (CarregarDadosPerdaQr dadosPerdaQr)
		{
			InitializeComponent ();

            NavigationPage.SetHasBackButton(this, false);

            BindingContext = new CadastroPerdasQrViewModel(dadosPerdaQr);
        }
    }
}