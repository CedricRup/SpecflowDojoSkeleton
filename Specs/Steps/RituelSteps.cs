using System;
using System.Linq;
using ApiClient;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using WebApi.Controllers;

namespace Specs.Steps
{
    [Binding]
    public class RituelSteps
    {
        private NouveauRituel _rituel;
        private readonly V1Client _client;

        public RituelSteps(WebClientContext context)
        {
            _client = context.WebClient;
        }

        [Given(@"le rituel '(.*)' avec les actions suivantes")]
        public void SoitLeRituelAvecLesActionsSuivantes(string nomRituel, Table table)
        {
            _rituel = new NouveauRituel
            {
                Nom = nomRituel,
                Actions = table.CreateSet<ActionJson>().ToArray(),
                DateDeDebut = new DateTime(2014, 01, 01),
                Echeance = new DateTime(2014, 12, 31)
            };

            var result = _client.NouveauRituel(_rituel);
        
        }

        [Given(@"le village '(.*)' effectue le rituel '(.*)'")]
        public void SoitLCrocto(string nomVillage, string projet)
        {
            var result = _client.AffecterVillage(nomVillage, projet);
        }

        [Then(@"les actions pour le rituel '(.*)' sont dans l'état suivant")]
        public void AlorsLesActionsDuRituelSontDansLEtatSuivant(string projet, Table table)
        {
            var result = _client.RecupererRituel(projet);
            table.CompareToSet(result.Data.Actions);
        }


    }
}
