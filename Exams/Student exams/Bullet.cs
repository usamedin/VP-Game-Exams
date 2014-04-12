using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Student_exams
{
    class Bullet : ObjectOnMap
    {
        public Point sorce { get; set; }
        public Point target { get; set; }
        public int  demage { get; set; }

        public Bullet(Point position, int width, int height,int speed, Point target, Point sorce, int demage)
            : base(position, width, height, speed)
        {
            this.sorce = sorce;
            this.target = target;
            this.demage = demage;
        }

        public bool hitEnemy(Student s)
        {
            //if x is target
            if ((centerPosition.x > (s.centerPosition.x - (s.width / 2))) && (centerPosition.x < (s.centerPosition.x + (s.width / 2))))
            {
                //if y is target
                if ((centerPosition.y > (s.centerPosition.y - (s.height / 2))) && (centerPosition.y < (s.centerPosition.y + (s.height / 2))))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
