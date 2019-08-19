using Prodfy.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prodfy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CadastroEstoqueViveiroView : ContentPage
	{
		public CadastroEstoqueViveiroView ()
		{
			InitializeComponent ();

            NavigationPage.SetHasBackButton(this, false);

            BindingContext = new CadastroEstoqueViveiroViewModel();
		}
	}
}