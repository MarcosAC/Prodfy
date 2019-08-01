using Prodfy.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prodfy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CadastroPerdasView : ContentView
    {
		public CadastroPerdasView ()
		{
			InitializeComponent ();

            BindingContext = new AdicionarPerdasViewModel();
        }

        private void PickerEstagio_Click(object sender, FocusEventArgs e)
        {
            ((AdicionarPerdasViewModel)BindingContext).VerificarDadosPickerEstagiosCommand.Execute(null);
        }

        private void PickerPontoControle_Click(object sender, FocusEventArgs e)
        {
            ((AdicionarPerdasViewModel)BindingContext).VerificarDadosPickerPontoControleCommand.Execute(null);
        }
    }
}