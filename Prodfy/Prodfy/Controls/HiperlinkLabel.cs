using System;
using Xamarin.Forms;

namespace Prodfy.Controls
{
    public class HiperlinkLabel : Label
    {
        public HiperlinkLabel()
        {
            FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label));
            FontAttributes = FontAttributes.Bold;
            TextDecorations = TextDecorations.Underline;
            TextColor = Color.Blue;

            GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => Device.OpenUri(new Uri(Url)))
            });
        }

        public static readonly BindableProperty UrlProperty =
            BindableProperty.Create(
                nameof(Url),
                typeof(string),
                typeof(HiperlinkLabel),
                null
            );

        public string Url
        {
            get { return (string)GetValue(UrlProperty); }
            set { SetValue(UrlProperty, value); }
        }
    }
}
