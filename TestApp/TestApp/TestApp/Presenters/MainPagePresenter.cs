using Acr.UserDialogs;
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
    class MainPagePresenter
    {
        IMainPageView MP;
        ICallAzureAPI FAC = new FaceApiCalls();

        public MainPagePresenter(IMainPageView MP)
        {
            this.MP = MP;
        }

        public void Register()
        {
           RefClass.Instance.InitRegister();
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
                    ICallAzureAPI CAA = RefClass.Instance.CAA;
                    try
                    {
                        UserDialogs.Instance.ShowLoading("Loading", MaskType.Black);
                        var username = await CAA.RecognitionAsync(file.Path);
                        try
                        {
                            
                            var WebSC = RefClass.Instance.RC;
                            var user = await WebSC.GetUserAsync(username);
                            if (user != null)
                            {


                                var UserBook = await WebSC.GetBooksReadAsync(user.UserID);
                                var BooksRea = await WebSC.GetUserBooksAsync(user.UserID);
                                RefClass.Instance.GB.CurrentUser = new UserData()
                                {
                                    UserID = user.UserID,
                                    UserEmail = user.UserEmail,
                                    UserName = user.UserName,
                                    UserStatus = user.UserStatus,
                                    UserBooks = UserBook,
                                    BooksRead = BooksRea
                                };
                                RefClass.Instance.InitMain();
                            }
                            else
                                await App.Current.MainPage.DisplayAlert("Exception", "Oops! We didn't find your face in our database. Try again", "OK");
                        }
                        catch
                        {
                            throw;
                        }
                    }
                    catch 
                    {
                        await App.Current.MainPage.DisplayAlert("Exception", "Oops! We didn't find your face in our database. Try again", "OK");
                    }
                    File.Delete(file.Path);
                    UserDialogs.Instance.HideLoading();
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
