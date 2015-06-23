using System;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
    public class Rituel
    {
        private List<Action> _actions; 
        public Rituel(string nom,DateTime dateDeDebut, DateTime dateDeRelease, IEnumerable<Action> actions)
        {
            Nom = nom;
            DateDeRelease = dateDeRelease;
            _actions = actions.ToList();
            Date = dateDeDebut;
        }

        public DateTime DateDeRelease { get; private set; }
        public DateTime Date { get; private set; }
        public IEnumerable<Action> Actions { get { return _actions; }}
        public string Nom { get; set; }
    }
}