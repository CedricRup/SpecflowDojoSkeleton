using System.Net;
using System.Web.Http;
using Database;
using Model;

namespace WebApi.Controllers
{
    public class EquipeController
    {
        private readonly IEquipeStore _store;

        public EquipeController(IEquipeStore store)
        {
            _store = store;
        }

        public Equipe Post(string nom, string[] nomsDeveloppeurs)
        {
            if (nom == null || nomsDeveloppeurs.Length == 0)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var equipe = new Equipe(nom,nomsDeveloppeurs);
            _store.Register(equipe);
            return equipe;
        }

        public Equipe Get(string id)
        {
            return _store.Get(id);
        }
    }
}