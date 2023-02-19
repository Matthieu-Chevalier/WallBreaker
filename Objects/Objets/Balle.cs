using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Objets
{
    public class Balle
    {
     

        public int BalleX { get; set; }
        public int BalleY { get; set; }
        //Mettre en place un design pattern observer qui modifie la vitesse en fonction des colisions
        public int BalleDX { get; set;} // Vitesse sur l'axe X
        public int BalleDY { get; set;} // Vitesse sur l'axe Y
        public int BalleSize { get; set;}

        public Balle(int balleX, int balleY, int balleDX, int balleDY, int balleSize)
        {
            BalleX = balleX;
            BalleY = balleY;
            BalleDX = balleDX;
            BalleDY = balleDY;
            BalleSize = balleSize;
        }

        public void DeplacerBalle(int Dx, int Dy)
        {
            BalleDX=Dx; BalleDY=Dy;
            BalleX += BalleDX; 
            BalleY += BalleDY;
        }

        public void ChangeDirection(int direction)
        {

        }
        public int GetPositionY()
        {
            return BalleY;
        }
       
    }
    
}
