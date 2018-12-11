using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.Presenters;
using TestApp.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StatsView : ContentPage, IStatisticsView
	{
        StatisticsPresenter SP;


		public StatsView ()
		{
			InitializeComponent ();
            SP = new StatisticsPresenter(this);
		}

        public string CrimeBookTxt { set => CrimeBooks.Text += value; }
        public string CrimePagesTxt { set => CrimePages.Text += value; }
        public string ComedyBookTxt { set => ComedyBooks.Text += value; }
        public string ComedyPagesTxt { set => ComedyPages.Text += value; }
        public string HorrorBookTxt { set => HorrorBooks.Text += value; }
        public string HorrorPagesTxt { set => HorrorPages.Text += value; }
        public string DocBookTxt { set => DocBooks.Text += value; }
        public string DocPagesTxt { set => DocPages.Text += value; }
        public string OABookTxt { set => OverallBooks.Text += value; }
        public string OAPagesTxt { set => OverallPages.Text += value; }
        public string AvgPagesTxt { set => OverallAvg.Text += value; }
        public string BigBookTxt { set => OverallBig.Text += value; }
    }
}