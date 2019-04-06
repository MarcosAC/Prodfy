using Android.Content;
using Android.Graphics.Drawables;
using Prodfy.Controls;
using Prodfy.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace Prodfy.Droid.Renderers
{
    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);                           

            if (Control != null)
            {
                //Control.Background = Context.GetDrawable(Resource.Drawable.RoundedCorner);
                RoundedCorner();
                BorderLessBotton();
            }
        }

        private void BorderLessBotton()
        {
            Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
        }

        private void RoundedCorner()
        {
            GradientDrawable gd = new GradientDrawable();
            // increase or decrease to changes the corner 
            gd.SetCornerRadius(30);
            Control.Background = gd;
            Control.Background = Context.GetDrawable(Resource.Drawable.RoundedCorner);
        }
    }
}