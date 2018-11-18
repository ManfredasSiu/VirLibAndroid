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
	public partial class Register : ContentPage
	{
        public string name => Nam.Text;
        public string password => Pass.Text;
        public string email => Email.Text;
        RegisterPresenter RP;
		public Register ()
		{
			InitializeComponent ();
            RP = new RegisterPresenter(this);
		}

        public void Done_button(Object sender, EventArgs e)
        {
            RP.CreateUser();
        }

        public async void Cancel_button(Object sender, EventArgs e)
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}