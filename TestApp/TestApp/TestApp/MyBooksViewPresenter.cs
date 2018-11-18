using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp
{
    class MyBooksViewPresenter
    {
        MyBooksView MBV;

        public MyBooksViewPresenter(MyBooksView MBV)
        {
            this.MBV = MBV;
        }
        public void ReturnInit()
        {
            //Application.Current.MainPage.Navigation.PushAsync(new MyBooksView());
            //kitas langas
        }
    }
}
