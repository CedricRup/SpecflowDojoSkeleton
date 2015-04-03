using System;
using System.Collections.Generic;
using System.Linq;
using Database;
using Model;

namespace UnitTests
{
    public class DummyPartyStore : IPartieStore
    {
        private readonly List<Partie> _store = new List<Partie>(); 

        public Partie Get(Guid id)
        {
            return _store.First(p => p.Id == id);
        }

        public IEnumerable<Partie> GetAll()
        {
            return _store;
        }

        public void Register(Partie toRegister)
        {
            _store.Add(toRegister);
        }
    }
}