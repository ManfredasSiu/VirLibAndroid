using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Views
{
    interface IStatisticsView
    {
        String CrimeBookTxt { set; }
        String CrimePagesTxt { set; }

        String ComedyBookTxt { set; }
        String ComedyPagesTxt { set; }

        String HorrorBookTxt { set; }
        String HorrorPagesTxt { set; }

        String DocBookTxt { set; }
        String DocPagesTxt { set; }

        String OABookTxt { set; }
        String OAPagesTxt { set; }
        String AvgPagesTxt { set; }
        String BigBookTxt { set; }

    }
}
