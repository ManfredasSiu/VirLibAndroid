using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace TestApp
{
    class MoreInfoPresenter
    {
        IMoreInfoView MIV;
        

        public MoreInfoPresenter(IMoreInfoView MIV)
        {
            this.MIV = MIV;
            LoadInfo();
        }

        public async void LoadInfo()
        {
           
            Book book = RefClass.Instance.GB.allBooks.Find(x => x.BookCode == RefClass.Instance.GB.CurrentBookCode);
            if (book != null)
            {
                var TS = new TableSection(book.BookCode);
                TS.Add(new TextCell() { Text = "Title: " + book.BookName });
                TS.Add(new TextCell() { Text = "Author: " + book.BookAuthor });
                TS.Add(new TextCell() { Text = "Genre: " + book.BookGenre });
                TS.Add(new TextCell() { Text = "Pages: " + book.BookPages.ToString() });
                TS.Add(new TextCell() { Text = "Pressname: " + book.BookPressname });
                TS.Add(new TextCell() { Text = "Quantity: " + book.BookQuantity.ToString() });
                MIV.Info_book.Root.Add(TS);
            }
            else
                await App.Current.MainPage.DisplayAlert(RefClass.Instance.GB.CurrentBookCode, "Incorrect book barcode", "OK");

        }

        public void InitCancel()
        {
            Application.Current.MainPage.Navigation.PopAsync();
        }
    }
}
