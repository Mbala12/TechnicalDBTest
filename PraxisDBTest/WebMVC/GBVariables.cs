using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace WebMVC
{
    public static class GBVariables
    {
        public static HttpClient WebApiClient = new HttpClient();

        static GBVariables()
        {
            WebApiClient.BaseAddress = new Uri("http://localhost:6014/api/");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}