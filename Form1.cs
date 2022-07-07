using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tetris;

namespace tetriswinforms
{
    public partial class Form1 : Form
    {
        private Graphics g;
        Gra game;
        PreviewKeyDownEventArgs ster;
        public Form1()
        {
            this.KeyPreview = true;
            InitializeComponent();
            game = new Gra(10, 15, g);
            timer1.Interval = 500;
        }

        public void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush r = new SolidBrush(Color.Red);
            g = e.Graphics;
            game.pl.Druk(e.Graphics);
        }
        
        private void Form1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    if (game.pl.KolizjaObrót(game.b, true) == false)
                    {
                        game.b.Obrót(true);
                        pictureBox1.Refresh();
                    }
                    break;

                case Keys.Right:
                    if (game.pl.KolizjaPrawo(game.b) == false)
                        game.b.MoveRight();
                    break;

                case Keys.Left:
                    if (game.pl.KolizjaLewo(game.b) == false)
                        game.b.MoveLeft();
                    break;

                case Keys.Down:
                    if (game.pl.KolizjaDół(game.b) == false)
                        game.b.MoveDown();
                    break;
            }
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            if(game.koniec==false)
                game.Ruch();
            else
            {
                sTOPToolStripMenuItem_Click(sender, e);
            }
            textBox1.Text = game.Punkty();
        }

        private void sTARTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
        }

        private void sTOPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timer2.Stop();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void nOWAGRAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game = new Gra(10, 15, g);
            timer1.Start();
            timer2.Start();
        }
    }
}
