using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TestApp
{
    class LibraryViewPresenter
    {
        ILibraryView LV;

        public LibraryViewPresenter(ILibraryView LV)
        {
            this.LV = LV;
        }

        public void AddInit()
        {
           Application.Current.MainPage.Navigation.PushAsync(new AddBook());
        }

        public void BorrowInit()
        {
            Application.Current.MainPage.Navigation.PushAsync(new BorrowBook());
        }
    }
}
