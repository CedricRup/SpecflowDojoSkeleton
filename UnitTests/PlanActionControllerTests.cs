using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using Model;
using NUnit.Framework;
using WebApi.Controllers;
using Action = Model.Action;

namespace UnitTests
{
    [TestFixture]
    public class PlanActionControllerTests
    {
        private PlanActionController _tested;
        private DummyPlanActionStore _planActionStore;
        private DummyRituelStore _rituelStore;

        [SetUp]
        public void Setup()
        {
            _planActionStore = new DummyPlanActionStore();
            _rituelStore = new DummyRituelStore();
            _tested = new PlanActionController(_planActionStore,_rituelStore);
        }

        [Test]
        public void Quand_je_poste_un_plan_je_recupere_une_200()
        {
            var rituel = new Rituel("Crocto", new DateTime(2012, 08, 17), new DateTime(2013, 08, 17),
                new[] { new Action("Test", 100), });

            _rituelStore.Register(rituel);


            HttpResponseMessage result = _tested.Post(new PlanAction {Rituel = "Crocto", Taches = new []{new Tache{Action = "Test", Par = "Alice"}}});
            Assert.That(result.StatusCode,Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void Quand_je_poste_un_plan_je_peux_recuperer_le_detail_pour_la_journee()
        {
            var rituel = new Rituel("Crocto", new DateTime(2012, 08, 17), new DateTime(2013, 08, 17),
                new[] {new Action("Test", 100),});

           _rituelStore.Register(rituel);

            _tested.Post(new PlanAction { Rituel = "Crocto", Taches = new[] { new Tache { Action = "Test", Par = "Alice" } } });

            var result = _tested.Get("Crocto", new DateTime(2012, 08, 17));
            Assert.That(result.Date, Is.EqualTo(new DateTime(2012, 08, 17)));
            Assert.That(result.Taches.Count(),Is.EqualTo(1));
        }

        [Test]
        public void Quand_je_poste_un_plan_pour_un_rituel_qui_n_existe_pas_j_ai_une_400()
        {
            var result = _tested.Post(new PlanAction { Rituel = "Crocto", Taches = new[] { new Tache { Action = "Test", Par = "Alice" } } });
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        
        }

    }
}
