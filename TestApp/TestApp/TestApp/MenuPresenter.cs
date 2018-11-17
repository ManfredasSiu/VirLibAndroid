using Plugin.Media;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TestApp
{
    class MenuPresenter
    {
        MainPage MP;

        public MenuPresenter(MainPage MP)
        {
            this.MP = MP;
        }

        public void Register()
        {
            Application.Current.MainPage.Navigation.PushAsync(new Register());
        }

        public async System.Threading.Tasks.Task LoginAsync()
        {
            await CrossMedia.Current.Initialize();
            var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Storage);
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await App.Current.MainPage.DisplayAlert("No Camera", "No camera available.", "OK");
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "LoginFace",
                Name = "Face"
            });

            //Face Recognition
            Application.Current.MainPage = new NavigationPage(new View1());

        }
        
    }
}
