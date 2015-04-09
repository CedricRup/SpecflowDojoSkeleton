namespace WebApi.Controllers
{
    public class NouvelleEquipe
    {
        private string _nom;
        private string[] _nomsDeveloppeurs;

        public NouvelleEquipe(string nom, string[] nomsDeveloppeurs)
        {
            _nom = nom;
            _nomsDeveloppeurs = nomsDeveloppeurs;
        }

        public string Nom
        {
            get { return _nom; }
        }

        public string[] NomsDeveloppeurs
        {
            get { return _nomsDeveloppeurs; }
        }
    }
}