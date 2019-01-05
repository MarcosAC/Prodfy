using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prodfy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ExpedicaoView : ContentPage
	{
		public ExpedicaoView ()
		{
			InitializeComponent ();
            NavigationPage.SetHasBackButton(this, false);
        }
	}
}