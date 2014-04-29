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
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            About formAbout = new About();
            formAbout.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Play formPlay = new Play(comboBox1.SelectedIndex);
            formPlay.Show();

        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.ColorTranslator.FromHtml("#006699");
        }
    }
}
