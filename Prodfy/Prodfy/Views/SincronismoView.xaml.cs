using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prodfy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SincronismoView : ContentPage
	{
		public SincronismoView ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void OnClicked_Sincronizar(object sender, System.EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new AjustesView());
        }
    }
}