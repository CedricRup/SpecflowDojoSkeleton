using System;
using Model;
using RestSharp;

namespace ApiClient
{
    public class ApiClient
    {
        public Dummy GetDummy()
        {
            var client = new RestClient {BaseUrl = new Uri("http://localhost:12345/api")};
            var restRequest = new RestRequest("Dummy",Method.GET) {RequestFormat = DataFormat.Json};
            return  client.Execute<Dummy>(restRequest).Data;
    
        }
    }
}
