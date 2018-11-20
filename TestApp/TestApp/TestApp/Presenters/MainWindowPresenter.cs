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
