using System;
using System.Linq;
using Model;

namespace Database
{
    public interface IDailyStore
    {
        void Register(Daily daily);
        Daily Get(string nomProjet, DateTime jour);
    }

     public class DailyStore : Store<Daily>, IDailyStore
     {
         public Daily Get(string nomProjet, DateTime jour)
         {
             return GetAll().FirstOrDefault(d => d.Projet == nomProjet && d.Date == jour);
         }
     }
}