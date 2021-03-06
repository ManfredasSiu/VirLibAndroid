﻿using Acr.UserDialogs;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace TestApp
{
    class AddBookPresenter
    {
        IAddBookview AB;

        public AddBookPresenter(IAddBookview AB)
        {
            this.AB = AB;
        }

        public async System.Threading.Tasks.Task ScanAsync()
        {
            await CrossMedia.Current.Initialize();
            var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
            {
                Directory = "Barcode",
                Name = "code"
            });
            File.Delete(file.Path);
        }

        public async void InitCancel()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public async void InitAdd()
        {
            if ((CheckTBs(AB.nameTXT, AB.authTXT, AB.pressnameTXT, AB.pagesTXT, AB.genreTXT, AB.quantityTXT, AB.codeTXT) != 0))
                return;

            Book book = new Book()
            {
                BookID = 1,
                BookName = AB.nameTXT,
                BookPressname = AB.pressnameTXT,
                BookGenre = AB.genreTXT,
                BookQuantity = int.Parse(AB.quantityTXT),
                BookPages = int.Parse(AB.pagesTXT),
                BookAuthor = AB.authTXT,
                BookCode = AB.codeTXT
            };
            RefClass.Instance.GB.allBooks.Add(book);
            var WebSC = RefClass.Instance.RC;
            try
            {
                UserDialogs.Instance.ShowLoading("Checking data", MaskType.Black);
                await WebSC.AddBookAsync(book);
                await App.Current.MainPage.DisplayAlert("Congratulations", "Book is added", "OK");
                UserDialogs.Instance.HideLoading();
            }
            catch (Exception ex){ Console.WriteLine(ex.Message); UserDialogs.Instance.HideLoading(); }
            
        }
        //tikrina ar add book lakai atitinka salygas ir knyga galima prideti
        public int CheckTBs(string name, string auth, string pressname, string pages, string genre, string quantity, string code)  //Tikrinama ar texfieldai visi uzpildyti ir ar uzpildyti legaliai
        {
            String[] TBs = {name, auth, pressname, pages, genre, quantity, code };
            var noSpecials = new System.Text.RegularExpressions.Regex("^[a-zA-Z0-9]*$"); //Regexas ivedimui be specealiu simboliu
            foreach (string tb in TBs)
            {
                if (tb == null || tb.Replace(" ", "") == "")
                    return 1;
                else if (!noSpecials.IsMatch(tb.Replace(" ", "")))
                    return 3;
            }
            try
            {
                int.Parse(quantity);
                int.Parse(pages);
            }
            catch
            {
                return 2;
            }
            return 0;
        }
    }
}
