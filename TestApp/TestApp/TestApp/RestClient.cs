using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;

namespace TestApp
{
    public enum httpVerb
    {
        GET,
        POST,
        PUT,
        DELETE
    }

    class RestClient
    {

        public HttpClient HttpClient { get; set; }
        public string endPoint { get; set; }
        public httpVerb httpMethod { get; set; }

        public RestClient()
        {
            HttpClient = new HttpClient();
        }

        public void GetUser()
        {
            var url = new Uri("https://virlibservice.azurewebsites.net/Database.asmx/GetUser");

            //HttpRequestMessage 
        }
    }
}
