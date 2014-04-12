using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Student_exams
{
    class ObjectOnMap
    {
        public Point position { get; set; }
        public Point centerPosition { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int speed { get; set; }

        public ObjectOnMap(Point position, int width, int height, int speed)
        {
            this.speed = speed;
            this.position = position;
            this.width = width;
            this.height = height;
            this.centerPosition =new Point( position.x+(width/2), position.y+(height/2));
        }
    }
}
