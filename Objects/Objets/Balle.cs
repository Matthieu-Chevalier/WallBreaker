using Objects.Moteurs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Objets
{
    public class Balle : IContraignable, IObserver
    {
     

        public int BalleX { get; set; }
        public int BalleY { get; set; }
        //Mettre en place un design pattern observer qui modifie la vitesse en fonction des colisions
        public int BalleDX { get; set;} // Vitesse sur l'axe X
        public int BalleDY { get; set;} // Vitesse sur l'axe Y
        public int BalleSize { get; set;}
        private int MaxX;
        private int MaxY;
        private int MinX;
        private int MinY;
        private int RaquetteY;
        private int RaquetteX;
        private int RaquetteLargeur;
        private int RaquetteHauteur;


        public Balle(int balleX, int balleY, int balleDX, int balleDY, int balleSize)
        {
            BalleX = balleX;
            BalleY = balleY;
            BalleDX = balleDX;
            BalleDY = balleDY;
            BalleSize = balleSize;
        }

        public void DeplacerBalle()
        {
            if (BalleX<MinX || BalleX+BalleSize>MaxX)
            {
                BalleDX = -BalleDX;
            }
            if(BalleY<MinY || BalleY>MaxY || this.CollisionRaquette()) { BalleDY = - BalleDY; }
            
            BalleX += BalleDX;
            BalleY += BalleDY;
        }

        public void ImposerContrainte(ZoneDeJeu zone)
        {
            MaxX = zone.MurDroit;
            MinX = zone.MurGauche;
            MaxY = zone.MurBas;
            MinY = zone.MurHaut;
        }

        public void Actualiser(IObservable observable)
        {
            if(observable.GetType() == typeof(Raquette)) {
            Raquette raquette = (Raquette)observable;
                RaquetteY = raquette.PositionY;
                RaquetteX = raquette.PositionX;
                RaquetteHauteur = raquette.Hauteur;
                RaquetteLargeur = raquette.Largeur;
            }else
            {

            throw new NotImplementedException();
            }
        }
        private bool CollisionRaquette()
        {
            if (BalleY+BalleSize > RaquetteY
                && BalleX > RaquetteX
                && BalleX < RaquetteX+RaquetteLargeur)
            {
                return true;
            }
            else return false;
        }
    }
    
}
