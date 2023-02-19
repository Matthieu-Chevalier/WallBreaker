using Objects.Moteur;
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
        public Graphics ModeleGraphique;
        public Dessin(Graphics modeleGraphique)
        {
            ModeleGraphique = modeleGraphique;
                      
        }

        public void DessinerRaquette(Raquette raquette, Graphics g)
        {
            Pen pen = new Pen(Color.Red, 3);
            g.DrawRectangle(pen, raquette.PositionX, raquette.PositionY, raquette.Largeur, raquette.Hauteur);
        }
        public void DessinerBalle(Balle balle, Graphics g)
        {
            Pen pen = new Pen(Color.Black, 3);
            g.DrawEllipse(pen, balle.BalleX, balle.BalleY,balle.BalleSize, balle.BalleSize);
        }
        public void DessinerZoneDeJeu(ZoneDeJeu zoneDeJeu, Graphics g)
        {
            Pen pen = new Pen(Color.Black, 4);
            //Deux approches: soit on dessine ligne par ligne, soit un dessine un rectangle directement
            int largeur = (zoneDeJeu.MurDroit - zoneDeJeu.MurGauche);
            int hauteur = (zoneDeJeu.MurBas - zoneDeJeu.MurHaut);
            g.DrawRectangle(pen, zoneDeJeu.MurGauche, zoneDeJeu.MurHaut, largeur, hauteur);
        }
        public void DessinerBrique(Brique brique, Graphics g)
        {
            Brush brush = new SolidBrush(Color.FromArgb(200, Color.Black));
            
            Pen pen = new Pen(Color.White, 1);
            g.FillRectangle(brush, brique.GetRectangle());
            g.DrawRectangle(pen, brique.GetRectangle());
            
        }
    }
}
