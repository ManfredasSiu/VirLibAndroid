using TestApp.Connection;
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

        public IRest RC = new RestClient();

        private VoiceRecognition VR = new VoiceRecognition();

        public ICallAzureAPI CAA = new FaceApiCalls();

        //UI
        object padlock2 = new object();

        public void InitRegister()
        {
            lock (padlock)
            {
                Application.Current.MainPage.Navigation.PushAsync(new Register());
            }
        }

        public void InitMain()
        {
            lock (padlock)
            {
                Application.Current.MainPage = new NavigationPage(new MainWindow());
            }
        }

        public void InitStatistics()
        {
            lock (padlock)
            {
                Application.Current.MainPage.Navigation.PushAsync(new StatsView());
            }
        }

        public void InitMyBooks()
        {
            lock (padlock)
            {
                Application.Current.MainPage.Navigation.PushAsync(new MyBooksView());
            }
        }

        public void InitLibrary()
        {
            lock (padlock)
            {
                Application.Current.MainPage.Navigation.PushAsync(new LibraryView());
            }
        }

        public void InitRecomended()
        {
            lock (padlock)
            {
                Application.Current.MainPage.Navigation.PushAsync(new Recommended());
            }
        }
    }
}
