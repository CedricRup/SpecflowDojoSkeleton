using System;
using System.Linq;
using Model;

namespace Database
{
    public interface IPlanActionStore
    {
        void Register(PlanAction planAction);
        PlanAction Get(string nomProjet, DateTime jour);
    }

     public class PlanActionStore : Store<PlanAction>, IPlanActionStore
     {
         public PlanAction Get(string nomProjet, DateTime jour)
         {
             return GetAll().FirstOrDefault(d => d.Rituel == nomProjet && d.Date == jour);
         }
     }
}