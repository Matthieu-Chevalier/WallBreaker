using Objects.Moteurs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Objets
{
    public class Balle : IContraignable
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
            if (BalleX<MinX || BalleX>MaxX)
            {
                BalleDX = -BalleDX;
            }
            if(BalleY<MinY || BalleY>MaxY) { BalleDY = - BalleDY; }
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
    }
    
}
