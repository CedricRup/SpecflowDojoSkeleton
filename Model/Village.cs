using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class Village
    {   
        public Village(string nomVillage, params string[] nomVillageois)
        {
            NomVillage = nomVillage;
            Villageois = nomVillageois.Select(nom => new Villageois(nom)).ToList();
        }

        public string NomVillage { get; private set; }
        public List<Villageois> Villageois { get; private set; }
        public string RituelId { get; private set; }

        public void PriseEnChargeProjet(string rituelId)
        {
            RituelId = rituelId;
        }
    }
}