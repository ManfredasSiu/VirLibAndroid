using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ZXing.Mobile;

namespace TestApp
{
    class BorrowBookPresenter
    {

        IBorrowBview BB;
        public BorrowBookPresenter(IBorrowBview BB)
        {
            this.BB = BB;
            
        }

        public void InitBor()
        {
            //some code to change cuurentuserbooks and etc.
        }

        public async void InitCancel()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public async System.Threading.Tasks.Task ScanAsync()
        {
            var scanner = new MobileBarcodeScanner();

            var result = await scanner.Scan();

            if (result != null)
                await App.Current.MainPage.DisplayAlert("Barcode", result.ToString(), "OK");

            //Barcode scanner

        }
    }
}
