using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiClient;
using Database;

namespace WebApi.Controllers
{
    public class AffectationEquipeController : ApiController
    {
        private readonly IEquipeStore _equipeStore;
        private readonly IProjetStore _projecStore;

        public AffectationEquipeController(IEquipeStore equipeStore,IProjetStore projecStore)
        {
            _equipeStore = equipeStore;
            _projecStore = projecStore;
        }

        public HttpResponseMessage Post(AffectationEquipe affectationEquipe)
        {
            var projet = _projecStore.Get(affectationEquipe.NomProjet);
            var equipe = _equipeStore.Get(affectationEquipe.NomEquipe);
            
            if(projet == null || equipe == null)  return new HttpResponseMessage(HttpStatusCode.NotFound);
            equipe.PriseEnChargeProjet(affectationEquipe.NomProjet);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        public IEnumerable<AffectationEquipe> Get()
        {
            return
                from equipe in _equipeStore.GetAll()
                where equipe.ProjectId != null
                select new AffectationEquipe {NomEquipe = equipe.NomEquipe, NomProjet = equipe.ProjectId};
        }
    }
}