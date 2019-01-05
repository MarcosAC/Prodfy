using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prodfy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MedicaoView : ContentPage
	{
		public MedicaoView ()
		{
			InitializeComponent ();
            NavigationPage.SetHasBackButton(this, false);
        }
	}
}