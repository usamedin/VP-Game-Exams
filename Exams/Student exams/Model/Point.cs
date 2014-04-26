using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Student_exams
{
    class Point
    {
        public int x { get; set; }
        public int y { get; set; }
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Point(Point t)
        {
            this.x = t.x;
            this.y = t.y;
        }
    }
}
