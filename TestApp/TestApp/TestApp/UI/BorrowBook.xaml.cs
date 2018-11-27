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
	public partial class BorrowBook : ContentPage, IBorrowBview
	{
        BorrowBookPresenter BBP;

        public string codeTXT => code.Text;

        public BorrowBook()
        {
            InitializeComponent();
            BBP = new BorrowBookPresenter(this);
        }

        public void Cancel_Button(object sender, EventArgs e)
        {
            BBP.InitCancel();
        }

        public async void ScanBarcode_Button(object sender, EventArgs e)
        {
            await BBP.ScanAsync();
        }
        public void Bor_Button(object sender, EventArgs e)
        {
            BBP.InitBor();
        }

    }
}