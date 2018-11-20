using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

using Xamarin.Forms;


namespace TestApp
{
    class RegisterPresenter
    {
        Register R;
        public event EventHandler<WrongInputEventArgs> WrongInput;

        public RegisterPresenter(Register R)
        {
            this.R = R;
        }

        public async System.Threading.Tasks.Task CreateUserAsync()
        {
            if (CheckTheEntries(R.name, R.password, R.email) != 0)
            {
                OnWrongInput(new WrongInputEventArgs { ErrorCode = CheckTheEntries(R.name, R.password, R.email) });
                return;
            }

            await CrossMedia.Current.Initialize();

            var file = CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Register",
                Name = "Face"
            });
            //New task
            //DetectFace
            //CreateUserAsync in DB
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public int CheckTheEntries(String name, String password, String email) //Security blokai Entry atzvilgiu
        {
            var noSpecials = new System.Text.RegularExpressions.Regex("^[a-zA-Z0-9]{2 ,}$"); // {2 ,} Matches the previous element at least 2 times.
            var correctEmail = new System.Text.RegularExpressions.Regex("^[_a-z0-9-]+(.[a-z0-9-]+)@[a-z0-9-]+(.[a-z0-9-]+)*(.[a-z]{2,4})$"); 
            var correctPassword = new System.Text.RegularExpressions.Regex("^([a-z]+[A-Z]+[0-9]+){6 ,}$");
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
            else if (!correctPassword.IsMatch(password))
            {
                return 5;
            }
            else if (!correctEmail.IsMatch(email))
            {
                return 6;
            }
            /*
            else if (DB.SearchUser(name) == 2)
            {
                return 7;
            }
            */
            return 0;
        }

        protected virtual void OnWrongInput(WrongInputEventArgs e)
        {
            WrongInput?.Invoke(this, e); //Iššaukiamas eventas, jei subscriberių != null
        }
    }
}
