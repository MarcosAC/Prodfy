using Prodfy.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prodfy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroAtividadeView : ContentPage
    {
        public CadastroAtividadeView()
        {
            InitializeComponent();

            NavigationPage.SetHasBackButton(this, false);

            BindingContext = new CadastroAtividadeViewModel();
        }
    }
}