using Objects.Dessins;
using Objects.Objets;
using Objects.Observer;
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
        
        public Dessin dessin;
        public Raquette raquette;
        public ZoneDeJeu ZoneDeJeu;
        public Balle Balle;
        public Moteur Moteur;
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
            Moteur = new Moteur(Balle, raquette, ZoneDeJeu);
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
            Moteur.KeyBoardReaction( e);
            
            Invalidate();
        }
        private void gameTimer_Tick(object sender, EventArgs e)
        {
            Moteur.Run();
            

            // Mettre à jour l'affichage
            Invalidate();
        }
    }
}
