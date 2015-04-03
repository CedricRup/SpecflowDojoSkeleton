using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using Database;
using Model;

namespace WebApi.Controllers
{
    public class PartieController : ApiController
    {
        private readonly IPartieStore _partieStore;

        public PartieController(IPartieStore partieStore)
        {
            _partieStore = partieStore;
        }

        public Partie Post(NouvellePartie nouvellePartie)
        {
            if (nouvellePartie.DateDeRelease == null || nouvellePartie.DateDeDebut == null || !nouvellePartie.Stories.Any())
            {
                throw  new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var stories = nouvellePartie.Stories.Select(s => new Story(s.Titre,s.Charge));
            var partie = new Partie(nouvellePartie.DateDeDebut.Value,nouvellePartie.DateDeRelease.Value,stories);
            _partieStore.Register(partie);
            return partie;
        }

        public Partie Get(Guid id)
        {
            return _partieStore.Get(id);
        }
    }



    public class NouvellePartie
    {
        public DateTime? DateDeRelease { get; set; }
        public DateTime? DateDeDebut { get; set; }
        public StoryParam[] Stories { get; set; }
    }

    public class StoryParam
    {
        public string Titre { get; set; }
        public int Charge { get; set; }
    }
}