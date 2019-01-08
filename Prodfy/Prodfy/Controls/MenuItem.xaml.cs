using Prodfy.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prodfy.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuItem : ContentView
	{
		public MenuItem ()
		{
			InitializeComponent ();
		}

        private void OnTapped_Inicio(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new LoginView());
        }

        private void OnTapped_Funcoes(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new FuncoesView());
        }

        private void OnTapped_Sincronia(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new SincronismoView());
        }

        private void OnTapped_Ajustes(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new AjustesView());
        }
    }
}