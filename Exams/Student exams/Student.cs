using System;
using System.Collections.Generic;
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

        public Student(Point position, int width, int height, int speed, int direction, int health)
            : base(position, width, height, speed)
        {
            this.position = position;
            this.centerPosition = new Point(position.x + (width / 2), position.y + (height / 2));
            this.speed = speed;
            this.checkpoint = 0;
            this.direction = direction;
            this.health = health;
            this.width = width;
            this.height = height;
        }
    }
}
