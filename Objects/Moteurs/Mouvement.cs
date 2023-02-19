using Objects.Objets;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Objects.Observer
{
    public class Mouvement
    {
        private const int VITESSE = 10; //Vitesse de déplacement de la raquette
        private Balle balle;
        private Raquette raquette;
        private bool _isPaused;
        public readonly List<Brique> Collisables;
        private Brique[,] Briques;
        private const int WALLSTARTX = 100;
        private const int WALLSTARTY = 100;
        private const int LARGEURBRIQUE = 50;
        private const int HAUTEURBRIQUE = 50;

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
                 {new Brique(1,this), null, new Brique(1, this) },
                 {new Brique(1,this), new Brique(1, this), new Brique(1, this) }
            };
            Collisables = new List<Brique>();
            InitialiseBriquePositions();
            InitialiseCollisable();

        }

        private void InitialiseBriquePositions()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Briques[i, j] != null)
                    {
                        Briques[i, j].SetPosition(WALLSTARTX + i * LARGEURBRIQUE, WALLSTARTY + j * HAUTEURBRIQUE);
                    }
                }
            }
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
            if (!IsPaused)
            {
                CheckCollisions(balle);
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
        private void InitialiseCollisable()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Briques[i, j] != null)
                    {
                        Collisables.Add(Briques[i, j]);
                    }
                }
            }
        }
        private void CheckCollisions(Balle balle)
        {
            List<Brique> list = new List<Brique>();
            list.AddRange(Collisables);
            foreach (Brique brique in list)
            {
                //Logique de test
                Rectangle intersection = Rectangle.Intersect(brique.GetRectangle(), balle.GetBallRectangle());
                if (intersection != Rectangle.Empty)
                {
                    // Balle touche le haut ou le bas de la brique
                    if (intersection.Width > intersection.Height)
                    {
                        balle.InverserY();
                        
                    }
                    // Balle touche le côté gauche ou droit de la brique
                    else
                    {
                        balle.InverserX();
                    }
                    //notifier la brique
                    brique.Affaiblir();

                }

                //Si collision:

                //Notifier la balle
                //Balle.CollisionBrique(string sens) (up,down,left,right)
            }
        }
    }
}
