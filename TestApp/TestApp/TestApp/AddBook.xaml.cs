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
	public partial class AddBook : ContentPage, IAddBookview
	{
        AddBookPresenter ABP;

        public string nameTXT => name.Text;

        public string authTXT => auth.Text;

        public string genreTXT => genre.Text;

        public string pagesTXT => pages.Text;

        public string quantityTXT => quantity.Text;

        public string pressnameTXT => pressname.Text;

        public string codeTXT => code.Text;

        public AddBook()
        {
            
            InitializeComponent();
            ABP = new AddBookPresenter(this);
        }


        private void ScanBarcode_Button(object sender, EventArgs e)
        {
            ABP.ScanAsync();
        }

        private void Cancel_Button(object sender, EventArgs e)
        {
            ABP.InitCancel();
        }

        private void AddBook_Button(object sender, EventArgs e)
        {
            ABP.InitAdd();
        }
    }
}