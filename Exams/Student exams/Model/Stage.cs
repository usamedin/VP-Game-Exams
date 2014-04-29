using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Student_exams
{
    class Stage
    {
        public Checkpoint[] checkpoints { get; set; }
        public int numCP { get; set; }
        public Point startPosition { get; set; }
        public int studentsPerClas { get; set; }
        public int classes { get; set; }
        public int startingCash { get; set; }
        public int studentHealth { get; set; }
        public int studentSpeed { get; set; }
        public Stage(Point startPosition, Checkpoint[] checkpoints, int numCP, int classes, int spc,int startingCash, int studentHealth,int studentSpeed)
        {
            this.studentSpeed = studentSpeed;
            this.checkpoints = checkpoints;
            this.startPosition = startPosition;
            this.numCP = numCP;
            this.classes = classes;
            this.startingCash = startingCash;
            this.studentsPerClas = spc;
            this.studentHealth = studentHealth;
        }
        public void drowStage(Stage s,Graphics g)
        {
            int x, y, pathWidth, lastDir;
            pathWidth = 60;
            int width = 0, height = 0;
            Color color = System.Drawing.ColorTranslator.FromHtml("#339900");
            g.FillRectangle(new SolidBrush(color), new Rectangle(s.startPosition.x, s.startPosition.y, s.checkpoints[0].value + pathWidth, pathWidth));
            y = s.startPosition.y;
            x = s.checkpoints[0].value;
            lastDir = 2;
            for (int i = 0; i < s.numCP - 1; i++)
            {
                if (lastDir == 2)
                {
                    if (s.checkpoints[i].coordinate == 3)
                    {
                        if (i != 0)
                        {
                            y = s.checkpoints[i - 1].value;
                            x = s.checkpoints[i].value;
                        }
                        width = pathWidth;
                        height = s.checkpoints[i + 1].value - y + pathWidth;
                    }
                    else if (s.checkpoints[i].coordinate == 1)
                    {
                        x = s.checkpoints[i].value;
                        y = s.checkpoints[i + 1].value;
                        width = pathWidth;
                        height = s.checkpoints[i - 1].value-y + pathWidth;
                    }
                }
                else if (lastDir == 3)
                {
                    if (s.checkpoints[i].coordinate == 4)
                    {
                        x = s.checkpoints[i + 1].value;
                        y = s.checkpoints[i].value;
                        width = s.checkpoints[i - 1].value - x;
                        height = pathWidth;
                    }
                    else if (s.checkpoints[i].coordinate == 2)
                    {
                        x = s.checkpoints[i - 1].value;
                        y = s.checkpoints[i].value;
                        width = s.checkpoints[i + 1].value - x;
                        height = pathWidth;
                    }

                }
                else if (lastDir == 4)
                {
                    if (s.checkpoints[i].coordinate == 3)
                    {
                        x = s.checkpoints[i].value;
                        y = s.checkpoints[i - 1].value;
                        width = pathWidth;
                        height = s.checkpoints[i + 1].value - y + pathWidth;
                    }
                    else if (s.checkpoints[i].coordinate == 1)
                    {
                        x = s.checkpoints[i].value;
                        y = s.checkpoints[i + 1].value;
                        width = pathWidth;
                        height = y - s.checkpoints[i + 1].value + pathWidth;
                    }

                }
                else if (lastDir == 1)
                {
                    if (s.checkpoints[i].coordinate == 4)
                    {
                        x = s.checkpoints[i + 1].value;
                        y = s.checkpoints[i].value;
                        width = s.checkpoints[i - 1].value - x;
                        height = pathWidth;
                    }
                    else if (s.checkpoints[i].coordinate == 2)
                    {
                        x = s.checkpoints[i-1].value;
                        y = s.checkpoints[i].value;
                        width = s.checkpoints[i + 1].value - x;
                        height = pathWidth;
                    }

                }

                lastDir = s.checkpoints[i].coordinate;
                g.FillRectangle(new SolidBrush(color), new Rectangle(x, y, width, height));
            }
            x = s.checkpoints[s.numCP-1].value;
           // y = s.checkpoints[i + 1].value;
            color = System.Drawing.ColorTranslator.FromHtml("#993399");
            g.FillRectangle(new SolidBrush(color), new Rectangle(x, y-20, 100, 100));
        }
    }
}
