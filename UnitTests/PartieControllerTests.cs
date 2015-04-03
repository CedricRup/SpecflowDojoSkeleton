using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using NUnit.Framework;
using WebApi.Controllers;

namespace UnitTests
{

    /* Quand je crée une partie je récupére un objet non null
     * Quand je crée une partie elle a un id
     * Je peux crée une partie avec une date de relase
     * Si je crée une partie sans date de release j'ai une erreur
     * Je peux créer une partie en spécifiant la date du jour
     * Si je crée une partie sans date du jour j'ai une erreur
     * Si je crée une partie sans story,  j'ai une erreur
     * */

    [TestFixture]
    public class PartieControllerTests
    {
        private PartieController _tested;

        [SetUp]
        public void Setup()
        {
            _tested = new PartieController(new DummyPartyStore());
        }

        public NouvellePartie NouvellePartieParDefaut()
        {
            return new NouvellePartie
            {
                DateDeRelease = new DateTime(2012, 8, 17),
                DateDeDebut = new DateTime(2011, 8, 17),
                Stories = new[]
                {
                    new StoryParam {Titre = "Libelle"},
                    new StoryParam {Titre = "Glop"}
                }
            };
        }

        [Test]
        public void Quand_je_cree_une_partie_je_recupere_une_partie_non_null()
        {
            var partie = _tested.Post(NouvellePartieParDefaut());
            Assert.That(partie, Is.Not.Null);
        }

        [Test]
        public void Quand_je_cree_une_partie_je_recupere_son_id()
        {
            var partie = _tested.Post(NouvellePartieParDefaut());
            Assert.That(partie.Id, Is.Not.EqualTo(Guid.Empty));
        }

        [Test]
        public void Quand_je_cree_une_partie_je_recupere_sa_date_de_release()
        {
            var parameters = NouvellePartieParDefaut();
            var partie = _tested.Post(parameters);
            Assert.That(partie.DateDeRelease, Is.EqualTo(parameters.DateDeRelease));
        }

        [Test]
        public void Quand_je_cree_une_partie_sans_date_de_release_j_ai_une_erreur()
        {
            var parameters = NouvellePartieParDefaut();
            parameters.DateDeRelease = null;
            var exception = Assert.Throws<HttpResponseException>(
                () => _tested.Post(parameters));
            Assert.That(exception.Response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public void Quand_je_cree_une_partie_je_recupere_la_date_courante()
        {
            var parameters = NouvellePartieParDefaut();
            var partie = _tested.Post(parameters);
            Assert.That(partie.Date, Is.EqualTo(parameters.DateDeDebut));
        }

        [Test]
        public void Quand_je_cree_une_partie_sans_date_de_debut_j_ai_une_erreur()
        {
            var parameters = NouvellePartieParDefaut();
            parameters.DateDeDebut = null;
            var exception = Assert.Throws<HttpResponseException>(
                () => _tested.Post(parameters));
            Assert.That(exception.Response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public void Quand_je_cree_une_partie_je_recupere_ses_stories()
        {
            var parameters = NouvellePartieParDefaut();
            var result = _tested.Post(parameters);
            Assert.That(result.Stories.Count(), Is.EqualTo(2));
            Assert.That(result.Stories.Select(s => s.Titre), Is.EquivalentTo(parameters.Stories.Select(s => s.Titre)));

        }

        [Test]
        public void Quand_je_cree_avec_0_story_j_ai_une_erreur()
        {
            var parameters = NouvellePartieParDefaut();
            parameters.Stories = new StoryParam[]{};
            var exception = Assert.Throws<HttpResponseException>(
                () => _tested.Post(parameters));
            Assert.That(exception.Response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));      
        }

        [Test]
        public void Quand_je_cree_une_partie_je_recupere_les_charges_des_stories()
        {
            var parameters = NouvellePartieParDefaut();
            parameters.Stories = new StoryParam[] { new StoryParam(){Titre = "Hello",Charge=2}};
            var result = _tested.Post(parameters);
            Assert.That(result.Stories.First().Charge,Is.EqualTo(2));
        }

        [Test]
        public void je_peux_recuperer_une_partie_que_j_ai_cree()
        {
            var parameters = NouvellePartieParDefaut();
            var result = _tested.Post(parameters);
            var partie = _tested.Get(result.Id);
            Assert.That(partie, Is.Not.Null);
            Assert.That(partie.DateDeRelease,Is.EqualTo(parameters.DateDeRelease));
        }


    }
}
