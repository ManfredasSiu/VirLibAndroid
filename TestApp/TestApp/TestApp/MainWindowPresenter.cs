using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TestApp
{
    class MainWindowPresenter
    {
<<<<<<< HEAD
        View1 MW;

        public MainWindowPresenter(View1 MW)
=======
        MainWindow MW;

        public MainWindowPresenter(MainWindow MW)
>>>>>>> parent of 8e06e99... Prideti TableViews ir inerfeisai presenteriams
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
            Application.Current.MainPage.Navigation.PushAsync(new MyBooksView());
        }

        public void LibInit()
        {

        }
    }
}
