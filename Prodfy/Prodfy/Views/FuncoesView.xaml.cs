using Prodfy.Utils;
using Prodfy.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prodfy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FuncoesView : ContentPage
	{
		public FuncoesView()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);

            // BindingContext = new FuncoesViewModel();

           // VerificarUsuarioLogado();

        }

        //private bool VerificarUsuarioLogado()
        //{
        //    var usuarioLogado = Login.VerificaLogin;

        //    if (usuarioLogado.UsuarioEstaLogado())
        //        return true;

        //    return false;
        //}

        private void OnClicked_Identificação(object sender, System.EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new IdentificacaoView());
        }

        private void OnClicked_Atividade(object sender, System.EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new CadastroAtividadeView());
        }

        private void OnClicked_Inventario(object sender, System.EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new CadastroInventarioView());
        }

        private void OnClicked_Perdas(object sender, System.EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new CadastroPerdasView());
        }

        private void OnClicked_btnHistorico(object sender, System.EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new CadastroHistoricoView());
        }

        private void OnClicked_Evolucao(object sender, System.EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new CadastroEvolucaoLoteView());
        }

        private void OnClicked_Expedicao(object sender, System.EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new CadastroExpedicaoView());
        }

        private void OnClicked_btnLocalizacao(object sender, System.EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new LocalizacaoView());
        }

        private void OnClicked_Ocorrencia(object sender, System.EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new CadastroOcorrencia());
        }

        private void OnClicked_btnMedicao(object sender, System.EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new CadastroMedicaoView());
        }
    }
}