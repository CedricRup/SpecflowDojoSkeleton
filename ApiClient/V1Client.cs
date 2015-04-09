using System;
using Model;
using RestSharp;
using WebApi.Controllers;

namespace ApiClient
{
    public class V1Client
    {
        private readonly RestClient _client;

        public V1Client(Uri adresse)
        {
            _client = new RestClient {BaseUrl = adresse};
        }

        public Dummy GetDummy()
        {
            var restRequest = new RestRequest("Dummy",Method.GET) {RequestFormat = DataFormat.Json};
            return  _client.Execute<Dummy>(restRequest).Data;
        }

        public IRestResponse NouvelleEquipe(string nomEquipe, string[] nomsMembres)
        {
            var restRequest = new RestRequest("Equipe", Method.POST) { RequestFormat = DataFormat.Json };
            restRequest.AddBody(new NouvelleEquipe(nomEquipe, nomsMembres));
            return _client.Execute(restRequest);
        }
    }
}
