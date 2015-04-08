using System;

namespace Model
{
    public class Daily
    {
        public string Projet { get; set; }
        public Tache[] Taches { get; set; }
        public DateTime Date { get; set; }
    }
}