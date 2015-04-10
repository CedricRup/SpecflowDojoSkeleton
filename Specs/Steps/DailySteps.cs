using System.Linq;
using ApiClient;
using Model;
using TechTalk.SpecFlow;

namespace Specs.Steps
{
    [Binding]
    public class DailySteps
    {
        private V1Client _client;
        private Daily _daily;

        public DailySteps(WebClientContext context)
        {
            _client = context.WebClient;
        }

        [Given(@"le daily pour le projet '(.*)'")]
        public void SoitLeDailyPourLeProjet(string projet)
        {
            _daily = new Daily
            {
                Projet = projet,
                Taches = new Tache[0]

            };

        }


        [Given(@"que '(.*)' travaille sur '(.*)'")]
        public void SoitQueTravailleSur(string developpeur, string story)
        {
            _daily.Taches = _daily.Taches.Concat(new[] { new Tache { Par = developpeur, Story = story } }).ToArray();
        }


        [When(@"la journée se termine")]
        public void QuandLaJourneeSeTermine()
        {
            var result = _client.PosterDaily(_daily);
        }

    }
}
