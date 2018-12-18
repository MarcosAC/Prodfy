using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Naxam.Controls.Platform.Droid;

namespace Prodfy.Droid
{
    [Activity(Label = "Prodfy", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            BottomTabbedRenderer.BackgroundColor = new Android.Graphics.Color(211, 211, 211);
            BottomTabbedRenderer.FontSize = 10;
            BottomTabbedRenderer.IconSize = 20;
            BottomTabbedRenderer.ItemSpacing = 8;
            BottomTabbedRenderer.ItemPadding = new Xamarin.Forms.Thickness(8);
            BottomTabbedRenderer.BottomBarHeight = 60;

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
    }
}