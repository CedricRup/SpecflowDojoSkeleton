using System;
using ApiClient;
using Database;
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

        private readonly DummyController _dummyController;

        public DummySteps()
        {
            _dummyController = new DummyController(new DummyStore());
        }

        [When(@"je récupère un Dummy")]
        public void QuandJeRecupereUnDummy()
        {
            _dummy = _dummyController.Get();
        }

        [Then(@"le nom du Dummy devrait être '(.*)'")]
        public void AlorsLeNomDuDummyDevraitEtre(string dummyName)
        {
            Assert.That(_dummy.Name,Is.EqualTo(dummyName));
        }
    }
}
