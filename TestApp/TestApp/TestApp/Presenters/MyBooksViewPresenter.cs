using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TestApp
{
    class MyBooksViewPresenter
    {
        IMyBooksView MBV;

        public MyBooksViewPresenter(IMyBooksView MBV)
        {
            this.MBV = MBV;
            LoadBooks();
        }

        public async void LoadBooks()
        {

            List<Book> list = new List<Book>();
            var WebSC = RefClass.Instance.RC;
            list = await WebSC.GetUserBooksAsync(RefClass.Instance.GB.CurrentUser.UserID);
            RefClass.Instance.GB.CurrentUser.UserBooks = list;
            foreach (Book book in list)
            {
                var TS = new TableSection(book.BookName);
                TS.Add(new TextCell() { Text = book.BookAuthor });
                TS.Add(new TextCell() { Text = book.BookGenre });
                TS.Add(new TextCell() { Text = book.BookCode });
                MBV.YourBookss.Root.Add(TS);
            }
        }

        public void ReturnInit()
        {
            Application.Current.MainPage.Navigation.PushAsync(new ReturnBook());
        }

        public void InitCancel()
        {
            Application.Current.MainPage.Navigation.PopAsync();
        }

    }
}
