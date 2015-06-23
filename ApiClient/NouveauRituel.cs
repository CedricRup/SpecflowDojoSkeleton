using System;
using ApiClient;

namespace WebApi.Controllers
{
    public class NouveauRituel
    {
        public DateTime? Echeance { get; set; }
        public DateTime? DateDeDebut { get; set; }
        public ActionJson[] Actions { get; set; }
        public string Nom { get; set; }
    }
}