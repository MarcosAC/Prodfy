using Prodfy.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prodfy.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MenuItem : ContentView
	{
        string tapped = string.Empty;

        public MenuItem ()
		{
			InitializeComponent ();

            GoToState(false, tapped);
        }

        private void GoToState(bool isValid, string tapped)
        {
            string visualState = isValid ? "Valid" : "Normal";

            if (tapped == "inicio")
                VisualStateManager.GoToState(lblIconeInicio, visualState);

            if (tapped == "funcoes")
                VisualStateManager.GoToState(lblIconeFuncoes, visualState);

            if (tapped == "sincronia")
                VisualStateManager.GoToState(lblIconeSincronia, visualState);

            if (tapped == "ajustes")
                VisualStateManager.GoToState(lblIconeAjustes, visualState);

            if (tapped == "inicio")
                VisualStateManager.GoToState(lblInicio, visualState);

            if (tapped == "funcoes")
                VisualStateManager.GoToState(lblFuncoes, visualState);

            if (tapped == "sincronia")
                VisualStateManager.GoToState(lblSincronia, visualState);

            if (tapped == "ajustes")
                VisualStateManager.GoToState(lblAjustes, visualState);
        }

        private void OnTapped_Inicio(object sender, TappedEventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new LoginView());

            if (e != null)
            {
                string tapped = "inicio";
                bool isValid = true;
                GoToState(isValid, tapped);
            }
        }

        private void OnTapped_Funcoes(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new FuncoesView());

            if (e != null)
            {
                string tapped = "funcoes";
                bool isValid = true;
                GoToState(isValid, tapped);
            }
        }

        private void OnTapped_Sincronia(object sender, EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new SincronismoView());

            if (e != null)
            {
                string tapped = "sincronia";
                bool isValid = true;
                GoToState(isValid, tapped);
            }
        }

        private void OnTapped_Ajustes(object sender, TappedEventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new AjustesView());

            if (e != null)
            {
                string tapped = "ajustes";
                bool isValid = true;
                GoToState(isValid, tapped);
            }
        }
    }
}