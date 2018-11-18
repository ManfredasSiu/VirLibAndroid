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

        public void InitCancel()
        {
            Application.Current.MainPage = new NavigationPage(new LibraryView());
        }

        public async System.Threading.Tasks.Task ScanAsync()
        {
            await CrossMedia.Current.Initialize();
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                //Directory = "LoginFace",
                //Name = "Face"
            });

            //Barcode scanner
            Application.Current.MainPage = new NavigationPage(new LibraryView());

        }
    }
}
