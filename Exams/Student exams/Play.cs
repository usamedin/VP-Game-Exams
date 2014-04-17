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
        public Play()
        {
            InitializeComponent();
            game = new Game(this);
            game.init();
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            game.play();
        }
        private void pbox_Click(object sender, EventArgs e)
        {

        }
    }
}
