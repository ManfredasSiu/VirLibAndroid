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
	public partial class ReturnBook : ContentPage, IReturnBookView
    {

	
        ReturnBookPresenter RBP;

        public string codeTXT => code.Text;

        public ReturnBook()
        {
            InitializeComponent();
            RBP = new ReturnBookPresenter(this);
        }

        private async void ScanBarcode_Button(object sender, EventArgs e)
        {
            await RBP.ScanAsync();
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