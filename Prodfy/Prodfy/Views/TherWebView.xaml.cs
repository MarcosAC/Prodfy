﻿using Prodfy.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prodfy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TherWebView : ContentPage
	{
		public TherWebView (string url)
		{
			InitializeComponent ();

            NavigationPage.SetHasBackButton(this, false);

            BindingContext = new TherWebViewModel(url);

            therWebView.Source = url;            
        }
    }
}