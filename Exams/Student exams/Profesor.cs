using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Student_exams
{
    class Profesor :ObjectOnMap
    {
        public int demage { get; set; }
        public int range { get; set; }

        public Profesor( Point position,int width,int height, int atackSpeed, int demage, int range)
            :base(position,width,height,atackSpeed)
        {
            this.demage = demage;
            this.range = range;
        }

        public bool isEnemyInRange(Point centerPosEnemy)
        {
            double distanceDiference = Math.Sqrt(Math.Pow((centerPosition.x - centerPosEnemy.x), 2) + Math.Pow((centerPosition.y - centerPosEnemy.y), 2));
            if (distanceDiference < range)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}
