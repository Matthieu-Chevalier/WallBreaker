using Objets;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dessins
{
    public class Dessins
    {
        public Graphics ModeleGraphique { get; set; }
        public Dessins(Graphics modeleGraphique)
        {
            ModeleGraphique = modeleGraphique;
        }

        public void DessinerRaquette(Raquette raquette)
        {
            ModeleGraphique.FillRectangle(Brushes.Black, raquette.PositionX, raquette.PositionY, raquette.Largeur, raquette.Hauteur);
        }
    }
}
