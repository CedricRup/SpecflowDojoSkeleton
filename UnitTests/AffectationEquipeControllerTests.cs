using System;
using System.Linq;
using System.Net;
using ApiClient;
using Model;
using NUnit.Framework;
using WebApi.Controllers;

namespace UnitTests
{
    [TestFixture]
    public class AffectationEquipeControllerTests
    {
        private AffectationEquipeController _tested;
        private DummyEquipeStore _equipeStore;
        private DummyProjetStore _projetStore;

        [SetUp]
        public void Setup()
        {
            _equipeStore = new DummyEquipeStore();
            _projetStore = new DummyProjetStore();
            _tested = new AffectationEquipeController(_equipeStore,_projetStore);
        }

        [Test]
        public void Quand_je_rattache_une_équipe_un_projet_j_ai_une_200()
        {
            _equipeStore.Register(new Equipe("A-Team"));
            _projetStore.Register(new Projet("Crocto",DateTime.Today,DateTime.Today,Enumerable.Empty<Story>()));
            var result = _tested.Post(new AffectationEquipe { NomEquipe = "A-Team", NomProjet = "Crocto" });
            Assert.That(result.StatusCode,Is.EqualTo(HttpStatusCode.OK));
        }

        [Test]
        public void Quand_je_rattache_une_équipe_a_un_projet_elle_est_presente_dans_les_affectations()
        {
            _equipeStore.Register(new Equipe("A-Team"));
            _projetStore.Register(new Projet("Crocto", DateTime.Today, DateTime.Today, Enumerable.Empty<Story>()));
            _tested.Post(new AffectationEquipe { NomEquipe = "A-Team", NomProjet = "Crocto" });
            var affectations = _tested.Get();
            Assert.That(affectations.Select(affectation => affectation.NomEquipe), Contains.Item("A-Team"));
        }

        [Test]
        public void Quand_il_n_y_a_pas_d_affectation_j_ai_une_liste_vide()
        {
            var affectations = _tested.Get();
            Assert.That(affectations, Is.Empty);
        }

        [Test]
        public void Tenter_d_affecter_un_projet_qui_n_existe_pa_donne_une_404()
        {
            _equipeStore.Register(new Equipe("A-Team"));
            var result = _tested.Post(new AffectationEquipe { NomEquipe = "A-Team", NomProjet = "Crocto" });
            Assert.That(result.StatusCode,Is.EqualTo(HttpStatusCode.NotFound));
        }

        [Test]
        public void Tenter_d_affecter_un_projet_qui_existe_a_une_equipe_qui_n_existe_pas_donne_une_404()
        {
            _projetStore.Register(new Projet("Crocto", DateTime.Today, DateTime.Today, Enumerable.Empty<Story>()));
            var result = _tested.Post(new AffectationEquipe { NomEquipe = "A-Team", NomProjet = "Crocto" });
            Assert.That(result.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));
        }
    }
}
