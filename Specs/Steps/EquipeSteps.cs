using System.Linq;
using ApiClient;
using TechTalk.SpecFlow;

namespace Specs.Steps
{
    [Binding]
    public class EquipeSteps
    {
        private readonly V1Client _client;

        public EquipeSteps(WebClientContext context)
        {
            _client = context.WebClient;
        }

        [Given(@"l'équipe ""(.*)"" est constituée de")]
        public void SoitLEquipeEstConstitueeDe(string nomEquipe, Table table)
        {
            var result = _client.NouvelleEquipe(nomEquipe, table.Rows.Select(r => r["Nom"]).ToArray());
        }

    }
}
