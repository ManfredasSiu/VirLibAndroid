using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TestApp
{
    class AddBookPresenter
    {
        AddBook AB;

        public AddBookPresenter(AddBook AB)
        {
            this.AB = AB;
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
            Application.Current.MainPage = new NavigationPage(new MyBooksView());

        }

        public async void InitCancel()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
