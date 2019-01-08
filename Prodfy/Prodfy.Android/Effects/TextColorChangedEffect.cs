using Android.Widget;
using Prodfy.Droid.Effects;
using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("MyEffects")]
[assembly: ExportEffect(typeof(TextColorChangedEffect), "TextColorChangedEffect")]
namespace Prodfy.Droid.Effects
{
    public class TextColorChangedEffect : PlatformEffect
    {
        //Android.Graphics.Color textColorChanged = Android.Graphics.Color.Gray;
        Label control = new Label();

        protected override void OnAttached()
        {
            //textColorChanged = Android.Graphics.Color.Gray;
            control.TextColor = Color.Gray;
        }

        protected override void OnDetached()
        {
            throw new NotImplementedException();
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);            

            if (args.PropertyName == "IsTapped")
            {
                if (control.TextColor == Color.Gray)
                {
                    control.TextColor = Color.LightBlue;
                }
            }
        }
    }
}