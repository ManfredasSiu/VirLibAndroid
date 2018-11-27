using Android.Content.Res;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;


namespace TestApp
{
    class BorrowBookPresenter
    {
        ZXingScannerPage scanPage;
        IBorrowBview BB;
        public BorrowBookPresenter(IBorrowBview BB)
        {
            this.BB = BB;
            
        }

        public async void InitBor()
        {
            String barcode = BB.codeTXT;
            if(barcode == null || barcode.Replace(" ", "") == "")
            {
                await App.Current.MainPage.DisplayAlert("Exception", "The barcode field is empty", "OK");
                return;
            }
            Book book = RefClass.Instance.GB.allBooks.Find(x => x.BookCode == barcode);
            Book arne = RefClass.Instance.GB.CurrentUser.UserBooks.Find(x => x.BookCode == barcode);
            
            if (arne == null && book != null)
            {
                var WebSC = RefClass.Instance.RC;
                try
                {
                    await WebSC.BorrowBookAsync(RefClass.Instance.GB.CurrentUser.UserID, book);
                    await App.Current.MainPage.DisplayAlert("Congratulations", "This book is borrowed", "OK");
                }
                catch (Exception ex)
                { Console.WriteLine(ex.Message); }

            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Warning", "You already have this book or barcode is not corrent", "OK");
            }
        }

        public async void InitCancel()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public async System.Threading.Tasks.Task ScanAsync()
        {
            scanPage = new ZXingScannerPage();
            scanPage.OnScanResult += (result) => {
                scanPage.IsScanning = false;

                //Pavaizduoja nuskenuotą barkodą
                Device.BeginInvokeOnMainThread(() => {
                    Application.Current.MainPage.Navigation.PopAsync();
                    Application.Current.MainPage.DisplayAlert("Scanned Barcode", result.Text, "OK");
                });
                //
            };

            await Application.Current.MainPage.Navigation.PushAsync(scanPage);
        }
    }
}
