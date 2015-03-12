using System.Collections.Generic;
using System.Threading;
using Model;

namespace Database
{
    public class Store<T>
    {
        readonly List<T> _storage = new List<T>(); 

        public IEnumerable<T> GetAll()
        {
            Thread.Sleep(5000);
            return _storage;
        }

        public void Register(T toRegister)
        {
            Thread.Sleep(1000);
            _storage.Add(toRegister);
        }

        public void Delete(T toDelete)
        {
            Thread.Sleep(1000);
            _storage.Remove(toDelete);
        }

        public void Reset()
        {
            _storage.Clear();
        }
    }

    public class DeveloppeurStore : Store<Developpeur>
    {
    }

    public class DummyStore : Store<Dummy>
    {
    }
}
