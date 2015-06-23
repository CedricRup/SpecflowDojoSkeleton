using System.Linq;
using System.Net;
using System.Web.Http;
using ApiClient;
using Database;
using Model;

namespace WebApi.Controllers
{
    public class RituelController : ApiController
    {
        private readonly IRituelStore _rituelStore;

        public RituelController(IRituelStore rituelStore)
        {
            _rituelStore = rituelStore;
        }

        public RituelJson Post(NouveauRituel nouveauRituel)
        {
            if (nouveauRituel.Echeance == null || nouveauRituel.DateDeDebut == null || !nouveauRituel.Actions.Any())
            {
                throw  new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var actions = nouveauRituel.Actions.Select(s => new Action(s.Intitule,s.Charge));
            var rituel = new Rituel(nouveauRituel.Nom,nouveauRituel.DateDeDebut.Value,nouveauRituel.Echeance.Value,actions);
            _rituelStore.Register(rituel);
            return ToRituelJson(rituel);;
        }

        private static RituelJson ToRituelJson(Rituel rituel)
        {
            return new RituelJson
            {
                Date = rituel.Date,
                Echeance= rituel.DateDeRelease,
                Nom = rituel.Nom,
                Actions =rituel.Actions.Select(s=>new ActionJson{Charge=s.Charge,Intitule=s.Intitule}).ToList()
            };
        }

        public RituelJson Get(string id)
        {
            return ToRituelJson(_rituelStore.Get(id));
        }
    }
}