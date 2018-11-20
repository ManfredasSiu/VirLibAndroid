using System;
using System.Collections.Generic;
using System.Text;
using TestApp.Data;
using VirtualLibrary;
using Xamarin.Forms;
namespace TestApp
{
    class RefClass
    {
        //*****IFN Singleton
        private static RefClass instance = null;
        private static readonly object padlock = new object();

        public static RefClass Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new RefClass();
                    }
                    return instance;
                }
            }
        }
        //*****ENDOFSINGLETON

        //Logic

        public GlobalData GB = new GlobalData();

        public RestClient RC = new RestClient();

        public ICallAzureAPI CAA = new FaceApiCalls();

        //UI

        public void InitRegister()
        {
            Application.Current.MainPage.Navigation.PushAsync(new Register());
        }

        public void InitMain()
        {
            Application.Current.MainPage.Navigation.PushAsync(new MainWindow());
        }

        public void InitStatistics()
        {
            Application.Current.MainPage.Navigation.PushAsync(new StatsView());
        }
        public void InitMyBooks()
        {
            Application.Current.MainPage.Navigation.PushAsync(new MyBooksView());
        }
        public void InitLibrary()
        {
            Application.Current.MainPage.Navigation.PushAsync(new LibraryView());
        }
        public void InitRecomended()
        {
            Application.Current.MainPage.Navigation.PushAsync(new Recommended());
        }
    }
}
