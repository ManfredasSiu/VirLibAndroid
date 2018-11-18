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
	public partial class ReturnBook : ContentPage
	{

	
        ReturnBookPresenter RBP;

        public ReturnBook()
        {
            InitializeComponent();
            RBP = new ReturnBookPresenter(this);
        }

        private void ScanBarcode_Button(object sender, EventArgs e)
        {
            RBP.ScanAsync();
        }

        private void Ret_Button(object sender, EventArgs e)
        {
            RBP.Ret_Init();
        }

        private void Cancel_Button(object sender, EventArgs e)
        {
            RBP.InitCancel();
        }

    }
}