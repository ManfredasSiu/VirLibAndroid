using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Data
{
    class Statistics
    {
        //--------------------
        //Overall Statistics
        public int[] GenreBooksCount; // reik 5
        public int PagesRead;//
        public int BooksRead;//
        public double PagesPerBook;
        public Book BiggestBook;
        //Horror Statistics
        public int PagesReadH;
        public int BooksReadH;
        //ComedyStatistics
        public int PagesReadCo;
        public int BooksReadCo;
        //CrimeStatistics
        public int PagesReadCr;
        public int BooksReadCr;
        //DocumentaryStatistics
        public int PagesReadD;
        public int BooksReadD;
        //ScienceStatistics
        public int PagesReadS;
        public int BooksReadS;
        //--------------------

        //Preferences
        public String PreferedGenre;
        public String PreferedPageCount;

        public void Calculate(UserData CUser)
        {
            SortBooks(CUser);
            SetThePreferences();
        }

        private void SetThePreferences()
        {
            if (PagesPerBook > 500)
                PreferedPageCount = "Storos 500+";
            else if (PagesPerBook > 200)
                PreferedPageCount = "Vidutines 200+";
            else if (PagesPerBook > 0)
                PreferedPageCount = "Plonos tarp 0 - 200 psl";
            else
            {
                PreferedPageCount = "Unknown";
                PreferedGenre = "Unknown";
                return;
            }
            GenreBooksCount = new int[5] { BooksReadH, BooksReadCo, BooksReadCr, BooksReadD, BooksReadS };
            int tempStorage = 0;
            for (int x = 0; x < 5; x++)
            {
                if (GenreBooksCount[x] > tempStorage)
                {
                    if (x == 0)
                        PreferedGenre = "Horror";
                    else if (x == 1)
                        PreferedGenre = "Comedy";
                    else if (x == 2)
                        PreferedGenre = "Crime";
                    else if (x == 3)
                        PreferedGenre = "Documentary";
                    else if (x == 4)
                        PreferedGenre = "Science";
                }
            }
        }

        private void SortBooks(UserData CUser) //Knygos isskirstomos i tam skirtus statistinius kintamuosius
        {
            foreach (Book bk in CUser.BooksRead)
            {
                BooksRead++;
                PagesRead += bk.BookPages;
                if (bk.BookGenre == "Horror")
                {
                    BooksReadH++;
                    PagesReadH += bk.BookPages;
                }
                if (bk.BookGenre == "Comedy")
                {
                    BooksReadCo++;
                    PagesReadCo += bk.BookPages;
                }
                if (bk.BookGenre == "Documentary")
                {
                    BooksReadD++;
                    PagesReadD += bk.BookPages;
                }
                if (bk.BookGenre == "Science")
                {
                    BooksReadS++;
                    PagesReadS += bk.BookPages;
                }
                if (bk.BookGenre == "Crime")
                {
                    BooksReadCr++;
                    PagesReadCr += bk.BookPages;
                }
            }
            if (BooksRead != 0)
                PagesPerBook = PagesRead / BooksRead;
            CUser.BooksRead.Sort((x, y) => x.BookPages.CompareTo(y.BookPages));
            if (CUser.BooksRead.ToArray().Length > 0)
                BiggestBook = CUser.BooksRead.ToArray()[0];
        }
    }
}
