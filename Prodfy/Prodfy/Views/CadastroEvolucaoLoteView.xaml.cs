using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prodfy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CadastroEvolucaoLoteView : ContentPage
	{
		public CadastroEvolucaoLoteView ()
		{
			InitializeComponent ();
            NavigationPage.SetHasBackButton(this, false);
        }
	}
}