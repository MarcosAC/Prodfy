﻿using Prodfy.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Prodfy
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            #if DEBUG
                HotReloader.Current.Start(this);     
            #endif

            MainPage = new NavigationPage(new InicioView())
            {
                BarBackgroundColor = Color.FromHex("#206805")
            };
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
