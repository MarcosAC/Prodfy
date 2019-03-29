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
        bool isValid = false;
        bool paginaCarregada = false;

        public MenuItem ()
		{
			InitializeComponent ();

            GoToState(false, tapped);
        }

        private void GoToState(bool isValid, string tapped)
        {
            string visualState = isValid ? "Valid" : "Normal";

            if (tapped == "inicio")
            {
                visualState = "Valid";
                VisualStateManager.GoToState(lblIconeInicio, visualState);
                VisualStateManager.GoToState(lblInicio, visualState);
            }
            else if (tapped != "inicio")
            {
                visualState = "Normal";
                VisualStateManager.GoToState(lblIconeInicio, visualState);
                VisualStateManager.GoToState(lblInicio, visualState);
            }

            if (tapped == "funcoes")
            {
                visualState = "Valid";
                VisualStateManager.GoToState(lblIconeFuncoes, visualState);
                VisualStateManager.GoToState(lblFuncoes, visualState);
            }
            else if (tapped != "funcoes")
            {
                visualState = "Normal";
                VisualStateManager.GoToState(lblIconeFuncoes, visualState);
                VisualStateManager.GoToState(lblFuncoes, visualState);
            }

            if (tapped == "sincronia")
            {
                visualState = "Valid";
                VisualStateManager.GoToState(lblIconeSincronia, visualState);
                VisualStateManager.GoToState(lblSincronia, visualState);
            }
            else if (tapped != "sincronia")
            {
                visualState = "Normal";
                VisualStateManager.GoToState(lblIconeSincronia, visualState);
                VisualStateManager.GoToState(lblSincronia, visualState);
            }

            if (tapped == "ajustes")
            {
                visualState = "Valid";
                VisualStateManager.GoToState(lblIconeAjustes, visualState);
                VisualStateManager.GoToState(lblAjustes, visualState);
            }
            else if (tapped != "ajustes")
            {
                visualState = "Normal";
                VisualStateManager.GoToState(lblIconeAjustes, visualState);
                VisualStateManager.GoToState(lblAjustes, visualState);
            }
        }

        private void OnTapped_Inicio(object sender, TappedEventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new LoginView());

            paginaCarregada = true;

            if (paginaCarregada)
            {
                if (e != null)
                {
                    string tapped = "inicio";
                    isValid = true;
                    GoToState(isValid, tapped);
                }
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