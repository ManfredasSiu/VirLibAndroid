using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestApp.Connection
{
    interface IRest
    {
        event EventHandler DataAdded;

        HttpClient HttpClient { get; set; }

        Task<User> GetUserAsync(string name);

        Task<int> AddBookAsync(Book book);

        Task<int> AddUserAsync(string name, string password, string email, int permission = 0);

        Task<int> searchUserAsync(string name);

        Task<int> BorrowBookAsync(int UserID, Book borrowThis);

        Task<int> ReturnBookAsync(int UserID, Book borrowThis);

        Task<List<Book>> GetUserBooksAsync(int UserID);

        Task<List<Book>> GetBooksReadAsync(int UserID);

        Task<List<Book>> GetABAsync();
    }
}
