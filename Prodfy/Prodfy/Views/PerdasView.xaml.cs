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

            BindingContext = new PerdasViewModel();
        }

        public PerdasViewModel ViewModel
        {
            get { return BindingContext as PerdasViewModel; }
            set { BindingContext = value; }
        }

        private void OnItemSelect(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
                ViewModel.SelecionarPerdaCommand.Execute(e.SelectedItem);

            listViewPerdas.SelectedItem = null;
        }
    }
}