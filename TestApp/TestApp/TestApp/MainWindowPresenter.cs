 using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TestApp
{
    class MainWindowPresenter
    {
        MainWindow MW;

        public MainWindowPresenter(MainWindow MW)
        {
            this.MW = MW;
        }

        public void StatsInit()
        {
            Application.Current.MainPage.Navigation.PushAsync(new StatsView());
        }

        public void RecInit()
        {
            Application.Current.MainPage.Navigation.PushAsync(new Recommended());
        }

        public void MBooksInit()
        {
            Application.Current.MainPage.Navigation.PushAsync(new MyBooksView());

        }

        public void LibInit()
        {
            Application.Current.MainPage.Navigation.PushAsync(new LibraryView());
        }
    }
}
