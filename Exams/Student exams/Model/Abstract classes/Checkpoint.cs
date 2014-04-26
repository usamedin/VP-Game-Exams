using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Student_exams
{
    class Checkpoint
    {
        //witch coordinate will change 1=-y 2=x 3=y 4=-x    1-Top 2-Right 3-Bot 4-Left
        public int coordinate { get; set; }
        //value of coordinate
        public int value { get; set; }
        public Checkpoint(int coordinate, int value)
        {
            this.coordinate = coordinate;
            this.value = value;
        }
    }
}
