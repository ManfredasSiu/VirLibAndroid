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
	public partial class AddBook : ContentPage
	{
        AddBookPresenter ABP;

        public AddBook()
        {
            InitializeComponent();
            ABP = new AddBookPresenter(this);
        }


        private void ScanBarcode_Button(object sender, EventArgs e)
        {
            ABP.ScanInit();
        }

        private void Cancel_Button(object sender, EventArgs e)
        {
            //ABP.ScanInit();
        }
    }
}