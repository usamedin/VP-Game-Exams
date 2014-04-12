using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;

namespace Student_exams
{
    class Game
    {
        public Game(Play p)
        {
            this.formPlay = p;
        }
        Play formPlay;
        Bitmap bufl;
        Profesor p;
        Profesor p1;
        Student s;
        public System.Windows.Forms.PictureBox pbox;
       
        Bullet b;
        public void init()
        {
            pbox = formPlay.pbox;

            p = new Profesor(new Point(100, 100), 30, 30, 1000, 20, 100);
            p1 = new Profesor(new Point(400, 400), 30, 30, 1000, 20, 300);
            s = new Student(new Point(200,200), 20, 20, 5, 2, 200);
            if (p1.isEnemyInRange(s.centerPosition))
            {
                b = new Bullet(new Point(p1.position.x, p1.position.y), 10, 10,1, s.centerPosition, p1.centerPosition, 50);
                //  System.Windows.Forms.MessageBox.Show(b.centerPosition.x+" "+b.centerPosition.y+"");
            }
        }
        public void play()
        {

            bufl = new Bitmap(pbox.Width, pbox.Height);
            using (Graphics g = Graphics.FromImage(bufl))
            {
               // g.FillRectangle(Brushes.White, new Rectangle(0, 0, pbox.Width, pbox.Height));
                drowProfesor(p, g);
                drowProfesor(p1, g);
                drowStudent(s, g);
                if (b != null)
                {
                    drowBullet(b, g);
                }
               pbox.CreateGraphics().DrawImageUnscaled(bufl, 0, 0);
            }
            
            if (b != null)
            {
                if (!b.hitEnemy(s))
                {
                    moveBullet(b);
                }
            }
            bufl.Dispose();
            bufl = null;
            
        }
        public void drowProfesor(Profesor p, Graphics g)
        {
            g.FillRectangle(Brushes.Black, new Rectangle(p.position.x, p.position.y, p.width, p.height));
            g.DrawEllipse(new Pen(Brushes.Green), p.centerPosition.x - p.range, p.centerPosition.y - p.range, p.range * 2, p.range * 2);

        }

        public void drowStudent(Student s, Graphics g)
        {
            g.FillRectangle(Brushes.Red, new Rectangle(s.position.x, s.position.y, s.width, s.height));
        }

        public void drowBullet(Bullet b, Graphics g)
        {
            g.FillRectangle(Brushes.Blue, new Rectangle(b.position.x, b.position.y, b.width, b.height));
        }
        public int bulletXDir(int  p, int s)
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
        public void moveBullet(Bullet b)
        {
            if (Math.Abs(b.sorce.x - b.target.x) < Math.Abs(b.sorce.y - b.target.y))
            {
                b.position.x += b.speed * bulletXDir(b.sorce.x, b.target.x);
                b.position.y = ((b.sorce.y - b.target.y) / (b.sorce.x - b.target.x)) * (b.position.x - b.target.x) + b.target.y;
                //System.Windows.Forms.MessageBox.Show("y");
            }
            else
            {
                //System.Windows.Forms.MessageBox.Show("x");
                b.position.y += b.speed * bulletXDir(b.sorce.y, b.target.y);
                b.position.x = ((b.sorce.x - b.target.x) / (b.sorce.y - b.target.y)) * (b.position.y - b.target.y) + b.target.x;
            }
            b.centerPosition = new Point(b.position.x + (b.width / 2), b.position.y + (b.height / 2));
        }

    }
}
