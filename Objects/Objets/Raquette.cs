using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Objets
{
    public class Raquette
    {
        public Raquette(int positionX, int positionY, int hauteur, int largeur)
        {
            PositionX = positionX;
            PositionY = positionY;
            Hauteur = hauteur;
            Largeur = largeur;
        }

        public int PositionX { get; set; }
        public int PositionY { get;  } // On peut envisager plus tard de modifier la hauteur de la raquette suite à un Malus, mais pas pour l'instant
        public int Hauteur { get;  } // La hauteur de la raquette ne changera jamais
        public int Largeur { get; set; }

         
        public void DeplacerRaquette(int vitesse)
        {
            PositionX += vitesse;
        }
        

    }
}
