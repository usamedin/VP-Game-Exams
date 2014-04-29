using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
namespace Student_exams
{
    class Profesor :ObjectOnMap
    {
        public int demage { get; set; }
        public int range { get; set; }
        public int nextBullet { get; set; }
        public int fireRate { get; set; }
        public int price { get; set; }
        public int MyProperty { get; set; }
        public Image  img { get; set; }
        public Profesor( Point position,int width,int height, int demage, int range,int fireRate,int price,string img)
            :base(position,width,height,0)
        {
            this.price = price;
            this.fireRate = fireRate;
            this.demage = demage;
            this.range = range;
            this.nextBullet = 0;
            setImage(img);
        }
        public void setImage(string img)
        {
            this.img = Image.FromFile("Profesors/"+img+".png");
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
