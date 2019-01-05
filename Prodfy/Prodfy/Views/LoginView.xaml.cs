using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prodfy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void OnClick_Entrar(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new SincronismoView());
        }
    }
}