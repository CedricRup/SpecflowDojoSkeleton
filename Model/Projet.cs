using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class Projet
    {
        private List<Story> _stories; 
        public Projet(string nom,DateTime dateDeDebut, DateTime dateDeRelease, IEnumerable<Story> stories)
        {
            Nom = nom;
            DateDeRelease = dateDeRelease;
            _stories = stories.ToList();
            Date = dateDeDebut;
        }

        public DateTime DateDeRelease { get; private set; }
        public DateTime Date { get; private set; }
        public IEnumerable<Story> Stories { get { return _stories; }}
        public string Nom { get; set; }
    }
}