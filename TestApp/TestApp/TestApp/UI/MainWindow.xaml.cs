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
	public partial class MainWindow : ContentPage, IMainWindowView
	{
        MainWindowPresenter MWP;
		public MainWindow ()
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