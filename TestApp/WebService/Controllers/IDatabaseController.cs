using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebService.Controllers
{
    interface IDatabaseController
    {
        IHttpActionResult AddBook([FromBody]BookInfo AddThis);

        IHttpActionResult AddUser(String name, String Password, String email, int Permission);

        IHttpActionResult SearchUser(string name);

        IHttpActionResult GetUser(string name);

        IHttpActionResult ReturnBook(int BookID, int UserID);

        IHttpActionResult GetAllUserBooks(int UserID);

        IHttpActionResult GetAllBooksRead(int UserID);

        IHttpActionResult BorrowBook(int BookID, int UserID);

        IHttpActionResult GetAllBooks();
    }
}
