using System;
using System.Net.Http;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpClient client = new HttpClient();
            StringContent con = new StringContent("{ \"temp\":67.66,\"pressure\":454.435,\"humidity\":44.69}", System.Text.Encoding.UTF8, "application/json");
            client.PostAsync("http://localhost:61565/api/Weathers", con);
        }
    }
}
