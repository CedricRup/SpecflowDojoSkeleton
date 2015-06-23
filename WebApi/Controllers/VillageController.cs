using System.Net;
using System.Web.Http;
using Database;
using Model;

namespace WebApi.Controllers
{
    public class VillageController : ApiController
    {
        private readonly IVillageStore _store;

        public VillageController(IVillageStore store)
        {
            _store = store;
        }

        public Village Post([FromBody]NouveauVillage nouveauVillage)
        {
            if (nouveauVillage.Nom == null || nouveauVillage.NomsVillageois.Length == 0)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var equipe = new Village(nouveauVillage.Nom,nouveauVillage.NomsVillageois);
            _store.Register(equipe);
            return equipe;
        }

        public Village Get(string id)
        {
            return _store.Get(id);
        }
    }
}