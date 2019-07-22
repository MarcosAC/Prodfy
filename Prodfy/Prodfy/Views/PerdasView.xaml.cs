using Prodfy.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prodfy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PerdasView : ContentPage
	{
		public PerdasView ()
		{
			InitializeComponent ();

            NavigationPage.SetHasBackButton(this, false);

            BindingContext = new PerdasViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            ((PerdasViewModel)BindingContext).RefreshCommand.Execute(null);
        }

        private void OnItemSelect(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
                ((PerdasViewModel)BindingContext).SelecionarPerdaCommand.Execute(e.SelectedItem);

            listViewPerdas.SelectedItem = null;
        }
    }
}