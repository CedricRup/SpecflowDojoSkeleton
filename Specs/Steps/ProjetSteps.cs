using System;
using System.Linq;
using ApiClient;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using WebApi.Controllers;

namespace Specs.Steps
{
    [Binding]
    public class ProjetSteps
    {
        private NouveauProjet _projet;
        private readonly V1Client _client;

        public ProjetSteps(WebClientContext context)
        {
            _client = context.WebClient;
        }

        [Given(@"le projet '(.*)' avec les stories suivantes")]
        public void SoitLeProjetAvecLesStoriesSuivantes(string nomProjet, Table table)
        {
            _projet = new NouveauProjet
            {
                Nom = nomProjet,
                Stories = table.CreateSet<StoryParam>().ToArray(),
                DateDeDebut = new DateTime(2014, 01, 01),
                DateDeRelease = new DateTime(2014, 12, 31)
            };

            var result = _client.NouveauProjet(_projet);
        
        }

        [Given(@"l'équipe '(.*)' travaille sur le projet '(.*)'")]
        public void SoitLCrocto(string equipe,string projet)
        {
            var result = _client.AffecterEquipe(equipe, projet);
        }

        [Then(@"les stories du projet '(.*)' sont dans l'état suivant")]
        public void AlorsLesStoriesDuProjetSontDansLEtatSuivant(string projet, Table table)
        {
            var result = _client.RecupererProjet(projet);
            table.CompareToSet(result.Data.Stories);
        }


    }
}
