using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class Village
    {   
        public Village(string nomEquipe, params string[] nomDeveloppeurs)
        {
            NomEquipe = nomEquipe;
            Villageois = nomDeveloppeurs.Select(nomDev => new Villageois(nomDev)).ToList();
        }

        public string NomEquipe { get; private set; }
        public List<Villageois> Villageois { get; private set; }
        public string RituelId { get; private set; }

        public void PriseEnChargeProjet(string rituelId)
        {
            RituelId = rituelId;
        }
    }
}