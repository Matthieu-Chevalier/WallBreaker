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
            this.balle.ImposerContrainte(zoneDeJeu);
            this.raquette.ImposerContrainte(zoneDeJeu);

            //Ajouter un observateur:
            this.raquette.AjouterObservateur(balle);
        }



        public void KeyBoardReaction(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left)
            {
                raquette.DeplacerGauche(VITESSE);
            }
            if (e.KeyCode == Keys.Right)
            {
                raquette.DeplacerDroite(VITESSE);
            }
            if (e.KeyCode == Keys.Space)
            {
                IsPaused = !IsPaused;
            }
        }

        public void Run()
        {
            

            
            balle.DeplacerBalle();
        }
    }
}
