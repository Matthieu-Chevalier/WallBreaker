namespace Objets
{
    public class Raquette
    {
        //Proriétés
        public int PositionX { get; set; }
        public int PositionY { get; init; }
        public int Hauteur { get; init; }
        public int Largeur { get; set; }
        //Constructeur
        public Raquette(int positionX, int positionY, int hauteur, int largeur)
        {
            PositionX = positionX;
            PositionY = positionY;
            Hauteur = hauteur;
            Largeur = largeur;
        }

        //Méthodes
        public void DeplacerRaquette(int vitesse)
        {
            PositionX= vitesse;
        }
      





    }
}