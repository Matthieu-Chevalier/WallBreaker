using Objects.Moteurs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Objets
{
    public class Raquette : IContraignable
    {
        private int _positionX;
        private int _positionY;
        private int _hauteur;
        private int _largeur;
        public int PositionX { get { return _positionX; }  }
        public int PositionY { get { return _positionY; }  } // On peut envisager plus tard de modifier la position de la raquette suite à un Malus, mais pas pour l'instant
        public int Hauteur { get { return _hauteur; }  } // La hauteur de la raquette ne changera jamais
        public int Largeur { get { return _largeur; } }
        private int MinX;
        private int MaxX;
    

        public Raquette(int positionX, int positionY, int hauteur, int largeur)
        {
            _positionX = positionX;
            _positionY = positionY;
            _hauteur = hauteur;
            _largeur = largeur;
        }
        public void DeplacerDroite(int vitesse)
        {
            if(_positionX+_largeur<MaxX)
            {
                _positionX += vitesse;
            }
        }
        public void DeplacerGauche(int vitesse)
        {
            if (_positionX>MinX)
            {
                _positionX -= vitesse;
            }
        }

        public void ImposerContrainte(ZoneDeJeu zone)
        {
            MinX = zone.MurGauche;
            MaxX = zone.MurDroit;
        }
    }
}
