using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prodfy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CadastroPerdasView : ContentPage
	{
		public CadastroPerdasView ()
		{
			InitializeComponent ();
            NavigationPage.SetHasBackButton(this, false);
        }
	}
}