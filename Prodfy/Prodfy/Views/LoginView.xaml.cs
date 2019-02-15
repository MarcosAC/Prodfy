using Prodfy.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prodfy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            BindingContext = new LoginViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ((LoginViewModel)BindingContext).RefreshCommand.Execute(null);
        }
    }
}