using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Net.Mobile.Forms;

namespace Prodfy.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LeitorQRView : ContentPage
    {
        //ZXingScannerView zxing;

        ZXingScannerView zxing;
        ZXingDefaultOverlay overlay;
        public event EventHandler<string> BarcodeReaded;

        public LeitorQRView()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

            var options = new ZXing.Mobile.MobileBarcodeScanningOptions
            {
                AutoRotate = false,
                UseFrontCameraIfAvailable = false,
                TryHarder = true,
                PossibleFormats = new List<ZXing.BarcodeFormat>
                {
                    ZXing.BarcodeFormat.QR_CODE//ZXing.BarcodeFormat.EAN_8, ZXing.BarcodeFormat.EAN_13
                }
            };

            zxing = new ZXing.Net.Mobile.Forms.ZXingScannerView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Options = options
            };

            

            overlay = new ZXingDefaultOverlay
            {
                TopText = "Escolhe um QRCode para leitura",
                BottomText = "O Código sera lido automaticamente",
                ShowFlashButton = zxing.HasTorch, //Lanterna
            };

            overlay.FlashButtonClicked += (sender, e) =>
            {
                zxing.IsTorchOn = !zxing.IsTorchOn;
            };

            var abort = new Button
            {
                Text = "Cancelar",
                VerticalOptions = LayoutOptions.End,
                TextColor = Color.FromHex("#FFF"),
                BackgroundColor = Color.FromHex("#4F51FF")
            };

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    abort.HeightRequest = 40;
                    break;
                case Device.Android:
                    abort.HeightRequest = 50;
                    break;
            }

            abort.Clicked += (object s, EventArgs e) =>
            {
                zxing.IsScanning = false;

                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Navigation.PopModalAsync();
                });
            };

            var grid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            grid.Children.Add(zxing);
            grid.Children.Add(overlay);
            grid.Children.Add(abort);

            Content = grid;


            //zxing = new ZXingScannerView
            //{
            //    HorizontalOptions = LayoutOptions.FillAndExpand,
            //    VerticalOptions = LayoutOptions.FillAndExpand,
            //};

            //zxing.OnScanResult += (result) =>
            //    Device.BeginInvokeOnMainThread(async () => {

            //        // Stop analysis until we navigate away so we don't keep reading barcodes
            //        zxing.IsAnalyzing = false;

            //        // Show an alert
            //        await DisplayAlert("Scanned Barcode", result.Text, "OK");

            //        // Navigate away
            //        await Navigation.PopAsync();
            //    });

            //EscanerQR.Children.Add(zxing);
        }

        //public async Task CheckCameraPermission()
        //{
        //    var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);

        //    if (status != PermissionStatus.Granted)
        //    {
        //        await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Camera);
        //        var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Camera);
        //    }
        //}

        //public async Task CheckPermissions()
        //{
        //    //await CheckReadDevicePermission();

        //    await CheckCameraPermission();

        //    //await CheckStoragePermission();
        //}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //CheckPermissions().GetAwaiter();

            zxing.IsScanning = true;

            zxing.OnScanResult += (result) =>
            Device.BeginInvokeOnMainThread(async () =>
            {

                // Para a analise
                zxing.IsAnalyzing = false;

                zxing.IsScanning = true;

                BarcodeReaded?.Invoke(this, result.Text);

                await DisplayAlert("Scanned Barcode", result.Text, "OK");

            });
        }

        protected override void OnDisappearing()
        {
            zxing.IsScanning = false;

            base.OnDisappearing();
        }
    }
}