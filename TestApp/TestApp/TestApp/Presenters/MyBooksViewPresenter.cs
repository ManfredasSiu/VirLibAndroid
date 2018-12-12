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
            RefClass.Instance.RC.DataAdded += (Object sender, EventArgs e) => { LoadBooks(); };
        }
        
        public async void LoadBooks()
        {
            List<Book> list1 = new List<Book>();
            var WebSC = RefClass.Instance.RC;
            list1 = await WebSC.GetABReadAsync();
            RefClass.Instance.GB.allBooks = list1;
            List<Book> list = new List<Book>();
            list = await WebSC.GetUserBooksAsync(RefClass.Instance.GB.CurrentUser.UserID);
            MBV.YourBookss.Root.Clear();
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
