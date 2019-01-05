using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prodfy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ConexaoView : ContentPage
	{
		public ConexaoView ()
		{
			InitializeComponent ();
            NavigationPage.SetHasBackButton(this, false);
        }

        private void OnClicked_btnConexao(object sender, System.EventArgs e)
        {
            App.Current.MainPage.Navigation.PushAsync(new FuncoesView());
        }
    }
}