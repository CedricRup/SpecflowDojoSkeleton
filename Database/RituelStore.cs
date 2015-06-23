using System.Linq;
using Model;

namespace Database
{
    public class RituelStore : Store<Rituel>, IRituelStore
    {
        public Rituel Get(string nom)
        {
            return GetAll().FirstOrDefault(p => p.Nom == nom);
        }
    }
}