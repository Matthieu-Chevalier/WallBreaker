using Objects.Objets;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects.Dessins
{
    public class Dessin
    {
        public Graphics ModeleGraphique { get; set; }
        public Dessin(Graphics modeleGraphique)
        {
            ModeleGraphique = modeleGraphique;
        }

        public void DessinerRaquette(Raquette raquette, Graphics g)
        {
            Pen pen = new Pen(Color.Red, 3);
            g.DrawRectangle(pen, raquette.PositionX, raquette.PositionY, raquette.Largeur, raquette.Hauteur);
        }
    }
}
