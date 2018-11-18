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
            await App.Current.MainPage.DisplayAlert("Permissions", "" + await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage), "OK");
            if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Storage))
                await App.Current.MainPage.DisplayAlert("Permissions", "Storage Permission Needed", "OK");
            var storageStatus = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage);

            // var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Storage);
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await App.Current.MainPage.DisplayAlert("No Camera", "No camera available.", "OK");
                return;
            }
            if (storageStatus != PermissionStatus.Granted)
            {
                var results = await CrossPermissions.Current.RequestPermissionsAsync( Permission.Storage );
                if (results.ContainsKey(Permission.Storage))
                    storageStatus = results[Permission.Storage];
            }
            if (storageStatus == PermissionStatus.Granted)
            {
                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "LoginFace",
                    Name = "Face"
                });
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Permissions Denied", "Unable to open camera", "OK");
                return;
            }


            //Face Recognition
            Application.Current.MainPage = new NavigationPage(new View1());

        }
        
    }
}
