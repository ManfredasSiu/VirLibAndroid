using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp
{
    public class UserData : User
    {
        List<Book> UserBooks = new List<Book>();
        List<Book> BooksRead = new List<Book>();
    }
}
