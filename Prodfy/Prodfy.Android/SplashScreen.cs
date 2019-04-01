using Android.App;
using Android.OS;

namespace Prodfy.Droid
{
    [Activity(Label = "Prodfy Plantas", Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = true)]
    public class SplashScreen : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            StartActivity(typeof(MainActivity));        
        }
    }
}