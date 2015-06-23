using System;
using System.Linq;
using System.Net;
using ApiClient;
using Model;
using NUnit.Framework;
using WebApi.Controllers;
using Action = Model.Action;

namespace UnitTests
{
    [TestFixture]
    public class AffectationVillageControllerTests
    {
        private AffectationVillageController _tested;
        private DummyVillageStore _villageStore;
        private DummyRituelStore _rituelStore;

        [SetUp]
        public void Setup()
        {
            _villageStore = new DummyVillageStore();
            _rituelStore = new DummyRituelStore();
            _tested = new AffectationVillageController(_villageStore,_rituelStore);
        }

        [Test]
        public void Quand_je_rattache_un_village_un_rituel_j_ai_une_200()
        {
            _villageStore.Register(new Village("A-Team"));
            _rituelStore.Register(new Rituel("Crocto",DateTime.Today,DateTime.Today,Enumerable.Empty<Action>()));
            var result = _tested.Post(new AffectationVillage { NomVillage = "A-Team", NomRituel = "Crocto" });
            Assert.That(result.StatusCode,Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void Quand_je_rattache_un_village_a_un_rituel_il_est_presente_dans_les_affectations()
        {
            _villageStore.Register(new Village("A-Team"));
            _rituelStore.Register(new Rituel("Crocto", DateTime.Today, DateTime.Today, Enumerable.Empty<Action>()));
            _tested.Post(new AffectationVillage { NomVillage = "A-Team", NomRituel = "Crocto" });
            var affectations = _tested.Get();
            Assert.That(affectations.Select(affectation => affectation.NomVillage), Contains.Item("A-Team"));
        }

        [Test]
        public void Quand_il_n_y_a_pas_d_affectation_j_ai_une_liste_vide()
        {
            var affectations = _tested.Get();
            Assert.That(affectations, Is.Empty);
        }

        [Test]
        public void Tenter_d_affecter_un_rituel_qui_n_existe_pa_donne_une_404()
        {
            _villageStore.Register(new Village("A-Team"));
            var result = _tested.Post(new AffectationVillage { NomVillage = "A-Team", NomRituel = "Crocto" });
            Assert.That(result.StatusCode,Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public void Tenter_d_affecter_un_rituel_qui_existe_a_un_village_qui_n_existe_pas_donne_une_404()
        {
            _rituelStore.Register(new Rituel("Crocto", DateTime.Today, DateTime.Today, Enumerable.Empty<Action>()));
            var result = _tested.Post(new AffectationVillage { NomVillage = "A-Team", NomRituel = "Crocto" });
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
    }
}
