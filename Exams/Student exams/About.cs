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
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            story.Text = "This is Tower defence game, Strategic game \nwhere you should place the profesors in a \nway to stop students to pass exams.";
        }
    }
}
