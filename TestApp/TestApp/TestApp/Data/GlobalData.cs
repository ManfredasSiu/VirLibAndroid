using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Data
{
    public class GlobalData
    {

        public UserData CurrentUser;
        public List<Book> allBooks = new List<Book>();
        public string CurrentBookCode;
    }
}
