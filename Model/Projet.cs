using System;
using System.Collections.Generic;

namespace Model
{
    public class Projet
    {
        public Projet(string nom,DateTime dateDeDebut, DateTime dateDeRelease, IEnumerable<Story> stories)
        {
            Nom = nom;
            DateDeRelease = dateDeRelease;
            Stories = stories;
            Date = dateDeDebut;
        }

        public DateTime DateDeRelease { get; private set; }
        public DateTime Date { get; private set; }
        public IEnumerable<Story> Stories { get; set; }
        public string Nom { get; set; }
    }
}