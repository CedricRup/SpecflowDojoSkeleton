using System.Collections.Generic;
using Model;

namespace Database
{
    public interface IVillageStore
    {
        Village Get(string nom);
        IEnumerable<Village> GetAll();
        void Register(Village toRegister);
    }
}