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
    public partial class Pause : Form
    {
        Play p;
        int level;
        public Pause(Play p,int level)
        {
            InitializeComponent();
            this.p = p;
            this.level = level;
            p.timer.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            p.timer.Start();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            p.Close();
            Play newGame = new Play(level);
            this.Close();
            newGame.Show();
             
        }

        private void button3_Click(object sender, EventArgs e)
        {
            p.Close();
            this.Close();
        }
    }
}
