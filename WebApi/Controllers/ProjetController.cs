using System.Linq;
using System.Net;
using System.Web.Http;
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

        public Projet Post(NouveauProjet nouveauProjet)
        {
            if (nouveauProjet.DateDeRelease == null || nouveauProjet.DateDeDebut == null || !nouveauProjet.Stories.Any())
            {
                throw  new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var stories = nouveauProjet.Stories.Select(s => new Story(s.Titre,s.Charge));
            var partie = new Projet(nouveauProjet.Nom,nouveauProjet.DateDeDebut.Value,nouveauProjet.DateDeRelease.Value,stories);
            _projetStore.Register(partie);
            return partie;
        }

        public Projet Get(string nom)
        {
            return _projetStore.Get(nom);
        }
    }
}