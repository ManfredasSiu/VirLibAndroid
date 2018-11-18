using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TestApp
{
    class MainPagePresenter
    {
        MainPage MP;

        public MainPagePresenter(MainPage MP)
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
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "LoginFace",
                Name = "Face"
            });

            //Face Recognition
            Application.Current.MainPage = new NavigationPage(new MainWindow());

        }
        
    }
}
