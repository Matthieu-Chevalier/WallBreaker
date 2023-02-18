﻿using Objects.Dessins;
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
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered= true;
            int raquettePosX = this.ClientSize.Width / 2 - 50; // Centré horizontalement
            int raquettePosY = this.ClientSize.Height * 4 / 5 - 20; // A un cinquième de la hauteur à partir du bas

            raquette = new Raquette(raquettePosX, raquettePosY, 50, 100);
            dessin = new Dessin(CreateGraphics());


        }

        public void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            dessin.DessinerRaquette(raquette, g);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Left && raquette.PositionX>0)
            {
                raquette.DeplacerRaquette(-VITESSE);
            }
            if(e.KeyCode == Keys.Right && (raquette.PositionX+raquette.Largeur)<this.ClientSize.Width)
            {
                raquette.DeplacerRaquette(VITESSE);
            }
            Invalidate();
        }
    }
}
