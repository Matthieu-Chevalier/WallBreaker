using Objects.Objets;
using System;
using System.Windows.Forms;

namespace Objects.Observer
{
    public class Moteur
    {
        private const int VITESSE = 10; //Vitesse de déplacement de la raquette
        private Balle balle;
        private Raquette raquette;
        private ZoneDeJeu zoneDeJeu;
        private bool _isPaused;

        public bool IsPaused
        {
            get { return _isPaused; }
            set { _isPaused = value; }
        }


        //private Bonus
        //Private Brique

        public Moteur(Balle balle, Raquette raquette, ZoneDeJeu zoneDeJeu)
        {
            this.balle = balle;
            this.raquette = raquette;
            this.zoneDeJeu = zoneDeJeu;
            IsPaused = true;
        }



        public void KeyBoardReaction(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                raquette.DeplacerRaquette(-VITESSE, zoneDeJeu.MurGauche,zoneDeJeu.MurDroit);
            }
            if (e.KeyCode == Keys.Right)
            {
                raquette.DeplacerRaquette(VITESSE, zoneDeJeu.MurGauche, zoneDeJeu.MurDroit);
            }
            if (e.KeyCode == Keys.Space)
            {
                IsPaused = !IsPaused;
            }
        }

        public void Run()
        {
            // Mettre à jour la position de la balle
            balle.BalleX += balle.BalleDX;
            balle.BalleY += balle.BalleDY;


            // Mettre à jour la direction de la balle si elle entre en collision avec le mur
            if (balle.BalleX < zoneDeJeu.MurGauche || balle.BalleX > zoneDeJeu.MurDroit)
            {
                balle.BalleDX = -balle.BalleDX;
            }
            if (balle.BalleY < 0)
            {
                balle.BalleDY = -balle.BalleDY;
            }

            if (balle.BalleY + balle.BalleDY > raquette.PositionY)
            {
            // Mettre à jour la direction de la balle si elle entre en collision avec la raquette
                if (
                 balle.BalleX + balle.BalleDX > raquette.PositionX
                && balle.BalleX + balle.BalleDY < raquette.PositionX + raquette.Largeur)
                {
                    balle.BalleDY = -balle.BalleDY;
                }
                else // Si la balle passe en dessous de la raquette
                {
                    //Fin de partie
                }
            }
        }
    }
}
