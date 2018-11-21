using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace TestApp
{
    class ReturnBookPresenter
    {
        IReturnBookView RB;

        public ReturnBookPresenter(IReturnBookView RB)
        {
            this.RB = RB;
        }


        public async void Ret_Init()
        {
            String barcode = RB.codeTXT;
            if (barcode == null || barcode.Replace(" ", "") == "")
            {
                await App.Current.MainPage.DisplayAlert("Exception", "The barcode field is empty", "OK");
                return;
            }
            Book book = RefClass.Instance.GB.CurrentUser.UserBooks.Find(x => x.BookCode == barcode);
            if (book != null)//(book.BookCode == barcode) //NES JEI NERA LYGU, REISKIAS FIND NERADO TOKIOS KNYGOS.LOGISKA? -- NELABAI .- Manfredas
            {
                var WebSC = RefClass.Instance.RC;
                try
                {
                    await WebSC.ReturnBookAsync(RefClass.Instance.GB.CurrentUser.UserID, book);
                    await App.Current.MainPage.DisplayAlert("Thank You", "Book is returned", "OK");
                }
                catch (Exception ex)
                { Console.WriteLine(ex.Message); }

            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Warning", "You do not have this book", "OK");
            }
        }

        public async void InitCancel()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public async System.Threading.Tasks.Task ScanAsync()
        {
            await CrossMedia.Current.Initialize();
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Barcode",
                Name = "Code"
            });

            //Barcode scanner
            //Application.Current.ReturnBook = new NavigationPage(new MyBooksView());
            File.Delete(file.Path);
        }
    }
}
