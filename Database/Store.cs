using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Model;

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

    public class DeveloppeurStore : Store<Developpeur>
    {
    }

    public interface IProjetStore
    {
        Projet Get(string nom);
        IEnumerable<Projet> GetAll();
        void Register(Projet toRegister);
    }

    public class ProjetStore : Store<Projet>, IProjetStore
    {
        public Projet Get(string nom)
        {
            return GetAll().FirstOrDefault(p => p.Nom == nom);
        }
    }

    public interface IEquipeStore
    {
        Equipe Get(string nom);
        IEnumerable<Equipe> GetAll();
        void Register(Equipe toRegister);
    }

    public class EquipeStore : Store<Equipe>, IEquipeStore
    {
        public Equipe Get(string nom)
        {
            return GetAll().FirstOrDefault(p => p.NomEquipe == nom);
        }
    }

    public class DummyStore : Store<Dummy>
    {
    }
}
