using System.Net;
using System.Web.Http;
using Database;
using Model;

namespace WebApi.Controllers
{
    public class EquipeController : ApiController
    {
        private readonly IEquipeStore _store;

        public EquipeController(IEquipeStore store)
        {
            _store = store;
        }

        public Equipe Post([FromBody]NouvelleEquipe nouvelleEquipe)
        {
            if (nouvelleEquipe.Nom == null || nouvelleEquipe.NomsDeveloppeurs.Length == 0)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var equipe = new Equipe(nouvelleEquipe.Nom,nouvelleEquipe.NomsDeveloppeurs);
            _store.Register(equipe);
            return equipe;
        }

        public Equipe Get(string id)
        {
            return _store.Get(id);
        }
    }
}