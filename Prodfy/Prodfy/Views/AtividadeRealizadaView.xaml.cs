using Prodfy.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prodfy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AtividadeRealizadaView : ContentPage
	{
		public AtividadeRealizadaView ()
		{
			InitializeComponent ();

            NavigationPage.SetHasBackButton(this, false);

            BindingContext = new AtividadeViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            BindingContext = new AtividadeViewModel();
            ((AtividadeViewModel)BindingContext).RefreshCommand.Execute(null);
        }

        private void OnItemSelect(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
                ((AtividadeViewModel)BindingContext).SelecinarAtividadeCommand.Execute(e.SelectedItem);

                listViewAtividades.SelectedItem = null;
        }
    }
}