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
        }

        private void OnClicked_LerCodigoQR(object sender, System.EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new AjustesView());
        }
    }
}