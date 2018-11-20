using Plugin.Media;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using VirtualLibrary;
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
                if(file != null)
                {
                    ICallAzureAPI CAA = new FaceApiCalls();
                    try
                    {
                        var username = await CAA.RecognitionAsync(file.Path);
                        RestClient WebSC = new RestClient();
                        try
                        {
                            var user = await WebSC.GetUserAsync(username);
                            await App.Current.MainPage.DisplayAlert("User Connected", "" + user.UserID, "OK");
                            Application.Current.MainPage = new NavigationPage(new View1());
                        }
                        catch
                        {
                            throw;
                        }
                    }
                    catch(Exception e)
                    {
                        await App.Current.MainPage.DisplayAlert("Exception", "error: " + e.Message, "OK");
                    }
                    File.Delete(file.Path);
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Permissions Denied", "Unable to open camera", "OK");
                return;
            }
        }
        
    }
}
