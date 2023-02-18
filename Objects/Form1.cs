using Objects.Dessins;
using Objects.Objets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Objects
{
    public partial class Form1 : Form
    {
        private const int VITESSE = 10;
        public Dessin dessin;
        public Raquette raquette;
        public ZoneDeJeu ZoneDeJeu;
        public Balle Balle;
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered= true;
            int raquettePosX = this.ClientSize.Width / 2 - 50; // Centré horizontalement
            int raquettePosY = this.ClientSize.Height * 4 / 5 - 20; // A un cinquième de la hauteur à partir du bas
            ZoneDeJeu = new ZoneDeJeu(10, ClientSize.Height - 10, 10, ClientSize.Width - 10);
            raquette = new Raquette(raquettePosX, raquettePosY, 50, 100);
            Balle = new Balle(raquettePosX+50, raquettePosY-15, 10, -10, 15);
            dessin = new Dessin(CreateGraphics());

            gameTimer.Start();

        }

        public void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            dessin.DessinerRaquette(raquette, g);
            dessin.DessinerZoneDeJeu(ZoneDeJeu, g);
            dessin.DessinerBalle(Balle, g);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //TODO à déplacer dans la couche "Physique"
            // Physique.DeplacerRaquette(e.KeyCode)
            if (e.KeyCode == Keys.Left && raquette.PositionX>0)
            {
                raquette.DeplacerRaquette(-VITESSE);
            }
            if(e.KeyCode == Keys.Right && (raquette.PositionX+raquette.Largeur)<this.ClientSize.Width)
            {
                raquette.DeplacerRaquette(VITESSE);
            }
            Invalidate();
        }
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //TODO à déplacer dans la couche "Physique"
            // Mettre à jour la position de la balle
            Balle.BalleX += Balle.BalleDX;
            Balle.BalleY += Balle.BalleDY;


            // Mettre à jour la direction de la balle si elle entre en collision avec le mur
            if (Balle.BalleX < 0 || Balle.BalleX > ClientSize.Width)
            {
                Balle.BalleDX = -Balle.BalleDX;
            }
            if (Balle.BalleY < 0)
            {
                Balle.BalleDY = -Balle.BalleDY;
            }

            // Mettre à jour la direction de la balle si elle entre en collision avec la raquette
            if (Balle.BalleY + Balle.BalleDY > raquette.PositionY
                && Balle.BalleX + Balle.BalleDX > raquette.PositionX 
                && Balle.BalleX + Balle.BalleDY < raquette.PositionX + raquette.Largeur)
            {
                Balle.BalleDY = -Balle.BalleDY;
            }

            // Mettre à jour l'affichage
            Invalidate();
        }
    }
}
