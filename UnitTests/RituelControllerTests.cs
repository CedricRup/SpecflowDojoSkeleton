using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using ApiClient;
using NUnit.Framework;
using WebApi.Controllers;

namespace UnitTests
{

    [TestFixture]
    public class RituelControllerTests
    {
        private RituelController _tested;

        [SetUp]
        public void Setup()
        {
            _tested = new RituelController(new DummyRituelStore());
        }

        public NouveauRituel NouveauRituelParDefaut()
        {
            return new NouveauRituel
            {
                Nom = "NomDuProjet",
                Echeance = new DateTime(2012, 8, 17),
                DateDeDebut = new DateTime(2011, 8, 17),
                Actions = new[]
                {
                    new ActionJson {Intitule = "Libelle"},
                    new ActionJson {Intitule = "Glop"}
                }
            };
        }

        [Test]
        public void Quand_je_cree_un_rituel_je_recupere_un_rituel_non_null()
        {
            var rituel = _tested.Post(NouveauRituelParDefaut());
            Assert.That(rituel, Is.Not.Null);
        }

        [Test]
        public void Quand_je_cree_un_rituel_je_recupere_son_id()
        {
            var rituel = _tested.Post(NouveauRituelParDefaut());
            Assert.That(rituel.Nom, Is.EqualTo(rituel.Nom));
        }

        [Test]
        public void Quand_je_cree_un_rituel_je_recupere_son_echeance()
        {
            var parameters = NouveauRituelParDefaut();
            var projet = _tested.Post(parameters);
            Assert.That(projet.Echeance, Is.EqualTo(parameters.Echeance));
        }

        [Test]
        public void Quand_je_cree_un_rituel_sans_echeance_j_ai_une_erreur()
        {
            var parameters = NouveauRituelParDefaut();
            parameters.Echeance = null;
            var exception = Assert.Throws<HttpResponseException>(
                () => _tested.Post(parameters));
            Assert.That(exception.Response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public void Quand_je_cree_un_rituel_je_recupere_la_date_courante()
        {
            var parameters = NouveauRituelParDefaut();
            var projet = _tested.Post(parameters);
            Assert.That(projet.Date, Is.EqualTo(parameters.DateDeDebut));
        }

        [Test]
        public void Quand_je_cree_un_rituel_sans_date_de_debut_j_ai_une_erreur()
        {
            var parameters = NouveauRituelParDefaut();
            parameters.DateDeDebut = null;
            var exception = Assert.Throws<HttpResponseException>(
                () => _tested.Post(parameters));
            Assert.That(exception.Response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public void Quand_je_cree_un_rituel_je_recupere_ses_actions()
        {
            var parameters = NouveauRituelParDefaut();
            var result = _tested.Post(parameters);
            Assert.That(result.Actions.Count(), Is.EqualTo(2));
            Assert.That(result.Actions.Select(s => s.Intitule), Is.EquivalentTo(parameters.Actions.Select(s => s.Intitule)));

        }

        [Test]
        public void Quand_je_cree_avec_0_actions_j_ai_une_erreur()
        {
            var parameters = NouveauRituelParDefaut();
            parameters.Actions = new ActionJson[] { };
            var exception = Assert.Throws<HttpResponseException>(
                () => _tested.Post(parameters));
            Assert.That(exception.Response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));      
        }

        [Test]
        public void Quand_je_cree_un_rituel_je_recupere_les_charges_des_actions()
        {
            var parameters = NouveauRituelParDefaut();
            parameters.Actions = new ActionJson[] { new ActionJson() { Intitule = "Hello", Charge = 2 } };
            var result = _tested.Post(parameters);
            Assert.That(result.Actions.First().Charge,Is.EqualTo(2));
        }

        [Test]
        public void je_peux_recuperer_un_rituel_que_j_ai_cree()
        {
            var parameters = NouveauRituelParDefaut();
            var result = _tested.Post(parameters);
            var projet = _tested.Get(result.Nom);
            Assert.That(projet, Is.Not.Null);
            Assert.That(projet.Echeance,Is.EqualTo(parameters.Echeance));
        }


    }
}
