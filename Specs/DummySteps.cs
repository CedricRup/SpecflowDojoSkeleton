using System;
using ApiClient;
using Model;
using NUnit.Framework;
using TechTalk.SpecFlow;
using WebApi.Controllers;

namespace Specs
{
    [Binding]
    public class DummySteps
    {
        private Dummy _dummy;

        [When(@"je récupère un Dummy")]
        public void QuandJeRecupereUnDummy()
        {
            _dummy = new ApiClient.ApiClient().GetDummy();
        }

        [Then(@"le nom du Dummy devrait être '(.*)'")]
        public void AlorsLeNomDuDummyDevraitEtre(string dummyName)
        {
            Assert.That(_dummy.Name,Is.EqualTo(dummyName));
        }
    }
}
