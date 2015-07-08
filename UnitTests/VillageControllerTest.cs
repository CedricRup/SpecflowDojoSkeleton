using System.Linq;
using System.Net;
using System.Web.Http;
using Model;
using NUnit.Framework;
using WebApi.Controllers;

namespace UnitTests
{
 
    [TestFixture]
    public class VillageControllerTest
    {
        private VillageController _tested;

        [SetUp]
        public void Setup()
        {
            _tested = new VillageController(new DummyVillageStore());
        }

        [Test]
        public void Quand_je_crée_un_village_sans_nom_j_ai_une_erreur_bad_request()
        {
            string parameters = null;
            var exception = Assert.Throws<HttpResponseException>(
                () => _tested.Post(new NouveauVillage(parameters, new[] {"Alice"})));
            Assert.That(exception.Response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));

        }

        [Test]
        public void Quand_je_crée_un_village_sans_villageois_j_ai_une_erreur_bad_request()
        {
            var exception = Assert.Throws<HttpResponseException>(
                () => _tested.Post(new NouveauVillage("A-team", new string[]{})));
            Assert.That(exception.Response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
        }

        [Test]
        public void Quand_je_crée_un_village_avec_un_villageois_je_récupere_le_village_avec_le_villageois()
        {
            Village village = _tested.Post(new NouveauVillage("A-team", new[] {"Alice"}));

            Assert.That(village.Villageois.Count, Is.EqualTo(1));
            Assert.That(village.Villageois.First().Nom, Is.EqualTo("Alice"));
        }

        [Test]
        public void Quand_je_crée_un_village_avec_deux_villageois_je_récupere_le_village_avec_les_villageois()
        {
            Village village = _tested.Post(new NouveauVillage("A-team", new []{"Alice", "Bob"}));

            Assert.That(village.Villageois.Count, Is.EqualTo(2));
            Assert.That(village.Villageois.First().Nom, Is.EqualTo("Alice"));
            Assert.That(village.Villageois.Last().Nom, Is.EqualTo("Bob"));
        }

        [Test]
        public void Quand_je_cree_un_village_je_peux_le_recuperer_avec_un_get()
        {
            _tested.Post(new NouveauVillage("A-team", new[] { "Alice", "Bob" }));
            var village = _tested.Get("A-team");
            Assert.That(village,Is.Not.Null);
            Assert.That(village.NomVillage, Is.EqualTo("A-team"));

        }

        
    }
}
