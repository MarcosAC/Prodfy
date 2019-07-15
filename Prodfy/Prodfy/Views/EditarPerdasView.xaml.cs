using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prodfy.ViewModels
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditarPerdasView : ContentPage
	{
		public EditarPerdasView ()
		{
			InitializeComponent ();

            NavigationPage.SetHasBackButton(this, false);
        }
	}
}