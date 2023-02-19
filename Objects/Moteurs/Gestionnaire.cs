using Objects.Objets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Moteur
{
    public class Gestionnaire
    {
        private const int VITESSE = 10; //Vitesse de déplacement de la raquette

        private Balle balle;
        private Raquette raquette;
        private ZoneDeJeu zoneDeJeu;
       

        //private Bonus
        //Private Brique

        public Gestionnaire(Balle balle, Raquette raquette, ZoneDeJeu zoneDeJeu)
        {
            this.balle = balle;
            this.raquette = raquette;
            this.zoneDeJeu = zoneDeJeu;
           
        }
    }
}
