using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prodfy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CadastroExpedicaoView : ContentPage
	{
		public CadastroExpedicaoView ()
		{
			InitializeComponent ();
            NavigationPage.SetHasBackButton(this, false);
        }
	}
}