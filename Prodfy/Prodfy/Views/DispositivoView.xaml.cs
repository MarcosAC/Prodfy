using Prodfy.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prodfy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DispositivoView : ContentPage
	{
        public DispositivoView ()
		{
			InitializeComponent ();

            NavigationPage.SetHasBackButton(this, false);

            BindingContext = new DispositivoViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ((DispositivoViewModel)BindingContext).RefreshCommand.Execute(null);
        }
    }
}