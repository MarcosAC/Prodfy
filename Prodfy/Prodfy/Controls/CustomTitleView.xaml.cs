using Prodfy.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prodfy.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomTitleView : ContentView
    {
        public CustomTitleView()
        {
            InitializeComponent();

            BindingContext = new CustomTitleViewModel();
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

        public static readonly BindableProperty Icone1Property =
           BindableProperty.Create(
               propertyName: "Icone1",
               returnType: typeof(string),
               declaringType: typeof(CustomTitleView),
               defaultValue: "",
               defaultBindingMode: BindingMode.TwoWay,
               propertyChanged: Icone1PropertyChanged
           );

        public string Icone1
        {
            get { return (string)GetValue(Icone1Property); }
            set { SetValue(Icone1Property, value); }
        }

        private static void Icone1PropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var titleView = (CustomTitleView)bindable;

            titleView.icone1.Text = (string)newValue;
        }

        public static readonly BindableProperty Icone2Property =
           BindableProperty.Create(
               propertyName: "Icone2",
               returnType: typeof(string),
               declaringType: typeof(CustomTitleView),
               defaultValue: "",
               defaultBindingMode: BindingMode.TwoWay,
               propertyChanged: Icone2PropertyChanged
           );

        public string Icone2
        {
            get { return (string)GetValue(Icone2Property); }
            set { SetValue(Icone2Property, value); }
        }

        private static void Icone2PropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var titleView = (CustomTitleView)bindable;

            titleView.icone2.Text = (string)newValue;
        }
    }
}