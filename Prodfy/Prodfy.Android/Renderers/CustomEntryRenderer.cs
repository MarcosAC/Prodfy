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
                //Control.Background = Context.GetDrawable(Resource.Drawable.RoundedEntry);               
                BorderLessBotton();
                BorderEntry();
            }
        }

        private void BorderLessBotton()
        {
            Control.Background = new ColorDrawable(Android.Graphics.Color.Transparent);
        }

        private void BorderEntry()
        {
            GradientDrawable gd = new GradientDrawable();
            gd.SetColor(Android.Graphics.Color.White);
            gd.SetShape(ShapeType.Rectangle);
            gd.SetCornerRadius(10);
            gd.SetStroke(4, Android.Graphics.Color.White);
            Control.SetBackground(gd);
        }
    }
}