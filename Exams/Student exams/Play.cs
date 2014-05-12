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
        public int profRange = 0;
        public int x;
        public int y;
        public bool pbClicked = false;
        int levelV;
        public Play(int level)
        {
            this.levelV = level;
            InitializeComponent();
            game = new Game(this, level);
            game.init();
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#006699");
            
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            game.play();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            profSelected = 1;
            profRange = 100;
            game.showDetails(profSelected);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            profSelected = 2;
            profRange = 150;
            game.showDetails(profSelected);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            profSelected = 3;
            profRange = 100;
            game.showDetails(profSelected);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            profSelected = 4;
            profRange = 200;
            game.showDetails(profSelected);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            profSelected = 5;
            profRange = 300;
            game.showDetails(profSelected);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            profSelected = 6;
            profRange = 200;
            game.showDetails(profSelected);
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

        private void Play_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Escape)
            {
                profSelected = 0;
            }
        }

        private void Play_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void pictureBox2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                profSelected = 0;
            }
        }

        private void Play_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pause p = new Pause(this , levelV);
            p.Show();
        }
    }
}
