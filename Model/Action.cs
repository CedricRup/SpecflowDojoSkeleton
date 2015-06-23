namespace Model
{
    public class Action  
    {
        public Action(string intitule, int charge)
        {
            Intitule = intitule;
            Charge = charge;
        }

        public string Intitule { get;private set; }
        public int Charge { get;private set; }
    }
}