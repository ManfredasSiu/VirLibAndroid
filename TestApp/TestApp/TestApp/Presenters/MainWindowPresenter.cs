using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Plugin.SpeechRecognition;
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
            RefClass.Instance.RC.DataAdded += LoadData;
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

        private async void LoadData(Object sender, EventArgs e)
        {
            RefClass.Instance.GB.allBooks = await RefClass.Instance.RC.GetABAsync();
            RefClass.Instance.GB.CurrentUser.UserBooks = await RefClass.Instance.RC.GetUserBooksAsync(RefClass.Instance.GB.CurrentUser.UserID);
            RefClass.Instance.GB.CurrentUser.BooksRead = await RefClass.Instance.RC.GetBooksReadAsync(RefClass.Instance.GB.CurrentUser.UserID);
        }

        public void StatsInitAsync()
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
