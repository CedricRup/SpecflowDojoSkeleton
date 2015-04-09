using System;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using WebApi.Controllers;

namespace Specs.Steps
{
    [Binding]
    public class ProjetSteps
    {
        private NouveauProjet _projet;

        [Given(@"le projet '(.*)' avec les stories suivantes")]
        public void SoitLeProjetAvecLesStoriesSuivantes(string nomProjet, Table table)
        {
            _projet = new NouveauProjet
            {
                Nom = nomProjet,
                Stories = table.CreateSet<StoryParam>().ToArray(),
                DateDeDebut = new DateTime(2014,01,01),
                DateDeRelease = new DateTime(2014,12,31)
            };
        }
    }
}
