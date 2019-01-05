using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prodfy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AjustesView : ContentPage
    {
        public AjustesView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void OnClicked_Dispositivo(object sender, System.EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new DispositivoView());
        }

        private void OnClicked_Conexao(object sender, System.EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new ConexaoView());
        }

        private void OnClicked_Exportar(object sender, System.EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new ExportarDadosView());
        }

        private void OnClicked_Sobre(object sender, System.EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new AtividadeRealizadaView());
        }
    }
}