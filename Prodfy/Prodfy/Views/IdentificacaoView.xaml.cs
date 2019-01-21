using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prodfy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IdentificacaoView : ContentPage
	{
		public IdentificacaoView ()
		{
			InitializeComponent ();                   
        }

        private async void OnTapped_LeitorQR(object sender, EventArgs e)
        {
            var scanner = new ZXing.Mobile.MobileBarcodeScanner();
            var result = await scanner.Scan();

            if (result != null)               
            {               
                await DisplayAlert("Valor", $"Leitura do codigo: {result.Text}", "OK");               
            }
        }
    }
}