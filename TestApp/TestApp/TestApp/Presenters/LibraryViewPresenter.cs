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
            
            var TS = new TableSection("Knyga");
            TS.Add(new TextCell() { Text = "Autorius" });
            TS.Add(new TextCell() { Text = "Žanras" });
            TS.Add(new TextCell() { Text = "000011" });
            LV.DataBookss.Root.Add(TS);
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
