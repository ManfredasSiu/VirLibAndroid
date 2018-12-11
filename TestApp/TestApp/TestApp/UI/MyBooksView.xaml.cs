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
	public partial class MyBooksView : ContentPage, IMyBooksView
	{
        MyBooksViewPresenter MBVP;
        public TableView YourBookss => YourBooks;
        public string codeTXT => code.Text;

        public MyBooksView()
        {
            InitializeComponent();
            MBVP = new MyBooksViewPresenter(this);
        
        }

        private void ReturnBook_Button(object sender, EventArgs e)
        {
            MBVP.ReturnInit();
        }

        private void Cancel_Button(object sender, EventArgs e)
        {
            MBVP.InitCancel();
        }

        private void MoreInfo_Button(object sender, EventArgs e)
        {
            MBVP.InitMore();
        }
    }
}