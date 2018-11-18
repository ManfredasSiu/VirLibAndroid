using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

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
            Application.Current.MainPage.Navigation.PushAsync(new ReturnBook());
        }
        public void InitCancel()
        {
            Application.Current.MainPage.Navigation.PushAsync(new MainWindow());
        }

    }
}
