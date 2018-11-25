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
            RefClass.Instance.RC.DataAdded += (Object sender, EventArgs e) => { LoadLibrary(); } ;
            LoadLibrary();
        }
        

        private async void LoadLibrary()
        {
            List<Book> list = new List<Book>();
            var WebSC = RefClass.Instance.RC;
            list = await WebSC.GetABAsync();
            LV.DataBookss.Root.Clear();
            RefClass.Instance.GB.allBooks = list;
            foreach (Book book in list)
            { 
                var TS = new TableSection(book.BookName);
                TS.Add(new TextCell() { Text = book.BookAuthor });
                TS.Add(new TextCell() { Text = book.BookGenre });
                TS.Add(new TextCell() { Text = book.BookCode });
                LV.DataBookss.Root.Add(TS);
            }
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
