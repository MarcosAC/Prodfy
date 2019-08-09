using Prodfy.Models;
using Prodfy.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prodfy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CadastroPerdasView : ContentPage
    {
		public CadastroPerdasView (CarregarDadosPerdaQr dadosPerdaQr = null)
		{
			InitializeComponent ();

            NavigationPage.SetHasBackButton(this, false);

            BindingContext = new CadastroPerdasViewModel(dadosPerdaQr);            
        }        

        private void PickerLotes_Click(object sender, FocusEventArgs e)
        {
            if (PickerPontoControle.IsEnabled == false)
                PickerPontoControle.IsEnabled = true;
        }        

        private void PickerPontoControle_Click(object sender, FocusEventArgs e)
        {
            if (!((CadastroPerdasViewModel)BindingContext).VerificaPickerPontoControle())
                PickerPontoControle.IsEnabled = false;

            PickerEstagio.IsEnabled = true;
        }

        private void PickerEstagio_Click(object sender, FocusEventArgs e)
        {
            if (!((CadastroPerdasViewModel)BindingContext).VerificaPickerEstagios())
                PickerEstagio.IsEnabled = false;
            else
                PickerEstagio.IsEnabled = true;
        }
    }
}