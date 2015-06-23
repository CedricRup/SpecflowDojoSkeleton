using System.Linq;
using ApiClient;
using TechTalk.SpecFlow;

namespace Specs.Steps
{
    [Binding]
    public class VillageSteps
    {
        private readonly V1Client _client;

        public VillageSteps(WebClientContext context)
        {
            _client = context.WebClient;
        }


        [Given(@"le village '(.*)' habité par")]
        public void SoitLeVillageEstHabitePar(string nomVillage, Table table)
        {
            var result = _client.NouveauVillage(nomVillage, table.Rows.Select(r => r["Nom"]).ToArray());
        }
    }
}
