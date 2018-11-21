using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Register : ContentPage, IRegisterView
    {
        
        
        RegisterPresenter RP;

        public string nameTxt => Nam.Text;

        public string PassTxt => Pass.Text;

        public string EmailTxt => Email.Text;

        public Register ()
		{
			InitializeComponent ();
            RP = new RegisterPresenter(this);
            RP.WrongInput += ShowMessage; 
		}

        public void Done_button(Object sender, EventArgs e)
        {
            RP.CreateUser(name: Nam.ToString(), password: Pass.ToString(), email: Email.ToString());
        }

        public async void Cancel_button(Object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public void ShowMessage(Object sender, WrongInputEventArgs e)
        {
            string message = "";
            switch (e.ErrorCode)
            {
                case 1:
                    message = "User Field is empty";
                    break;
                case 2:
                    message = "Password Field is empty";
                    break;
                case 3:
                    message = "Email Field is empty";
                    break;
                case 4:
                    message = "User name is incorrect";
                    break;
                case 5:
                    message = "Password is incorrect"; //Slaptažodis turi būti panaudotos mažosios ir didžiosios raidės bei skaičiai ir ilgis >=6 
                    break;
                case 6:
                    message = "Email is incorrect";
                    break;
                case 7:
                    message = "This user name already exists";
                    break;
            }

            DisplayAlert("Warrning", message, "OK");
        }
    }
}