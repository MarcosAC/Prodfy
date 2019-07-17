using Prodfy.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prodfy.ViewModels
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditarPerdasView : ContentPage
	{
		public EditarPerdasView (EditarPerdas editarPerdas)
		{
			InitializeComponent ();

            NavigationPage.SetHasBackButton(this, false);

            BindingContext = new EditarPerdasViewModel(editarPerdas);
        }
	}
}