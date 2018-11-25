using Acr.UserDialogs;
using Plugin.Media;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TestApp.Connection;
using VirtualLibrary;
using Xamarin.Forms;

namespace TestApp
{

    class RegisterPresenter
    {
        IRest WebSC;
        IRegisterView R;

        public event EventHandler<WrongInputEventArgs> WrongInput; 

        public RegisterPresenter(IRegisterView R)
        {
            this.R = R;
            WebSC = RefClass.Instance.RC;
        }

        public async void CreateUser(String name, String password, String email)
        {
            UserDialogs.Instance.ShowLoading("Checking data", MaskType.Black);
            int check = await CheckTheEntries(R.nameTxt, R.PassTxt, R.EmailTxt);
            
            if (check != 0)
            {
                WrongInput?.Invoke(this, new WrongInputEventArgs { ErrorCode = check });
                UserDialogs.Instance.HideLoading();
                return;
            }
            UserDialogs.Instance.HideLoading();

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
                    UserDialogs.Instance.ShowLoading("Loading", MaskType.Black);
                    string checkIfNologin;
                    try
                    {
                        checkIfNologin = await CAA.RecognitionAsync(file.Path);
                    }
                    catch { checkIfNologin = null; }
                    if (checkIfNologin == null)
                    {
                        try
                        {
                            var username = await CAA.FaceSave(R.nameTxt, file.Path);
                            if (username)
                            {
                                try
                                {
                                    var WebSC = RefClass.Instance.RC;
                                    await WebSC.AddUserAsync(R.nameTxt, R.PassTxt, R.EmailTxt);
                                    await App.Current.MainPage.DisplayAlert("User Registered", "Success" , "OK");
                                    await Application.Current.MainPage.Navigation.PopAsync();
                                    
                                }
                                catch
                                {
                                    throw;
                                }
                            }
                            else
                                await App.Current.MainPage.DisplayAlert("Exception", "Oops, try again", "OK");
                        }
                        catch (Exception e)
                        {
                            await App.Current.MainPage.DisplayAlert("Exception", "" + e.Message, "OK");
                        }
                    }
                    else await App.Current.MainPage.DisplayAlert("User exists", "User already exists, try connecting", "OK");
                    File.Delete(file.Path);
                    UserDialogs.Instance.HideLoading();
                }
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Permissions Denied", "Unable to open camera", "OK");
                return;
            }
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public async Task<int> CheckTheEntries(string name, string password, string email) //Security blokai Entry atzvilgiu
        {
            
            var noSpecials = new System.Text.RegularExpressions.Regex("^[a-zA-Z0-9 ]*$"); // {2 ,} Matches the previous element at least 2 times.
            var correctEmail = new System.Text.RegularExpressions.Regex("^[_a-z0-9-]+(.[a-z0-9-]+)@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$");
            if (name == null|| name.Replace(" ", "") == "" )
            {
                return 1;
            }
            else if (password == null|| password.Replace(" ", "") == "" )
            {
                return 2;
            }
            else if ( email == null||email.Replace(" ", "") == "" )
            {
                return 3;
            }
            else if (!noSpecials.IsMatch(name))
            {
                return 4;
            }
            else if (!correctEmail.IsMatch(email))
            {
                return 6;
            }
            if (await WebSC.searchUserAsync(R.nameTxt) != 0)
            {
                return 7;
            }
            return 0;
        }
    }
}