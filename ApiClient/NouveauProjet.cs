using System;

namespace WebApi.Controllers
{
    public class NouveauProjet
    {
        public DateTime? DateDeRelease { get; set; }
        public DateTime? DateDeDebut { get; set; }
        public StoryParam[] Stories { get; set; }
        public string Nom { get; set; }
    }
}