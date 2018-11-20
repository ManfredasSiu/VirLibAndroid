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
<<<<<<< HEAD

=======
        public string nameField { get => "test" ; }
        
>>>>>>> parent of 8e06e99... Prideti TableViews ir inerfeisai presenteriams
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