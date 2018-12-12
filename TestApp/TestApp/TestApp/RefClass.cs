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

        public Statistics CreateStatistics()
        {
            Statistics ST = new Statistics();
            return ST;
        }

        

        //UI
        object padlock2 = new object();
        
        private IRegisterView Reg;
        private IMainWindowView MWV;
        private StatsView SW;
        private IMyBooksView MBV;
        private ILibraryView LV;
        private Recommended R;

        //UI
        private static readonly object ResLock = new object();

        public void InitRegister()
        {
            lock (ResLock)
            {
                Reg = new Register();
                Application.Current.MainPage.Navigation.PushAsync((Page)Reg);
            }
        }

        public void InitMain()
        {
            lock (ResLock)
            {
                MWV = new MainWindow();
                Application.Current.MainPage.Navigation.PushAsync((Page)MWV);
            }
        }

        public void InitStatistics()
        {
            lock (ResLock)
            {
                SW = new StatsView();
                Application.Current.MainPage.Navigation.PushAsync(SW);
            }
        }

        public void InitMyBooks()
        {
            lock (ResLock)
            {
                MBV = new MyBooksView();
                Application.Current.MainPage.Navigation.PushAsync((Page)MBV);
            }
        }

        public void InitLibrary()
        {
            lock (ResLock)
            {
                LV = new LibraryView();
                Application.Current.MainPage.Navigation.PushAsync((Page)LV);
            }
        }

        public void InitRecomended()
        {
            lock (ResLock)
            {
                    R = new Recommended();
                    Application.Current.MainPage.Navigation.PushAsync(R);
            }
        }
    }
}
