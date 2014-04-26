using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Student_exams
{
    public partial class Play : Form
    {
        Game game;
       public int profSelected = 0;
       public int x;
       public int y;
        public Play()
        {
            InitializeComponent();
            game = new Game(this, 0);
            game.init();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            game.play();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            profSelected = 1;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            profSelected = 2;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            profSelected = 3;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            profSelected = 4;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            profSelected = 5;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            profSelected = 6;
        }

        private void pbox_MouseUp(object sender, MouseEventArgs e)
        {
            if (profSelected != 0)
            {
                game.createProfesor(profSelected, e.X, e.Y);
                profSelected = 0;
            }
        }

        private void pbox_MouseMove(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
        }

        private void pbox_MouseDown(object sender, MouseEventArgs e)
        {
            x = e.X;
            y = e.Y;
            if (game.canGenProf())
            {
                tbAtackSpeed.Text = "";
                tbDem.Text = "";
                tbRange.Text = "";
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
