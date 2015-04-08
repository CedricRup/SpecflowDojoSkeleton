using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class Equipe
    {   
        public Equipe(string nomEquipe, params string[] nomDeveloppeurs)
        {
            NomEquipe = nomEquipe;
            Developpeurs = nomDeveloppeurs.Select(nomDev => new Developpeur(nomDev)).ToList();
        }

        public string NomEquipe { get; private set; }
        public List<Developpeur> Developpeurs { get; private set; }
        public string ProjectId { get; private set; }

        public void PriseEnChargeProjet(string projetId)
        {
            ProjectId = projetId;
        }
    }
}