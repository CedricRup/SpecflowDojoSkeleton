using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using Database;
using Model;
using NUnit.Framework;
using WebApi.Controllers;

namespace UnitTests
{
    /*
     * Quand je crée une équipe, je récupere un identifiant
     * Quand je crée une équipe, je récupere le développeur
     * Quand je crée une équipe sans dév, j'ai une erreur 400
     */

    [TestFixture]
    public class EquipeControllerTest
    {
        private EquipeController _tested;

        [SetUp]
        public void Setup()
        {
            _tested = new EquipeController(new DummyEquipeStore());
        }

        [Test]
        public void Quand_je_crée_une_équipe_sans_nom_j_ai_une_erreur_bad_request()
        {
            string parameters = null;
            var exception = Assert.Throws<HttpResponseException>(
                () => _tested.Post(parameters,new[] {"Alice"}));
            Assert.That(exception.Response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));

        }

        [Test]
        public void Quand_je_crée_une_équipe_sans_developpeurs_j_ai_une_erreur_bad_request()
        {
            var exception = Assert.Throws<HttpResponseException>(
                () => _tested.Post("A-team", new string[]{}));
            Assert.That(exception.Response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public void Quand_je_crée_une_équipe_avec_un_developpeur_je_récupere_l_equipe_avec_le_developpeur()
        {
            Equipe equipe = _tested.Post("A-team", new[] {"Alice"});

            Assert.That(equipe.Developpeurs.Count, Is.EqualTo(1));
            Assert.That(equipe.Developpeurs.First().Nom, Is.EqualTo("Alice"));
        }

        [Test]
        public void Quand_je_crée_une_équipe_avec_deux_developpeurs_je_récupere_l_equipe_avec_le_developpeur()
        {
            Equipe equipe = _tested.Post("A-team", new []{"Alice", "Bob"});

            Assert.That(equipe.Developpeurs.Count, Is.EqualTo(2));
            Assert.That(equipe.Developpeurs.First().Nom, Is.EqualTo("Alice"));
            Assert.That(equipe.Developpeurs.Last().Nom, Is.EqualTo("Bob"));
        }

        [Test]
        public void Quand_je_cree_une_equipe_je_peux_la_recuperer_avec_un_get()
        {
            _tested.Post("A-team", new[] { "Alice", "Bob" });
            var equipe = _tested.Get("A-team");
            Assert.That(equipe,Is.Not.Null);
            Assert.That(equipe.NomEquipe, Is.EqualTo("A-team"));

        }

        
    }
}
