using Prodfy.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prodfy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HistoricoView : ContentPage
	{
		public HistoricoView ()
		{
			InitializeComponent ();

            NavigationPage.SetHasBackButton(this, false);

            BindingContext = new HistoricoViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ((HistoricoViewModel)BindingContext).RefreshCommand.Execute(null);
        }        

        private void OnItemSelect(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
                ((HistoricoViewModel)BindingContext).SelecionarHistoricoCommand.Execute(e.SelectedItem);

            lisViewHistoricos.SelectedItem = null;
        }
    }
}