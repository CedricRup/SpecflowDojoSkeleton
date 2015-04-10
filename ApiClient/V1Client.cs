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

        public IRestResponse NouveauProjet(NouveauProjet projet)
        {
            var restRequest = new RestRequest("Projet", Method.POST) { RequestFormat = DataFormat.Json };
            restRequest.AddBody(projet);
            return _client.Execute(restRequest);
        }

        public IRestResponse AffecterEquipe(string equipe, string projet)
        {
            var restRequest = new RestRequest("AffectationEquipe", Method.POST) { RequestFormat = DataFormat.Json };
            restRequest.AddBody(new AffectationEquipe{NomEquipe = equipe,NomProjet = projet});
            return _client.Execute(restRequest);
        }

        public IRestResponse PosterDaily(Daily daily)
        {
            var restRequest = new RestRequest("Daily", Method.POST) { RequestFormat = DataFormat.Json };
            restRequest.AddBody(daily);
            return _client.Execute(restRequest);
        }

        public IRestResponse<ProjetJson> RecupererProjet(string projet)
        {
            var restRequest = new RestRequest("Projet/{nomProjet}", Method.GET) { RequestFormat = DataFormat.Json };
            restRequest.AddParameter("nomProjet", projet, ParameterType.UrlSegment);
            return _client.Execute<ProjetJson>(restRequest);
        }
    }
}
