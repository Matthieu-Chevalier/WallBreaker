using Objects.Objets;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Objects.Observer
{
    public class Mouvement
    {
        private const int VITESSE = 10; //Vitesse de déplacement de la raquette
        private Balle balle;
        private Raquette raquette;
        private bool _isPaused;
        private List<Brique> Collisables;
        private Brique[,] Briques;

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
            IsPaused = true;
            this.balle.ImposerContrainte(zoneDeJeu);
            this.raquette.ImposerContrainte(zoneDeJeu);

            //Ajouter un observateur:
            this.raquette.AjouterObservateur(balle);

            Briques = new Brique[3, 3]
            {
                 {new Brique(1,this), new Brique(1, this), new Brique(1, this) },
                 {new Brique(1,this), new Brique(1, this), new Brique(1, this) },
                 {new Brique(1,this), new Brique(1, this), new Brique(1, this) }
            };
          
        }



        public void KeyBoardReaction(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left && IsPaused == false)
            {
                raquette.DeplacerGauche(VITESSE);
            }
            if (e.KeyCode == Keys.Right && IsPaused == false)
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
            if(!IsPaused)
            {
            balle.DeplacerBalle();

            }
            
        }

        public void SupprimerBrique(Brique brique)
        {
            Collisables.Remove(brique);
        }
        public void AjouterCollisable(Brique brique)
        {
            Collisables.Add(brique);
        }
        private void InitialiseMurDeBrique()
        {
            for(int i=0; i<3;i++)
            {
                for(int j=0; j<3;j++) 
                {
                    Collisables.Add(Briques[i, j]);
                }
            }
        }
    }
}
