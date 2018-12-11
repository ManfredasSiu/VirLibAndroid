using System;
using System.Collections.Generic;
using System.Text;
using TestApp.Data;
using TestApp.Views;

namespace TestApp.Presenters
{
    class StatisticsPresenter
    {

        IStatisticsView SW;
        Statistics ST;

        public StatisticsPresenter(IStatisticsView SW)
        {
            this.SW = SW;
            RefClass.Instance.RC.DataAdded += (Object sender, EventArgs e) => { RenewStats(); };
            RenewStats();
        }

        public void RenewStats()
        {
            this.ST = RefClass.Instance.CreateStatistics();
            ST.Calculate(RefClass.Instance.GB.CurrentUser);
            SW.CrimeBookTxt = ST.BooksReadCr.ToString();
            SW.CrimePagesTxt = ST.PagesReadCr.ToString();
            SW.OABookTxt = ST.BooksRead.ToString();
            SW.OAPagesTxt = ST.PagesRead.ToString();
            SW.HorrorBookTxt = ST.BooksReadH.ToString();
            SW.HorrorPagesTxt = ST.PagesReadH.ToString();
            SW.DocBookTxt = ST.BooksReadD.ToString();
            SW.DocPagesTxt = ST.PagesReadD.ToString();
            SW.ComedyBookTxt = ST.BooksReadCo.ToString();
            SW.ComedyPagesTxt = ST.PagesReadCo.ToString();
        }

    }
}
