using System.Collections.Generic;
using System.Threading;

namespace Database
{
    public class Store<T>
    {
        readonly List<T> _storage = new List<T>(); 

        public IEnumerable<T> GetAll()
        {
            Thread.Sleep(1000);
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
}
