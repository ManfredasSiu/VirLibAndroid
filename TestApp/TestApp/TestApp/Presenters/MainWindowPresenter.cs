 using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TestApp
{
    class MainWindowPresenter
    {
        IMainWindowView MW;

        public MainWindowPresenter(IMainWindowView MW)
        {
            this.MW = MW;
            string statusas;
            statusas = RefClass.Instance.GB.CurrentUser.UserStatus;
            if (statusas == "0")
            {
                MW.StatusLabeltxt = "Status: Reader";
            }
            else
            {
                MW.StatusLabeltxt = "Status: Admin";

            }
            string vardas;
            vardas = RefClass.Instance.GB.CurrentUser.UserName;
            MW.NameLabeltxt = "Name: " + vardas;
        }

        public void StatsInit()
        {
            RefClass.Instance.InitStatistics();
        }

        public void RecInit()
        {
            RefClass.Instance.InitRecomended();
        }

        public void MBooksInit()
        {
            RefClass.Instance.InitMyBooks();
        }

        public void LibInit()
        {
            RefClass.Instance.InitLibrary();
        }
    }
}
