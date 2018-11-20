using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TestApp
{
    public partial class MainPage : ContentPage, IMainPageView
    {

        MainPagePresenter MP;

        public MainPage()
        {
            InitializeComponent();
            MP = new MainPagePresenter(this);
        }

       

        private void Login_button(object sender, EventArgs e)
        {
            MP.LoginAsync();
        }

        private void Register_button(object sender, EventArgs e)
        {
            MP.Register();
        }
    }
}
