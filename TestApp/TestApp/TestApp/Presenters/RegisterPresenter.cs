using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TestApp
{
    class RegisterPresenter
    {
        IRegisterView R;
        public RegisterPresenter(IRegisterView R)
        {
            this.R = R;
        }

        public async void CreateUser(String name, String password, String email)
        {
            await CrossMedia.Current.Initialize();

            var file = CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Register",
                Name = "Face"
            });
            //New task
            //DetectFace
            //CreateUser in DB
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
