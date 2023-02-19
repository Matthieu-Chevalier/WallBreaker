using Objects.Observer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Objects.Objets
{
    public class Brique 
    {
        private int resistance;
        public const int LARGEUR = 50;
        public const int HAUTEUR = 50;
        private Mouvement Mouvement;
        public int BriqueX;
        public int BriqueY;
        public Brique(int resistance, Mouvement mvt)
        {
            this.resistance = resistance;
            Mouvement = mvt;
            BriqueX = -1;
            BriqueY = -1;
        }
        public void Affaiblir()
        {
            resistance -= 1;
            if (resistance == 0)
            {
                Mouvement.SupprimerBrique(this);
            }
        }

        public void SetPosition(int x, int y)
        {
            BriqueX = BriqueX ==-1 ? x : -1; // Empêche la redéfinition de la position d'une brique.
            BriqueY = BriqueY ==-1 ? y : -1; // On envisagera plus tard de créer une méthode : déplacerbrique si on souhaite avoir des briques mouvantes
            
        }
        public Rectangle GetRectangle()
        {
            return new Rectangle(new Point(BriqueX,BriqueY),new Size(LARGEUR,HAUTEUR));
        }
    }
}
