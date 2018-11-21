using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace WebService.Controllers
{
    /// <summary>
    /// Summary description for Database
    /// </summary>
    /// 
    public class UserInfo
    {
        public int UserID
        {
            get;
            set;
        }
        public string UserName
        {
            get;
            set;
        }
        public string UserStatus
        {
            get;
            set;
        }
        public string UserEmail
        {
            get;
            set;
        }
    }

    public class BookInfo
    {
        public int BookID
        {
            get;
            set;
        }
        public string BookName
        {
            get;
            set;
        }
        public string BookPressname
        {
            get;
            set;
        }
        public string BookGenre
        {
            get;
            set;
        }
        public int BookQuantity
        {
            get;
            set;
        }
        public int BookPages
        {
            get;
            set;
        }
        public string BookAuthor
        {
            get;
            set;
        }
        public string BookCode
        {
            get;
            set;
        }
    }
    
    public class DatabaseController : ApiController
    {

        DataClasses1DataContext db = new DataClasses1DataContext();
        /// <inheritdoc/>
        [HttpGet]
        [Route("api/database/helloworld")]
        public IHttpActionResult HelloWorld()
        {
            var userObj = new UserInfo()
            {
                UserID = 1,
                UserName = "Manfredas",
                UserStatus = "1"
            };
            return Json(userObj);
        }
        /// <inheritdoc/>
        [HttpPost]
        [Route("api/book/add")]
        public IHttpActionResult AddBook([FromBody]BookInfo AddThis)
        {
            try
            {
                Book book = new Book();
                book.Name = AddThis.BookName;
                book.Author = AddThis.BookAuthor;
                book.Press = AddThis.BookPressname;
                book.Barcode = AddThis.BookCode;
                book.Genre = AddThis.BookGenre;
                book.Pages = AddThis.BookPages;
                book.Quantity = AddThis.BookQuantity;
                db.Books.InsertOnSubmit(book);
                db.SubmitChanges();
                return Json(0);
            }
            catch (SqlException e)
            {
                return Json(e.Message);
            }
        }
        /// <inheritdoc/>
        [HttpGet]
        [Route("api/user/add/{name}/{Password}/{email}/{Permission}")]
        public IHttpActionResult AddUser(String name, String Password, String email, int Permission)
        {
            try
            {
                string s = Convert.ToString(Permission);
                User user = new User();
                user.Name = name;
                user.Password = Password;
                user.Email = email;
                user.Permission = s;
                db.Users.InsertOnSubmit(user);
                db.SubmitChanges();
                return Json(0);
            }
            catch (SqlException e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <inheritdoc/>
        [HttpGet]
        [Route("api/user/search/{name}")]
        public IHttpActionResult SearchUser(string name)
        {
            try
            {
                var naudotojas = from u in db.Users
                                 where u.Name == name
                                 select u;
                if (naudotojas.ToArray().Length != 0) { return Json(2); }
                return Json(0);
            }
            catch (SqlException e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <inheritdoc/>
        [HttpGet]
        [Route("api/user/getu/{name}")]
        public IHttpActionResult GetUser(string name)
        {
            try
            {
                var naudotojas = from u in db.Users
                                 where u.Name == name
                                 select u;
                if (naudotojas.ToArray().Length > 0)
                {
                    UserInfo user = new UserInfo();
                    foreach (var item in naudotojas)
                    {
                        user.UserID = item.Id;
                        user.UserName = item.Name;
                        user.UserEmail = item.Email;
                        user.UserStatus = item.Permission;
                    }
                    return Json(user);
                }
                else
                    return BadRequest();
            }
            catch (SqlException e)
            {
                return BadRequest(e.Message);
            }

        }
        /// <inheritdoc/>
        [HttpGet]
        [Route("api/book/return/{UserID}/{BookID}")]
        public IHttpActionResult ReturnBook(int BookID, int UserID)
        {
            try
            {
                var knyga = from u in db.UserBooks
                            where u.UserID == UserID && u.BookID == BookID
                            select u;
                foreach (var item in knyga)
                {
                    db.UserBooks.DeleteOnSubmit(item);
                }
                db.SubmitChanges();
                BooksRead book = new BooksRead();
                book.UserID = UserID;
                book.BookID = BookID;
                db.BooksReads.InsertOnSubmit(book);
                db.SubmitChanges();
                var knygos = from u in db.Books
                             where u.Id == BookID
                             select u;
                foreach (var item in knygos)
                {
                    item.Quantity++;
                }
                db.SubmitChanges();
                return Json(0);
            }
            catch (SqlException e)
            {
                return Json(1);
            }
        }
        /// <inheritdoc/>
        [HttpGet]
        [Route("api/book/getub/{UserID}")]
        public IHttpActionResult GetAllUserBooks(int UserID)
        {
            try
            {
                var knygos = from u in db.UserBooks
                             join g in db.Books on u.BookID equals g.Id
                             where u.UserID == UserID
                             select g;

                List<BookInfo> bookIDList = new List<BookInfo>();
                foreach (var item in knygos)
                {
                    BookInfo book = new BookInfo();
                    book.BookID = item.Id;
                    book.BookName = item.Name;
                    book.BookAuthor = item.Author;
                    book.BookPressname = item.Press;
                    book.BookCode = item.Barcode;
                    book.BookGenre = item.Genre;
                    book.BookPages = item.Pages;
                    book.BookQuantity = item.Quantity;
                    bookIDList.Add(book);
                }
                return Json(bookIDList);
            }
            catch (SqlException e)
            {
                return BadRequest(e.Message);
            }

        }
        /// <inheritdoc/>
        [HttpGet]
        [Route("api/book/getbr/{UserID}")]
        public IHttpActionResult GetAllBooksRead(int UserID)
        {
            try
            {
                var knygos = from u in db.BooksReads
                             join g in db.Books on u.BookID equals g.Id
                             where u.UserID == UserID
                             select g;

                List<BookInfo> bookIDList = new List<BookInfo>();
                foreach (var item in knygos)
                {
                    BookInfo book = new BookInfo();
                    book.BookID = item.Id;
                    book.BookName = item.Name;
                    book.BookAuthor = item.Author;
                    book.BookPressname = item.Press;
                    book.BookCode = item.Barcode;
                    book.BookGenre = item.Genre;
                    book.BookPages = item.Pages;
                    book.BookQuantity = item.Quantity;
                    bookIDList.Add(book);
                }
                return Json(bookIDList);
            }
            catch (SqlException e)
            {
                return Json(e.Message);
            }
        }
        /// <inheritdoc/>
        [HttpGet]
        [Route("api/book/borrow/{UserID}/{BookID}")]
        public IHttpActionResult BorrowBook(int BookID, int UserID)
        {
            try
            {
                UserBook book = new UserBook();
                book.UserID = UserID;
                book.BookID = BookID;
                db.UserBooks.InsertOnSubmit(book);
                db.SubmitChanges();
                var knygos = from u in db.Books
                             where u.Id == BookID
                             select u;
                foreach (var item in knygos)
                {
                    item.Quantity--;
                }
                db.SubmitChanges();
                return Json(0);
            }
            catch (SqlException e)
            {
                return BadRequest(e.Message);
            }
        }
        /// <inheritdoc/>
        [HttpGet]
        [Route("api/book/getab")]
        public IHttpActionResult GetAllBooks()
        {
            try
            {
                var knygos = from u in db.Books
                             select u;
                List<BookInfo> templist = new List<BookInfo>();
                foreach (var item in knygos)
                {
                    BookInfo book = new BookInfo();
                    book.BookID = item.Id;
                    book.BookName = item.Name;
                    book.BookAuthor = item.Author;
                    book.BookPressname = item.Press;
                    book.BookCode = item.Barcode;
                    book.BookGenre = item.Genre;
                    book.BookPages = item.Pages;
                    book.BookQuantity = item.Quantity;
                    templist.Add(book);
                }
                return Json(templist);
            }
            catch (SqlException e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
