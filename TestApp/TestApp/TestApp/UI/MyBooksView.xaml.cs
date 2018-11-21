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
        public MyBooksView()
        {
            InitializeComponent();
            MBVP = new MyBooksViewPresenter(this);
            var TS = new TableSection("Knyga");
            TS.Add(new TextCell() { Text = "Autorius" });
            TS.Add(new TextCell() { Text = "Žanras" });
            TS.Add(new TextCell() { Text = "000011" });
            YourBooks.Root.Add(TS);
        }

        private void ReturnBook_Button(object sender, EventArgs e)
        {
            MBVP.ReturnInit();
        }

        private void Cancel_Button(object sender, EventArgs e)
        {
            MBVP.InitCancel();
        }
    }
}