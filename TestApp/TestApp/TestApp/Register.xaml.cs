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
        public string nameField { get => "test" ; }
        
        RegisterPresenter RP;
		public Register ()
		{
			InitializeComponent ();
            RP = new RegisterPresenter(this);
		}

        public void Done_button(Object sender, EventArgs e)
        {
            RP.CreateUser(name: Nam.ToString(), password: Pass.ToString(), email:Email.ToString());
        }

        public async void Cancel_button(Object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}