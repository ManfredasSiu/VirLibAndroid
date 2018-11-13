using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TestApp
{
    class MainWindowPresenter
    {
        View1 MW;

        public MainWindowPresenter(View1 MW)
        {
            this.MW = MW;
        }

        public void StatsInit()
        {
            Application.Current.MainPage.Navigation.PushAsync(new StatsView());
        }

        public void RecInit()
        {

        }

        public void MBooksInit()
        {

        }

        public void LibInit()
        {

        }
    }
}
