using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TestApp
{
    interface IMyBooksView
    {
        String codeTXT { get; }
        TableView YourBookss { get; }
    }
}
