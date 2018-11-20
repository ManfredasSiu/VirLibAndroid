using Plugin.Media;
using System;
using System.Collections.Generic;
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
                //Directory = "LoginFace",
                //Name = "Face"
            });

            //Barcode scanner

        }

        public async void InitCancel()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }

        public void InitAdd()
        {
           // metodas kuris kreipiasi i CheckTBs ir prideda knyga i duombaze
           //pasiimu reiksmes is lauku ir dedu i book ir pridedu prie all books
        }



        //tikrina ar add book lakai atitinka salygas ir knyga galima prideti
        public int CheckTBs(string name, string auth, string pressname, string pages, string genre, string quantity, string code)  //Tikrinama ar texfieldai visi uzpildyti ir ar uzpildyti legaliai
        {
            String[] TBs = {name, auth, pressname, pages, genre, quantity, code };
            var noSpecials = new System.Text.RegularExpressions.Regex("^[a-zA-Z0-9]*$"); //Regexas ivedimui be specealiu simboliu
            foreach (string tb in TBs)
            {
                if (tb.Replace(" ", "") == "")
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
