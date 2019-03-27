using Prodfy.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prodfy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PoliticaDePrivacidadeView : ContentPage
	{
		public PoliticaDePrivacidadeView ()
		{
			InitializeComponent ();

            NavigationPage.SetHasBackButton(this, false);

            BindingContext = new PoliticaDePrivacidadeViewModel();
        }
	}
}