using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CPlanner.Client
{
    public class BaseWebClient
    {
        public  HttpClient Client = new HttpClient();

        public BaseWebClient()
        {
            Client.BaseAddress = new Uri("https://plannersp.azurewebsites.net/api/");
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");

        }
    }
}