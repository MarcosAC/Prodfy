using Prodfy.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prodfy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PesquisarEstoqueViveiroView : ContentPage
	{
		public PesquisarEstoqueViveiroView ()
		{
			InitializeComponent ();

            NavigationPage.SetHasBackButton(this, false);

            BindingContext = new PesquisarEstoqueViveiroViewModel();
        }
	}
}