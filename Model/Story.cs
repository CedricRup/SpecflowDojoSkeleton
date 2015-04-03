namespace Model
{
    public class Story  
    {
        public Story(string titre, int charge)
        {
            Titre = titre;
            Charge = charge;
        }

        public string Titre { get;private set; }
        public int Charge { get;private set; }
    }
}