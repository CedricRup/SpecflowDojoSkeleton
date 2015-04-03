using System.Net;
using System.Web.Http;
using Model;

namespace WebApi.Controllers
{
    public class EquipeController
    {
        public Equipe Post(string nom, string[] nomsDeveloppeurs)
        {
            if (nom == null || nomsDeveloppeurs.Length == 0)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            return new Equipe(nom,nomsDeveloppeurs);
        }
    }
}