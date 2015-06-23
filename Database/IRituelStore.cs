using System.Collections.Generic;
using Model;

namespace Database
{
    public interface IRituelStore
    {
        Rituel Get(string nom);
        IEnumerable<Rituel> GetAll();
        void Register(Rituel toRegister);
    }
}