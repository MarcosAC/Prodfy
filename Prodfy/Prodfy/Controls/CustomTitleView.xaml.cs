using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prodfy.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CustomTitleView : ContentView
	{
		public CustomTitleView ()
		{
			InitializeComponent ();
		}

        public static readonly BindableProperty TituloProperty =
            BindableProperty.Create(
                propertyName: "Titulo",
                returnType: typeof(string),
                declaringType: typeof(CustomTitleView),
                defaultValue: "",
                propertyChanged: TituloPropertyChanged
            );

        public string Titulo
        {
            get { return (string)GetValue(TituloProperty); }
            set { SetValue(TituloProperty, value); }
        }

        private static void TituloPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var titleView = (CustomTitleView)bindable;

            titleView.titulo.Text = (string)newValue;
        }

        public static readonly BindableProperty IconeProperty =
           BindableProperty.Create(
               propertyName: "Icone",
               returnType: typeof(string),
               declaringType: typeof(CustomTitleView),
               defaultValue: "",
               defaultBindingMode: BindingMode.TwoWay,
               propertyChanged: IconePropertyChanged
           );

        public string Icone
        {
            get { return (string)GetValue(IconeProperty); }
            set { SetValue(IconeProperty, value); }
        }

        private static void IconePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var titleView = (CustomTitleView)bindable;

            titleView.icone.Text = (string)newValue;
        }
    }
}