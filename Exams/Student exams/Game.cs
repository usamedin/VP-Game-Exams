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
        Stage[] stages = Data.stages;
        int level;
        int timer;
        int generatedStudents;
        int sClass;
        int nextStudentSpown;

        public Game(Play p, int level)
        {
            this.formPlay = p;
            this.level = level;
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
            genStudent();
            moveBullets();
            moveStudents();
            timer++;
        }

        public void init()
        {
            profesors = new List<Profesor>();
            students = new List<Student>();
            bullets = new List<Bullet>();
            pbox = formPlay.pbox;
            timer = 0;
            sClass = 0;
            generatedStudents = 0;
            nextStudentSpown = 0;

            p = new Profesor(new Point(100, 100), 30, 30, 1000, 20, 100);
            p1 = new Profesor(new Point(400, 400), 30, 30, 1000, 20, 300);
            st = new Student(new Point(200, 400), 20, 20, 2, 1, 20);

          //  profesors.Add(p);
            profesors.Add(p1);
            students.Add(st);

            if (p1.isEnemyInRange(st.centerPosition))
            {
                bu = new Bullet(new Point(p1.position.x, p1.position.y), 10, 10, 1, st.centerPosition, p1.centerPosition, 50);
                bullets.Add(bu);
            }
        }
        public void genStudent()
        {
            if (sClass < stages[level].classes)
            {
                if (generatedStudents < stages[level].studentsPerClas)
                {
                    if (nextStudentSpown >= timer)
                    {
                        Student student = new Student(stages[level].startPosition, 20, 20, 2, 2, 100);
                        students.Add(student);// here is the problem
                        nextStudentSpown = timer + 260;
                    }
                }
                else
                {
                    generatedStudents = 0;
                    nextStudentSpown = timer + 300;
                }
            }
        }

        public void drowScreen()
        {
            bitMap = new Bitmap(pbox.Width, pbox.Height);
            using (Graphics g = Graphics.FromImage(bitMap))
            {
                g.FillRectangle(Brushes.White, new Rectangle(0, 0, pbox.Width, pbox.Height));

                drowStage(g);
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


        public void drowStage(Graphics g)
        {
            int x, y, pathWidth, lastDir;
            pathWidth = 60;
            int width = 0, height = 0;
            Color colour = System.Drawing.ColorTranslator.FromHtml("#339900");
            g.FillRectangle(new SolidBrush(colour), new Rectangle(stages[level].startPosition.x, stages[level].startPosition.y, stages[level].checkpoints[0].value + pathWidth, pathWidth));
            y = stages[level].startPosition.y;
            x = stages[level].checkpoints[0].value;
            lastDir = 2;
            for (int i = 0; i < stages[level].numCP - 1; i++)
            {
                if (lastDir == 2)
                {
                    if (stages[level].checkpoints[i].coordinate == 3)
                    {
                        if (i != 0)
                        {
                            y = stages[level].checkpoints[i - 1].value;
                            x = stages[level].checkpoints[i].value;
                        }
                        width = pathWidth;
                        height = stages[level].checkpoints[i + 1].value - y + pathWidth;
                    }
                    else if (stages[level].checkpoints[i].coordinate == 1)
                    {
                        x = stages[level].checkpoints[i].value;
                        y = stages[level].checkpoints[i + 1].value;
                        width = pathWidth;
                        height = y - stages[level].checkpoints[i + 1].value + pathWidth;
                    }
                }
                else if (lastDir == 3)
                {
                    if (stages[level].checkpoints[i].coordinate == 4)
                    {
                        x = stages[level].checkpoints[i + 1].value;
                        y = stages[level].checkpoints[i].value;
                        width = stages[level].checkpoints[i - 1].value - x;
                        height = pathWidth;
                    }
                    else if (stages[level].checkpoints[i].coordinate == 2)
                    {
                        x = stages[level].checkpoints[i - 1].value;
                        y = stages[level].checkpoints[i].value;
                        width = stages[level].checkpoints[i + 1].value - x;
                        height = pathWidth;
                    }

                }
                else if (lastDir == 4)
                {
                    if (stages[level].checkpoints[i].coordinate == 3)
                    {
                        x = stages[level].checkpoints[i].value;
                        y = stages[level].checkpoints[i - 1].value;
                        width = pathWidth;
                        height = stages[level].checkpoints[i + 1].value - y + pathWidth;
                    }
                    else if (stages[level].checkpoints[i].coordinate == 1)
                    {
                        x = stages[level].checkpoints[i].value;
                        y = stages[level].checkpoints[i + 1].value;
                        width = pathWidth;
                        height = y - stages[level].checkpoints[i + 1].value + pathWidth;
                    }

                }
                else if (lastDir == 1)
                {
                    if (stages[level].checkpoints[i].coordinate == 4)
                    {
                        x = stages[level].checkpoints[i + 1].value;
                        y = stages[level].checkpoints[i].value;
                        width = stages[level].checkpoints[i - 1].value - x;
                        height = pathWidth;
                    }
                    else if (stages[level].checkpoints[i].coordinate == 2)
                    {
                        x = stages[level].checkpoints[i].value;
                        y = stages[level].checkpoints[i + 1].value;
                        width = stages[level].checkpoints[i + 1].value - x;
                        height = pathWidth;
                    }

                }

                lastDir = stages[level].checkpoints[i].coordinate;
                g.FillRectangle(new SolidBrush(colour), new Rectangle(x, y, width, height));
            }
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
                students[i].moveStudent(stages[level].checkpoints);
            }
        }

        public void moveBullets()
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                for (int j = 0; j < students.Count; j++)
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