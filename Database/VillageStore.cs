using System.Linq;
using Model;

namespace Database
{
    public class VillageStore : Store<Village>, IVillageStore
    {
        public Village Get(string nom)
        {
            return GetAll().FirstOrDefault(p => p.NomVillage == nom);
        }
    }
}