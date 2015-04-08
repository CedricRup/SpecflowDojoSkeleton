using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using NUnit.Framework;
using WebApi.Controllers;

namespace UnitTests
{

    /* Quand je crée un projet je récupére un objet non null
     * Quand je crée un projet elle a un id
     * Je peux crée un projet avec un date de relase
     * Si je crée un projet sans date de release j'ai une erreur
     * Je peux créer un projet en spécifiant la date du jour
     * Si je crée un projet sans date du jour j'ai une erreur
     * Si je crée un projet sans story,  j'ai une erreur
     * */

    [TestFixture]
    public class ProjetControllerTests
    {
        private ProjetController _tested;

        [SetUp]
        public void Setup()
        {
            _tested = new ProjetController(new DummyProjetStore());
        }

        public NouveauProjet NouveauProjetParDefaut()
        {
            return new NouveauProjet
            {
                Nom = "NomDuProjet",
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
        public void Quand_je_cree_un_projet_je_recupere_un_projet_non_null()
        {
            var projet = _tested.Post(NouveauProjetParDefaut());
            Assert.That(projet, Is.Not.Null);
        }

        [Test]
        public void Quand_je_cree_un_projet_je_recupere_son_id()
        {
            var projet = _tested.Post(NouveauProjetParDefaut());
            Assert.That(projet.Nom, Is.EqualTo(projet.Nom));
        }

        [Test]
        public void Quand_je_cree_un_projet_je_recupere_sa_date_de_release()
        {
            var parameters = NouveauProjetParDefaut();
            var projet = _tested.Post(parameters);
            Assert.That(projet.DateDeRelease, Is.EqualTo(parameters.DateDeRelease));
        }

        [Test]
        public void Quand_je_cree_un_projet_sans_date_de_release_j_ai_une_erreur()
        {
            var parameters = NouveauProjetParDefaut();
            parameters.DateDeRelease = null;
            var exception = Assert.Throws<HttpResponseException>(
                () => _tested.Post(parameters));
            Assert.That(exception.Response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public void Quand_je_cree_un_projet_je_recupere_la_date_courante()
        {
            var parameters = NouveauProjetParDefaut();
            var projet = _tested.Post(parameters);
            Assert.That(projet.Date, Is.EqualTo(parameters.DateDeDebut));
        }

        [Test]
        public void Quand_je_cree_un_projet_sans_date_de_debut_j_ai_une_erreur()
        {
            var parameters = NouveauProjetParDefaut();
            parameters.DateDeDebut = null;
            var exception = Assert.Throws<HttpResponseException>(
                () => _tested.Post(parameters));
            Assert.That(exception.Response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public void Quand_je_cree_un_projet_je_recupere_ses_stories()
        {
            var parameters = NouveauProjetParDefaut();
            var result = _tested.Post(parameters);
            Assert.That(result.Stories.Count(), Is.EqualTo(2));
            Assert.That(result.Stories.Select(s => s.Titre), Is.EquivalentTo(parameters.Stories.Select(s => s.Titre)));

        }

        [Test]
        public void Quand_je_cree_avec_0_story_j_ai_une_erreur()
        {
            var parameters = NouveauProjetParDefaut();
            parameters.Stories = new StoryParam[]{};
            var exception = Assert.Throws<HttpResponseException>(
                () => _tested.Post(parameters));
            Assert.That(exception.Response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));      
        }

        [Test]
        public void Quand_je_cree_un_projet_je_recupere_les_charges_des_stories()
        {
            var parameters = NouveauProjetParDefaut();
            parameters.Stories = new StoryParam[] { new StoryParam(){Titre = "Hello",Charge=2}};
            var result = _tested.Post(parameters);
            Assert.That(result.Stories.First().Charge,Is.EqualTo(2));
        }

        [Test]
        public void je_peux_recuperer_un_projet_que_j_ai_cree()
        {
            var parameters = NouveauProjetParDefaut();
            var result = _tested.Post(parameters);
            var projet = _tested.Get(result.Nom);
            Assert.That(projet, Is.Not.Null);
            Assert.That(projet.DateDeRelease,Is.EqualTo(parameters.DateDeRelease));
        }


    }
}
