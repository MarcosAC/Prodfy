using Android.Content;
using Android.OS;
using Android.Text;
using Prodfy.Controls;
using Prodfy.Droid.Renderers;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomHtmlLabel), typeof(CustomHtmlLabelRenderer))]
namespace Prodfy.Droid.Renderers
{
    public class CustomHtmlLabelRenderer : LabelRenderer
    {
        public CustomHtmlLabelRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == nameof(CustomHtmlLabel.Text))
            {
                UpdateText();
            }
        }

        private void UpdateText()
        {
            if (string.IsNullOrWhiteSpace(Element?.Text))
            {
                Control.Text = string.Empty;
                return;
            }

            Control.TextFormatted = Build.VERSION.SdkInt >= BuildVersionCodes.N ? Html.FromHtml(Element.Text, FromHtmlOptions.ModeCompact)
#pragma warning disable CS0618
                : Html.FromHtml(Element.Text);
#pragma warning disable CS061
            Control.MovementMethod = Android.Text.Method.LinkMovementMethod.Instance;
        }
    }
}