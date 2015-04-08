using System;
using System.Collections.Generic;
using System.Linq;
using Database;
using Model;

namespace UnitTests
{
    public class DummyStore<T>
    {
        protected readonly List<T> _store = new List<T>();

        public IEnumerable<T> GetAll()
        {
            return _store;
        }

        public void Register(T toRegister)
        {
            _store.Add(toRegister);
        }
    }

    public class DummyProjetStore : DummyStore<Projet>, IProjetStore
    {
        public Projet Get(string nom)
        {
            return _store.FirstOrDefault(p => p.Nom == nom);
        }
    }

    public class DummyEquipeStore : DummyStore<Equipe>, IEquipeStore
    {
        public Equipe Get(string nom)
        {
            return _store.FirstOrDefault(p => p.NomEquipe == nom);
        }
    }
}