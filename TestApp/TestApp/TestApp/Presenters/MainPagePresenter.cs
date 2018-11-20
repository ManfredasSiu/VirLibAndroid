﻿using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TestApp
{
    class MainPagePresenter
    {
        IMainPageView MP;

        public MainPagePresenter(IMainPageView MP)
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