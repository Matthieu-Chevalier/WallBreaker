using Objects.Moteurs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Objets
{
    public class Raquette : IContraignable, IObservable
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
        private List<IObserver> balles;

        public Raquette(int positionX, int positionY, int hauteur, int largeur)
        {
            _positionX = positionX;
            _positionY = positionY;
            _hauteur = hauteur;
            _largeur = largeur;
            balles  = new List<IObserver>();

        }
        public void DeplacerDroite(int vitesse)
        {
            if(_positionX+_largeur<MaxX)
            {
                _positionX += vitesse;
                AvertirObservateurs();
            }
        }
        public void DeplacerGauche(int vitesse)
        {
            if (_positionX>MinX)
            {
                _positionX -= vitesse;
                AvertirObservateurs();
            }
        }

        public void ImposerContrainte(ZoneDeJeu zone)
        {
            MinX = zone.MurGauche;
            MaxX = zone.MurDroit;
        }

        public void AjouterObservateur(IObserver observateur)
        {
            if(observateur.GetType()==typeof(Balle))
            balles.Add(observateur);
        }

        public void SupprimerObservateur(IObserver observateur)
        {
            if(observateur.GetType() == typeof(Balle))
            balles.Remove(observateur);
        }

        public void AvertirObservateurs()
        {
            foreach (var item in balles)
            {
                item.Actualiser(this);
            }
        }
    }
}
