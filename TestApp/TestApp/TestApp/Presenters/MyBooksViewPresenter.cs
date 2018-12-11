using System;
using System.Collections.Generic;
using System.Text;
using TestApp.UI;
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
            List<Book> list1 = new List<Book>();
            var WebSC1 = RefClass.Instance.RC;
            list1 = await WebSC1.GetABReadAsync();
            RefClass.Instance.GB.allBooks = list1;

            List<Book> list = new List<Book>();
            var WebSC = RefClass.Instance.RC;
            list = await WebSC.GetUserBooksAsync(RefClass.Instance.GB.CurrentUser.UserID);
            RefClass.Instance.GB.CurrentUser.UserBooks = list;
            foreach (Book book in list)
            {
              
                var TS = new TableSection("Code: "+book.BookCode);
                TS.Add(new TextCell() {Text = "Book name: " + book.BookName});
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

        public void InitMore()
        {
            RefClass.Instance.GB.CurrentBookCode = MBV.codeTXT;
            Application.Current.MainPage.Navigation.PushAsync(new MoreInfo());
        }

    }
}
