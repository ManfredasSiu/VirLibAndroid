using System;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

public class Scanner
{
    public event EventHandler<ScannedEventArgs> Scanned;
    static ZXingScannerPage scanPage;

    public async System.Threading.Tasks.Task Scan ()
    {
        string barcode = "";
        scanPage = new ZXingScannerPage();
        scanPage.OnScanResult += (result) => {
            scanPage.IsScanning = false;
            barcode = result.Text;

            //Parodo nuskenuotą barkodą
            /*
            Device.BeginInvokeOnMainThread(() => {
                Application.Current.MainPage.Navigation.PopAsync();
                Application.Current.MainPage.DisplayAlert("Scanned Barcode", result.Text, "OK");
            });
            */
        };

        await Application.Current.MainPage.Navigation.PushAsync(scanPage);
        Scanned?.Invoke(this, new ScannedEventArgs { Barcode = barcode });
    }
}

