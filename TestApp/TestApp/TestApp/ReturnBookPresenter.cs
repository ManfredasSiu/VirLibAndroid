using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TestApp
{
    class ReturnBookPresenter
    {
        ReturnBook RB;

        public ReturnBookPresenter(ReturnBook RB)
        {
            this.RB = RB;
        }


        public void Ret_Init()
        {
            //some code to change cuurentuserbooks and etc.
        }

        public void InitCancel()
        {
            Application.Current.MainPage = new NavigationPage(new MyBooksView());
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
            //Application.Current.ReturnBook = new NavigationPage(new MyBooksView());

        }
    }
}
