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
                var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Storage);
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
                if (file != null)
                {
                    ICallAzureAPI CAA = new FaceApiCalls();
                    var checkIfNologin = await CAA.RecognitionAsync(file.Path);
                    if (checkIfNologin == null)
                    {
                        try
                        {

                            RestClient WebSC = new RestClient();
                            var username = await CAA.FaceSave(name, file.Path);
                            try
                            {
                                await WebSC.AddUserAsync(R.nameTxt, R.PassTxt, R.EmailTxt);
                                await App.Current.MainPage.DisplayAlert("User Registered", "" + username, "OK");
                                Application.Current.MainPage = new NavigationPage(new MainWindow());
                            }
                            catch
                            {
                                throw;
                            }

                        }
                        catch (Exception e)
                        {
                            await App.Current.MainPage.DisplayAlert("Exception", "" + e.Message, "OK");
                        }
                    }
                    else await App.Current.MainPage.DisplayAlert("User exists", "User already exists, try connecting", "OK");
                    File.Delete(file.Path);
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Permissions Denied", "Unable to open camera", "OK");
                return;
            }
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
