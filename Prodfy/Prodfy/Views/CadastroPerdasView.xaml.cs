using Prodfy.Models;
using Prodfy.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prodfy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CadastroPerdasView : ContentView
	{
		public CadastroPerdasView (/*CarregaCamposPerdas carregaCamposPerdas = null*/)
		{
			InitializeComponent ();

            //NavigationPage.SetHasBackButton(this, false);

            //BindingContext = new CadastroPerdasViewModel(carregaCamposPerdas);
        }
	}
}