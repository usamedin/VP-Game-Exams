using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Student_exams
{
    class Student : ObjectOnMap
    {
        public int checkpoint { get; set; }
        //valid values: 1-Top 2-Right 3-Bot 4-Left
        public int direction { get; set; }
        public int health { get; set; }
        public int cost { get; set; }
        public Image img { get; set; }
        public string imgS;

        public Student(Point position, int width, int height, int speed, int direction, int health,int cost,string imgS)
            : base(position, width, height, speed)
        {
            this.imgS = imgS;
            this.cost = cost;
            this.position = new Point(position);
            this.centerPosition = new Point(position.x + (width / 2), position.y + (height / 2));
            this.speed = speed;
            this.checkpoint = 0;
            this.direction = direction;
            this.health = health;
            this.width = width;
            this.height = height;
            setImage(imgS);
        }
        public void setImage(string img)
        {
            this.img = Image.FromFile("../../Students/" + img + ".png");
        }
        public bool moveStudent(Checkpoint[] ch)
        {
            Random r = new Random();
            int ofset = r.Next(1, 39);
            if (checkpoint == ch.Count())
            {
                return false;
            }
            string newimg;
            switch (direction)
            {
                case 1:
                    position.y -= speed;
                    centerPosition.y -= speed;
                    if (position.y < ch[checkpoint].value+ofset)
                    {
                        direction = ch[checkpoint].coordinate;
                        checkpoint++;
                    }
                    break;

                case 2:
                    position.x += speed;
                    centerPosition.x += speed;
                    if (position.x > ch[checkpoint].value + ofset)
                    {
                        direction = ch[checkpoint].coordinate;
                        checkpoint++;
                        newimg = imgS[0] + "4";
                        setImage(newimg);
                    }
                    break;

                case 3:
                    position.y += speed;
                    centerPosition.y += speed;
                    if (position.y > ch[checkpoint].value + ofset)
                    {
                        direction = ch[checkpoint].coordinate;
                        checkpoint++;
                        
                    }
                    break;

                case 4:
                    position.x -= speed;
                    centerPosition.x -= speed;
                    if (position.x < ch[checkpoint].value + ofset)
                    {
                        direction = ch[checkpoint].coordinate;
                        checkpoint++;
                        newimg = imgS[0] + "2";
                        setImage(newimg);
                    }
                    break;
            }
            return true;
        }
    }
}
