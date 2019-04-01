using Prodfy.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prodfy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FuncoesView : ContentPage
	{
		public FuncoesView()
		{
			InitializeComponent ();

            NavigationPage.SetHasNavigationBar(this, false);

            BindingContext = new FuncoesViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ((FuncoesViewModel)BindingContext).RefreshCommand.Execute(null);
        }
    }
}