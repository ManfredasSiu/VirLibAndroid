using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TestApp
{
    class ReturnBookPresenter
    {
        IReturnBookView RB;

        public ReturnBookPresenter(IReturnBookView RB)
        {
            this.RB = RB;
        }


        public void Ret_Init()
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
                //Directory = "LoginFace",
                //Name = "Face"
            });

            //Barcode scanner
            //Application.Current.ReturnBook = new NavigationPage(new MyBooksView());

        }
    }
}
