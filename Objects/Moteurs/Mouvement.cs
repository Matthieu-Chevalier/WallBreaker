using Objects.Objets;
using System.Windows.Forms;

namespace Objects.Observer
{
    public class Mouvement
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

        public Mouvement(Balle balle, Raquette raquette, ZoneDeJeu zoneDeJeu)
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
                raquette.DeplacerRaquette(-VITESSE, zoneDeJeu.MurGauche, zoneDeJeu.MurDroit);
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
            int Dx = balle.BalleDX;
            int Dy = balle.BalleDY;
            int pX = balle.BalleX;
            int pY = balle.BalleY;


            // Mettre à jour la direction de la balle si elle entre en collision avec le mur
            if (pX < zoneDeJeu.MurGauche || pX > zoneDeJeu.MurDroit)
            {
                Dx = -Dx;
            }
            if (balle.BalleY < 0)
            {
                Dy = -Dy;
            }

            if (balle.GetPositionY() + Dy > raquette.PositionY)
            {
                // Mettre à jour la direction de la balle si elle entre en collision avec la raquette
                if (
                 pX + Dx > raquette.PositionX
                && pX + Dx < raquette.PositionX + raquette.Largeur)
                {
                    Dy = -Dy;
                }
                else // Si la balle passe en dessous de la raquette
                {
                    //Fin de partie
                }
            }
            balle.DeplacerBalle(Dx,Dy);
        }
    }
}
