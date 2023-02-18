using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Objets
{
    public class Raquette
    {
        private int _positionX;
        private int _positionY;
        private int _hauteur;
        private int _largeur;
        public int PositionX { get { return _positionX; }  }
        public int PositionY { get { return _positionY; }  } // On peut envisager plus tard de modifier la position de la raquette suite à un Malus, mais pas pour l'instant
        public int Hauteur { get { return _hauteur; }  } // La hauteur de la raquette ne changera jamais
        public int Largeur { get { return _largeur; } }
    

        public Raquette(int positionX, int positionY, int hauteur, int largeur)
        {
            _positionX = positionX;
            _positionY = positionY;
            _hauteur = hauteur;
            _largeur = largeur;
        }
        public void DeplacerRaquette(int vitesse, int bordGauche, int bordDroit)
        {
            if(_positionX > bordGauche || _positionX+_largeur<bordDroit)
            {
                _positionX += vitesse;
            }
        }
    }
}
