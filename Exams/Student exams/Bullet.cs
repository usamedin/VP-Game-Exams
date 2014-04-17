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

        public float mKoeficient { get; set; }
        public int moveDir { get; set; }
        public int moveXorY { get; set; }

        public Bullet(Point position, int width, int height,int speed, Point target, Point sorce, int demage)
            : base(position, width, height, speed)
        {
            if (Math.Abs(sorce.x - target.x) > Math.Abs(sorce.y - target.y))
            {
                moveXorY = 1;
            }
            else
            {
                moveXorY = 0;
            }

            if (moveXorY == 1)
            {
                moveDir = bulletDir(sorce.x, target.x);
                mKoeficient = mKoeficientX(sorce, target);
            }
            else
            {
                moveDir = bulletDir(sorce.y, target.y);
                mKoeficient = mKoeficientY(sorce, target);
            }
            this.sorce = sorce;
            this.target =target;
            this.demage = demage;
        }

        
        public float mKoeficientX(Point p, Point s)
        {
            int f = (p.x - s.x);
            if (f != 0)
            {
                return (p.y - s.y) * 1.0f / f;
            }
            else
            {
                return 1;
            }
        }
        public float mKoeficientY(Point p, Point s)
        {
            int f = (p.y - s.y);
            if (f != 0)
            {
                return (p.x - s.x) * 1.0f / f;
            }
            else
            {
                return 1;
            }
        }
        public int bulletDir(int p, int s)
        {
            if ((s - p) > 0)
            {
                return 1;
            }
            else
            {
                return -1;
            }
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
