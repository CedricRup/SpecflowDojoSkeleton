using System;
using System.Collections.Generic;

namespace Model
{
    public class Partie
    {
        public Partie(DateTime dateDeDebut, DateTime dateDeRelease, IEnumerable<Story> stories)
        {
            DateDeRelease = dateDeRelease;
            Stories = stories;
            Date = dateDeDebut;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }
        public DateTime DateDeRelease { get; private set; }
        public DateTime Date { get; private set; }
        public IEnumerable<Story> Stories { get; set; }
    }
}