using System.Linq;
using System.Net;
using System.Web.Http;
using ApiClient;
using Database;
using Model;

namespace WebApi.Controllers
{
    public class ProjetController : ApiController
    {
        private readonly IProjetStore _projetStore;

        public ProjetController(IProjetStore projetStore)
        {
            _projetStore = projetStore;
        }

        public ProjetJson Post(NouveauProjet nouveauProjet)
        {
            if (nouveauProjet.DateDeRelease == null || nouveauProjet.DateDeDebut == null || !nouveauProjet.Stories.Any())
            {
                throw  new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var stories = nouveauProjet.Stories.Select(s => new Story(s.Titre,s.Charge));
            var projet = new Projet(nouveauProjet.Nom,nouveauProjet.DateDeDebut.Value,nouveauProjet.DateDeRelease.Value,stories);
            _projetStore.Register(projet);
            return ToProjetJson(projet);;
        }

        private static ProjetJson ToProjetJson(Projet projet)
        {
            return new ProjetJson
            {
                Date = projet.Date,
                DateDeRelease= projet.DateDeRelease,
                Nom= projet.Nom,
                Stories=projet.Stories.Select(s=>new StoryJson{Charge=s.Charge,Titre=s.Titre}).ToList()
            };
        }

        public ProjetJson Get(string id)
        {
            return ToProjetJson(_projetStore.Get(id));
        }
    }
}