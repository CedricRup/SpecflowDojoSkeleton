using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ApiClient;
using Database;

namespace WebApi.Controllers
{
    public class AffectationVillageController : ApiController
    {
        private readonly IVillageStore _villageStore;
        private readonly IRituelStore _projecStore;

        public AffectationVillageController(IVillageStore villageStore,IRituelStore projecStore)
        {
            _villageStore = villageStore;
            _projecStore = projecStore;
        }

        public HttpResponseMessage Post(AffectationVillage affectationVillage)
        {
            var projet = _projecStore.Get(affectationVillage.NomRituel);
            var village = _villageStore.Get(affectationVillage.NomVillage);
            
            if(projet == null || village == null)  return new HttpResponseMessage(HttpStatusCode.NotFound);
            village.PriseEnChargeProjet(affectationVillage.NomRituel);
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        public IEnumerable<AffectationVillage> Get()
        {
            return
                from village in _villageStore.GetAll()
                where village.RituelId != null
                select new AffectationVillage {NomVillage = village.NomVillage, NomRituel = village.RituelId};
        }
    }
}