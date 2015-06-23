using System;
using System.Collections.Generic;

namespace ApiClient
{
    public class RituelJson
    {
        public DateTime Echeance { get; set; }
        public string Nom { get; set; }
        public List<ActionJson> Actions { get; set; }
        public DateTime Date { get; set; }
    }
}
