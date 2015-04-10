using System;
using System.Collections.Generic;

namespace ApiClient
{
    public class ProjetJson
    {
        public DateTime DateDeRelease { get; set; }
        public string Nom { get; set; }
        public List<StoryJson> Stories { get; set; }
        public DateTime Date { get; set; }
    }
}
