using Objects.Objets;
using System.Collections.Generic;

namespace Objects.Moteur
{
    public class Gestionnaire
    {
        private const int VITESSE = 10; //Vitesse de déplacement de la raquette

        private List<Balle> Balles;
        private List<Raquette> Raquettes;
        private ZoneDeJeu ZoneDeJeu;
        private List<Brique> Briques;


        //private Bonus
        //Private Brique

        public Gestionnaire()
        {
            
        }

        public void AjouterBalle(Balle balle)
        {
            Balles.Add(balle);
        }
        public void SupprimerBalle(Balle balle)
        {
            Balles.Remove(balle);
            if (Balles.Count == 0)
            { //Notifier le moteur qu'il n'y a plus de balles
            }
        }
    }
}
