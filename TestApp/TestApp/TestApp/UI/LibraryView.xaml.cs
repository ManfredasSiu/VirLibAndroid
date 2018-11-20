using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LibraryView : ContentPage, ILibraryView
    {
      

        LibraryViewPresenter LVP;

        public TableView DataBookss => DataBooks;

        

        public LibraryView()
        {
            InitializeComponent();
            LVP = new LibraryViewPresenter(this);
            //padaryti loada is listo AllBooks
            var TS = new TableSection("Knyga");
            TS.Add(new TextCell() { Text = "Autorius"});
            TS.Add(new TextCell() { Text = "Žanras" });
            TS.Add(new TextCell() { Text = "000011" });
            DataBooks.Root.Add(TS);
        }


        private void AddBook_Button(object sender, EventArgs e)
        {
            LVP.AddInit();
        }
        private void BorrowBook_Button(object sender, EventArgs e)
        {
            LVP.BorrowInit();
        }
    }
}