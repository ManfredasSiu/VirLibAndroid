using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{

    class RestClient
    {

        public HttpClient HttpClient { get; set; }

        public RestClient()
        {
            HttpClient = new HttpClient();
        }

        public async Task<User> GetUserAsync(string name)
        {
            var uri = new Uri("https://webservicevirlib.azurewebsites.net/api/user/getu/" + name);
            var response = await HttpClient.GetAsync(uri);
            if (!response.IsSuccessStatusCode)
            {
                throw new ArgumentException();
            }
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<User>(content);
        }

        public async Task<int> AddBookAsync(Book book)
        {
            var uri = new Uri("https://webservicevirlib.azurewebsites.net/api/book/add");

            var jsonContent = JsonConvert.SerializeObject(book, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore
            });

            var request = new HttpRequestMessage(HttpMethod.Post, uri)
            {
                Content = new StringContent(jsonContent, Encoding.UTF8, "application/json")
            };

            var response = await HttpClient.SendAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                throw new ArgumentException();
            }
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<int>(content);
        }

        public async Task<int> AddUserAsync(string name, string password, string email, int permission = 0)
        {
            var uri = new Uri("https://webservicevirlib.azurewebsites.net/api/user/add/" + name +  "/" + password + "/" + email + "/" + permission);
            var response = await HttpClient.GetAsync(uri);
            if (!response.IsSuccessStatusCode)
            {
                throw new ArgumentException();
            }
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<int>(content);
        }

        public async Task<int> searchUserAsync(string name)
        {
            var uri = new Uri("https://webservicevirlib.azurewebsites.net/api/user/search/" + name);
            var response = await HttpClient.GetAsync(uri);
            if (!response.IsSuccessStatusCode)
            {
                throw new ArgumentException();
            }
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<int>(content);
        }

        public async Task<int> BorrowBookAsync(int UserID, Book borrowThis )
        {
            var uri = new Uri("https://webservicevirlib.azurewebsites.net/api/book/borrow/" + UserID + "/" + borrowThis.BookID);
            var response = await HttpClient.GetAsync(uri);
            if (!response.IsSuccessStatusCode)
            {
                throw new ArgumentException();
            }
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<int>(content);
        }

        public async Task<int> ReturnBookAsync(int UserID, Book borrowThis)
        {
            var uri = new Uri("https://webservicevirlib.azurewebsites.net/api/book/return/" + UserID + "/" + borrowThis.BookID);
            var response = await HttpClient.GetAsync(uri);
            if (!response.IsSuccessStatusCode)
            {
                throw new ArgumentException();
            }
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<int>(content);
        }

        public async Task<List<Book>> GetUserBooksAsync(int UserID)
        {
            var uri = new Uri("https://webservicevirlib.azurewebsites.net/api/book/getub/"+UserID);
            var response = await HttpClient.GetAsync(uri);
            if (!response.IsSuccessStatusCode)
            {
                throw new ArgumentException();
            }
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Book>>(content);
        }

        public async Task<List<Book>> GetBooksReadAsync(int UserID)
        {
            var uri = new Uri("https://webservicevirlib.azurewebsites.net/api/book/getbr/" + UserID);
            var response = await HttpClient.GetAsync(uri);
            if (!response.IsSuccessStatusCode)
            {
                throw new ArgumentException();
            }
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Book>>(content);
        }

        public async Task<List<Book>> GetABAsync()
        {
            var uri = new Uri("https://webservicevirlib.azurewebsites.net/api/book/getab");
            var response = await HttpClient.GetAsync(uri);
            if (!response.IsSuccessStatusCode)
            {
                throw new ArgumentException();
            }
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Book>>(content);
        }
    }
}
