namespace WebApi.Controllers
{
    public class NouveauVillage
    {
        private string _nom;
        private string[] _nomsVillageois;

        public NouveauVillage(string nom, string[] nomsVillageois)
        {
            _nom = nom;
            _nomsVillageois = nomsVillageois;
        }

        public string Nom
        {
            get { return _nom; }
        }

        public string[] NomsVillageois
        {
            get { return _nomsVillageois; }
        }
    }
}