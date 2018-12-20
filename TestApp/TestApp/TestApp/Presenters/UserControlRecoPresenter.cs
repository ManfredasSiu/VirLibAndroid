using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp;
using TestApp.Connection;
using TestApp.Data;
using VirtualLibrary.Views;

namespace VirtualLibrary.presenters
{
    public class UserControlRecoPresenter
    {
        IRest RC;
        IUControlR UCR;
        private List<Book> allBooks = new List<Book>();
        private List<Book> recoBooks = new List<Book>();
        private List<Book> randomOnes = new List<Book>();
        private String genre;
        Statistics Stats;

        public UserControlRecoPresenter(IUControlR UCR)
        {
            this.UCR = UCR;
            this.RC= RefClass.Instance.RC;
            getRecommendedBooksAsync();
            getRandomAsync();
            //UpdateTable(randomOnes);
        }

        public async Task getRecommendedBooksAsync()
        {
            Stats = RefClass.Instance.CreateStatistics();
            Stats.Calculate(RefClass.Instance.GB.CurrentUser);
            genre = Stats.PreferedGenre;
            //reik patikrint ar neskaite ir ar neskaito
            foreach (Book book in await RC.GetABAsync())
                if (book.BookGenre == genre)
                    recoBooks.Add(book); 
            foreach (Book book in recoBooks)
            {
                 var temp1 = RefClass.Instance.GB.CurrentUser.BooksRead.Find(x => x.BookID == book.BookID);
                 var temp2 = RefClass.Instance.GB.CurrentUser.UserBooks.Find(x => x.BookID == book.BookID);
                if (temp1 == null && temp2 == null)
                 {
                    allBooks.Add(new Book() { BookName = book.BookName, BookID = book.BookID, BookCode = book.BookCode });
                    //UCR.newCell = book.BookName + " " + book.BookCode;
                }
                
            }
        }

        public async Task getRandomAsync()
        {
            int index;
            Random r = new Random();
            if (allBooks.ToArray().Length <= 3)
            {
                foreach(Book item in allBooks)
                {
                    UCR.newCell = item.BookName + " " + item.BookCode;
                }
                return;
            }
            if (allBooks.ToArray().Length == 0) return;
            for (int y = 0; y < 3; y++)
            {
                index = r.Next(allBooks.ToArray().Length);

                if (randomOnes.Find(x => x.BookID == allBooks[index].BookID) == null)
                {
                    randomOnes.Add(allBooks[index]);
                    UCR.newCell = allBooks[index].BookName + " " + allBooks[index].BookCode;
                }
                else
                    y--;
            }
        }
         
    }
}