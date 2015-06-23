using System;

namespace Model
{
    public class PlanAction
    {
        public string Rituel { get; set; }
        public Tache[] Taches { get; set; }
        public DateTime Date { get; set; }
    }
}