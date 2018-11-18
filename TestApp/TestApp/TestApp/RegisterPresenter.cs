using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TestApp
{
    class RegisterPresenter
    {
        Register R;
        public event EventHandler<WrongIputEventArgs> WrongInput;

        public RegisterPresenter(Register R)
        {
            this.R = R;
        }

        public async void CreateUser()
        {
            if (CheckTheEntries(R.name, R.password, R.email) != 0)
            {
                OnWrongInput(new WrongIputEventArgs { ErrorCode = CheckTheEntries(R.name, R.password, R.email) });
            }

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

        public int CheckTheEntries(String name, String password, String email) //Security blokai Entry atzvilgiu
        {
            var noSpecials = new System.Text.RegularExpressions.Regex("^[a-zA-Z0-9]*$");
            var correctEmail = new System.Text.RegularExpressions.Regex("^[_a-z0-9-]+(.[a-z0-9-]+)@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$"); //Pasiai6kinti dar regex
            if (name.Replace(" ", "") == "")
            {
                return 1;
            }
            else if (password.Replace(" ", "") == "")
            {
                return 2;
            }
            else if (email.Replace(" ", "") == "")
            {
                return 3;
            }
            else if (!noSpecials.IsMatch(name))
            {
                return 4;
            }
            else if (!correctEmail.IsMatch(email))
            {
                //rase event
                return 5;
            }
            /* 
            //Patikrina ar nėra jau tokio userio + emailo
            else if (DB.SearchUser(name) == 2)
            {
                return 6;
            }
            */
            return 0;
        }


        protected virtual void OnWrongInput(WrongIputEventArgs e)
        {
            EventHandler<WrongIputEventArgs> handler = WrongInput;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
