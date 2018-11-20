using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp
{
    public class UserData
    {
        public int UserID;
        public string UserName;
        public string UserStatus;
        public string UserEmail;
        List<Book> UserBooks = new List<Book>();
        List<Book> BooksRead = new List<Book>();
    }
}
