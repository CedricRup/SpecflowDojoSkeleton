using System.Linq;
using ApiClient;
using Model;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Specs.Steps
{
    [Binding]
    public class PlanActionSteps
    {
        private V1Client _client;
        private PlanAction _planAction;

        public PlanActionSteps(WebClientContext context)
        {
            _client = context.WebClient;
        }

        [Given(@"le daily pour le projet '(.*)'")]
        public void SoitLeDailyPourLeProjet(string projet)
        {
            _planAction = new PlanAction
            {
                Rituel = projet,
                Taches = new Tache[0]

            };

        }

        [Given(@"le plan d'action pour le rituel '(.*)'")]
        public void SoitLePlanDCrocto(string rituel, Table table)
        {
            _planAction = new PlanAction
            {
                Rituel = rituel,
                Taches = table.CreateSet<Tache>().ToArray()
            };
        }



        [Given(@"que '(.*)' travaille sur '(.*)'")]
        public void SoitQueTravailleSur(string developpeur, string story)
        {
            _planAction.Taches = _planAction.Taches.Concat(new[] { new Tache { Par = developpeur, Action = story } }).ToArray();
        }


        [When(@"la journée se termine")]
        public void QuandLaJourneeSeTermine()
        {
            var result = _client.PosterPlanAction(_planAction);
        }

    }
}
