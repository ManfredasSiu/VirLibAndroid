using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TestApp
{
    class BorrowBookPresenter
    {
        BorrowBook BB;

        public BorrowBookPresenter(BorrowBook BB)
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
            await CrossMedia.Current.Initialize();
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
            });

            //Barcode scanner

        }
    }
}
