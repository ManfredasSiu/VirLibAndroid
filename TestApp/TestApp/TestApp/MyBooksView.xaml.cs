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
	public partial class MyBooksView : ContentPage
	{
        MyBooksViewPresenter MBVP;
        public MyBooksView()
        {
            InitializeComponent();
            MBVP = new MyBooksViewPresenter(this);
        }

        private void ReturnBook_Button(object sender, EventArgs e)
        {
            MBVP.ReturnInit();
        }
    }
}