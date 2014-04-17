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
        public System.Windows.Forms.PictureBox pbox;
        List<Profesor> profesors;
        List<Student> students;
        List<Bullet> bullets;

        public Game(Play p)
        {
            this.formPlay = p;
        }
        Play formPlay;
        Bitmap bitMap;

        Profesor p;
        Profesor p1;
        Student st;
        Bullet bu;

        public void play()
        {
            drowScreen();
            moveBullets();
            moveStudents();

        }

        public void init()
        {
            profesors = new List<Profesor>();
            students = new List<Student>();
            bullets = new List<Bullet>();
            pbox = formPlay.pbox;

            p = new Profesor(new Point(100, 100), 30, 30, 1000, 20, 100);
            p1 = new Profesor(new Point(400, 400), 30, 30, 1000, 20, 300);
            st = new Student(new Point(200, 400), 20, 20, 2, 1, 20);

            profesors.Add(p);
            profesors.Add(p1);
            students.Add(st);

            if (p1.isEnemyInRange(st.centerPosition))
            {
                bu = new Bullet(new Point(p1.position.x, p1.position.y), 10, 10, 20, st.centerPosition, p1.centerPosition, 50);
                bullets.Add(bu);
            }
        }
       

        public void drowScreen()
        {
            bitMap = new Bitmap(pbox.Width, pbox.Height);
            using (Graphics g = Graphics.FromImage(bitMap))
            {
                g.FillRectangle(Brushes.White, new Rectangle(0, 0, pbox.Width, pbox.Height));
                for (int i = 0; i < profesors.Count; i++)
                {
                    drowProfesor(profesors[i], g);
                }

                for (int i = 0; i < students.Count; i++)
                {
                    g.FillRectangle(Brushes.Red, new Rectangle(students[i].position.x, students[i].position.y, students[i].width, students[i].height));
                }

                for (int i = 0; i < bullets.Count; i++)
                {
                    g.FillRectangle(Brushes.Blue, new Rectangle(bullets[i].position.x, bullets[i].position.y, bullets[i].width, bullets[i].height));
                }
                pbox.CreateGraphics().DrawImageUnscaled(bitMap, 0, 0);
            }
            bitMap.Dispose();
            bitMap = null;
        }

        public void drowProfesor(Profesor p, Graphics g)
        {
            g.FillRectangle(Brushes.Black, new Rectangle(p.position.x, p.position.y, p.width, p.height));
            g.DrawEllipse(new Pen(Brushes.Green), p.centerPosition.x - p.range, p.centerPosition.y - p.range, p.range * 2, p.range * 2);
        }
        public void moveStudents()
        {
            for (int i = 0; i < students.Count; i++)
            {
                students[i].moveStudent();
            }
        }
        
        public void moveBullets()
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                for (int j = 0; i < students.Count; i++)
                {
                    if (bullets[i].hitEnemy(students[j]))
                    {
                        students[j].health -= bullets[i].demage;
                        if (students[j].health < 0)
                        {
                            students.RemoveAt(j);
                        }
                        bullets.RemoveAt(i);
                        break;
                    }
                    else
                    {
                        moveBulletPosition(bullets[i]);
                    }
                }
            }
        }
        public void moveBulletPosition(Bullet b)
        {
            //Witch coordinate to increment
            if (b.moveXorY == 1)
            {
                b.position.x += b.speed * b.moveDir;
                b.position.y = (int)(b.mKoeficient * (b.position.x - b.target.x) + b.target.y);
                //System.Windows.Forms.MessageBox.Show("y");
            }
            else
            {
                b.position.y += b.speed * b.moveDir;
                b.position.x = (int)(b.mKoeficient * (b.position.y - b.target.y) + b.target.x);
            }
            b.centerPosition = new Point(b.position.x + (b.width / 2), b.position.y + (b.height / 2));
        }

    }
}