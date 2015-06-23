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

    public class DummyRituelStore : DummyStore<Rituel>, IRituelStore
    {
        public Rituel Get(string nom)
        {
            return _store.FirstOrDefault(p => p.Nom == nom);
        }
    }

    public class DummyVillageStore : DummyStore<Village>, IVillageStore
    {
        public Village Get(string nom)
        {
            return _store.FirstOrDefault(p => p.NomEquipe == nom);
        }
    }

    public class DummyPlanActionStore : DummyStore<PlanAction>, IPlanActionStore
    {
        public PlanAction Get(string nomProjet, DateTime jour)
        {
            return _store.FirstOrDefault(d => d.Date == jour && d.Rituel == nomProjet);
        }
    }
}