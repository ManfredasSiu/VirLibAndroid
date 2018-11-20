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
<<<<<<< HEAD:TestApp/TestApp/TestApp/View1.xaml.cs
	public partial class View1 : ContentPage
=======
	public partial class MainWindow : ContentPage
>>>>>>> parent of 8e06e99... Prideti TableViews ir inerfeisai presenteriams:TestApp/TestApp/TestApp/MainWindow.xaml.cs
	{
        MainWindowPresenter MWP;
		public View1 ()
		{
			InitializeComponent ();
            MWP = new MainWindowPresenter(this);
        }

        private void Stats_button(object sender, EventArgs e)
        {
            MWP.StatsInit();
        }

        private void MBooks_button(object sender, EventArgs e)
        {
            MWP.MBooksInit();
        }

        private void Lib_button(object sender, EventArgs e)
        {
            MWP.LibInit();
        }

        private void Rec_button(object sender, EventArgs e)
        {
            MWP.RecInit();
        }
    }
}