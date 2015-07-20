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

        public IRestResponse NouveauVillage(string nom, string[] nomsMembres)
        {
            var restRequest = new RestRequest("Village", Method.POST) { RequestFormat = DataFormat.Json };
            restRequest.AddBody(new NouveauVillage(nom, nomsMembres));
            return _client.Execute(restRequest);
        }

        public IRestResponse NouveauRituel(NouveauRituel rituel)
        {
            var restRequest = new RestRequest("Rituel", Method.POST) { RequestFormat = DataFormat.Json };
            restRequest.AddBody(rituel);
            return _client.Execute(restRequest);
        }

        public IRestResponse AffecterVillage(string village, string projet)
        {
            var restRequest = new RestRequest("AffectationVillage", Method.POST) { RequestFormat = DataFormat.Json };
            restRequest.AddBody(new AffectationVillage{NomVillage = village,NomRituel = projet});
            return _client.Execute(restRequest);
        }

        public IRestResponse PosterPlanAction(PlanAction planAction)
        {
            var restRequest = new RestRequest("PlanAction", Method.POST) { RequestFormat = DataFormat.Json };
            restRequest.AddBody(planAction);
            return _client.Execute(restRequest);
        }

        public IRestResponse<RituelJson> RecupererRituel(string projet)
        {
            var restRequest = new RestRequest("Rituel/{nomRituel}", Method.GET) { RequestFormat = DataFormat.Json };
            restRequest.AddParameter("nomRituel", projet, ParameterType.UrlSegment);
            return _client.Execute<RituelJson>(restRequest);
        }
    }
}
