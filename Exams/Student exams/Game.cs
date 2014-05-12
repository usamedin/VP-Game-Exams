using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace Student_exams
{
    class Game
    {
        public System.Windows.Forms.PictureBox pbox;
        List<Profesor> profesors;
        List<Student> students;
        List<Bullet> bullets;
        Play formPlay;
        Bitmap bitMap;
        Stage[] stages;
        int level;
        int timer;
        int generatedStudents;
        int sClass;
        int nextStudentSpown;
        int cash;
        int lives;
        int vave;
        public Game(Play p, int level)
        {
            this.formPlay = p;
            this.level = level;
        }
        public void play()
        {
            drowScreen();
            genStudent();
            moveBullets();
            moveStudents();
            fireBullet();
            timer++;
        }

        public void init()
        {
            profesors = new List<Profesor>();
            students = new List<Student>();
            bullets = new List<Bullet>();
            pbox = formPlay.pbox;
            stages = new Stage[Data.stages.Count()];
            for(int i=0;i<Data.stages.Count();i++){
                stages[i] = new Stage(Data.stages[i]);
            }
            cash = stages[level].startingCash;
            lives = 5;
            vave=1;
            timer = 0;
            sClass = 0;
            generatedStudents = 0;
            nextStudentSpown = 60;
            

            formPlay.cash.Text = cash + "";
            formPlay.level.Text = level + 1 + "";
            formPlay.lives.Text = lives + "";
            formPlay.tbVave.Text = "1/" + stages[level].classes;
        }
        public void createProfesor(int i, int x, int y)
        {
            Profesor prof = null;
            switch (i)
            {
                case 0:
                    prof = null;
                    break;
                case 1:
                    prof = new Profesor(new Point(x - 30, y - 30), 60, 60, 30, 100, 30,1000,"1");
                    break;
                case 2:
                    prof = new Profesor(new Point(x - 30, y - 30), 60, 60, 50, 150, 30, 1500, "2");
                    break;
                case 3:
                    prof = new Profesor(new Point(x - 30, y - 30), 60, 60, 40, 100, 15, 2000, "3");
                    break;
                case 4:
                    prof = new Profesor(new Point(x - 30, y - 30), 60, 60, 100, 200, 60, 2500, "4");
                    break;
                case 5:
                    prof = new Profesor(new Point(x - 30, y - 30), 60, 60, 120, 300, 50, 3000, "5");
                    break;
                case 6:
                    prof = new Profesor(new Point(x - 30, y - 30), 60, 60, 150, 200, 40, 3500, "6");
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
            if (prof != null && canGenProf())
            {
                if (cash >= prof.price)
                {
                    profesors.Add(prof);
                    cash -= prof.price;
                    formPlay.cash.Text = cash + "";
                }
            }
        }
        public void fireBullet()
        {
            for (int i = 0; i < profesors.Count; i++)
            {
                if (profesors[i].nextBullet <= timer)
                {
                    for (int j = 0; j < students.Count; j++)
                    {
                        if (profesors[i].nextBullet <= timer)
                        {
                            if (profesors[i].isEnemyInRange(students[j].centerPosition))
                            {
                                Bullet b = new Bullet(new Point(profesors[i].position.x, profesors[i].position.y), 10, 10, 5, students[j].centerPosition, profesors[i].centerPosition, profesors[i].demage);
                                bullets.Add(b);
                                profesors[i].nextBullet = timer + profesors[i].fireRate;
                            }
                        }
                    }
                }
            }

        }
        public void genStudent()
        {
            if (sClass < stages[level].classes)
            {
                if (generatedStudents < stages[level].studentsPerClas)
                {
                    if (nextStudentSpown <= timer)
                    {
                        formPlay.tbVave.Text = vave + "/" + stages[level].classes;
                        Random r = new Random();
                        int ofset = r.Next(1, 39);
                        Student student = new Student(new Point(stages[level].startPosition.x, stages[level].startPosition.y + ofset), 20, 20, stages[level].studentSpeed, 2, stages[level].studentHealth,(int)( stages[level].studentHealth*0.4), "12");
                        students.Add(student);// here is the problem
                        nextStudentSpown = timer + 30;
                        generatedStudents++;
                    }
                }
                else
                {
                    generatedStudents = 0;
                    nextStudentSpown = timer + 400;
                    sClass++;
                    stages[level].studentsPerClas = (int)(stages[level].studentsPerClas * 1.5);
                    stages[level].studentHealth = (int)(stages[level].studentHealth * 1.2);
                    vave++;
                }
            }
            else
            {
                if (students.Count == 0)
                {
                    formPlay.timer.Stop();
                        victory();
                }
            }
        }

        public void drowScreen()
        {
            bitMap = new Bitmap(pbox.Width, pbox.Height);
            using (Graphics g = Graphics.FromImage(bitMap))
            {
                Color color = System.Drawing.ColorTranslator.FromHtml("#006699");
                g.FillRectangle(new SolidBrush(color), new Rectangle(0, 0, pbox.Width, pbox.Height));

                stages[level].drowStage(stages[level], g);
                for (int i = 0; i < profesors.Count; i++)
                {
                    drowProfesor(profesors[i], g);
                }

                for (int i = 0; i < students.Count; i++)
                {
                    g.DrawRectangle(new Pen(Brushes.Black, 1), new Rectangle(students[i].position.x - 5, students[i].position.y - 10, students[i].width + 10, 3));
                    g.FillRectangle(Brushes.Blue, new Rectangle(students[i].position.x - 5, students[i].position.y - 10, (int)(((float)students[i].health / stages[level].studentHealth) * students[i].width + 10), 3));
                    g.DrawImage(students[i].img, students[i].position.x, students[i].position.y,20, 22);
                }

                for (int i = 0; i < bullets.Count; i++)
                {
                    g.FillEllipse(Brushes.Brown, bullets[i].position.x, bullets[i].position.y, bullets[i].width, bullets[i].height);
                   // g.FillRectangle(Brushes.Blue, new Rectangle(bullets[i].position.x, bullets[i].position.y, bullets[i].width, bullets[i].height));
                }
                if (formPlay.profSelected != 0)
                {
                    if (canGenProf())
                    {
                        g.FillRectangle(Brushes.Black, new Rectangle(formPlay.x - 15, formPlay.y - 15, 30, 30));
                    }
                    else
                    {
                        g.FillRectangle(Brushes.Red, new Rectangle(formPlay.x - 15, formPlay.y - 15, 30, 30));
                    }
                    g.DrawEllipse(new Pen(Brushes.Silver), formPlay.x - formPlay.profRange, formPlay.y - formPlay.profRange, formPlay.profRange * 2, formPlay.profRange * 2);

                }
                pbox.CreateGraphics().DrawImageUnscaled(bitMap, 0, 0);
            }
            bitMap.Dispose();
            bitMap = null;
        }
        public bool canGenProf()
        {
            for (int i = 0; i < profesors.Count; i++)
            {
                double distanceDiference = Math.Sqrt(Math.Pow((profesors[i].centerPosition.x - formPlay.x), 2) + Math.Pow((profesors[i].centerPosition.y - formPlay.y), 2));
                if (distanceDiference < 32)
                {
                    formPlay.tbDem.Text = profesors[i].demage+"";
                    formPlay.tbRange.Text = profesors[i].range+"";
                    formPlay.tbAtackSpeed.Text = profesors[i].fireRate+"";
                    formPlay.tbPrice.Text = profesors[i].price + "";
                    return false;
                }
            }
            return true;
        }

        public void drowProfesor(Profesor p, Graphics g)
        {
            g.DrawImage(p.img, p.position.x, p.position.y,60,60);
            g.DrawEllipse(new Pen(Brushes.Silver), p.centerPosition.x - p.range, p.centerPosition.y - p.range, p.range * 2, p.range * 2);
        }
        public void moveStudents()
        {
            for (int i = 0; i < students.Count; i++)
            {
                if (!students[i].moveStudent(stages[level].checkpoints))
                {
                    lives--;
                    formPlay.lives.Text = lives + "";
                    students.RemoveAt(i);
                    if (lives == 0)
                    {
                        gameOver();
                    }
                }
            }
        }

        private void gameOver()
        {
            formPlay.timer.Stop();
            if(MessageBox.Show("YOU LOSE!\nTry again", "DEFEAT",MessageBoxButtons.RetryCancel)==DialogResult.Cancel)
            {
                formPlay.Close();
            }
            else
            {
                formPlay.Close();
                Play formplay = new Play(level);
                formplay.Show();
            }
        }
        private void victory()
        {
            formPlay.timer.Stop();
            if (level == 2)
            {
                if (MessageBox.Show("YOU WIN!\nYou destroy them all!", "VICTORY", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    formPlay.Close();
                    return;
                }

            }
            if (MessageBox.Show("YOU WIN!\nContinue next level", "VICTORY",MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                formPlay.Close();
            }
            else
            {
                formPlay.Close();
                Play formplay = new Play(level+1);
                formplay.Show();
            }
        }
        public void moveBullets()
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                bool isLife = true;
                for (int j = 0; j < students.Count; j++)
                {
                    if (bullets[i].hitEnemy(students[j]))
                    {
                        students[j].health -= bullets[i].demage;
                        if (students[j].health <= 0)
                        {
                            cash += (int)(students[j].cost*0.7) ;
                            formPlay.cash.Text = cash + "";
                            students.RemoveAt(j);

                        }
                        bullets.RemoveAt(i);
                        isLife = false;
                        break;
                    }
                }
                if (!isLife)
                {
                    continue;
                }
                moveBulletPosition(bullets[i]);
            }
        }
        public void moveBulletPosition(Bullet b)
        {
            if (b.position.x < 0 || b.position.x > pbox.Width || b.position.y < 0 || b.position.y > pbox.Height)
            {
                bullets.Remove(b);
            }
            //Witch coordinate to increment
            if (b.moveXorY == 1)
            {
                b.position.x += b.speed * b.moveDir;
                b.position.y = (int)(b.mKoeficient * (b.position.x - b.target.x) + b.target.y);
            }
            else
            {
                b.position.y += b.speed * b.moveDir;
                b.position.x = (int)(b.mKoeficient * (b.position.y - b.target.y) + b.target.x);
            }
            b.centerPosition = new Point(b.position.x + (b.width / 2), b.position.y + (b.height / 2));
        }
        public void showDetails(int p)
        {
            Profesor prof=null;
            switch (p)
            {
                case 0:
                    prof = null;
                    break;
                case 1:
                    prof = new Profesor(new Point(0, 0), 60, 60, 30, 100, 30, 1000, "1");
                    break;
                case 2:
                    prof = new Profesor(new Point(0, 0), 60, 60, 50, 150, 30, 1500, "2");
                    break;
                case 3:
                    prof = new Profesor(new Point(0, 0), 60, 60, 50, 100, 15, 2000, "3");
                    break;
                case 4:
                    prof = new Profesor(new Point(0, 0), 60, 60, 150, 200, 60, 2500, "4");
                    break;
                case 5:
                    prof = new Profesor(new Point(0, 0), 60, 60, 200, 300, 50, 3000, "5");
                    break;
                case 6:
                    prof = new Profesor(new Point(0,0), 60, 60, 220, 200, 40, 3500, "6");
                    break;
                default:
                    break;
            }
            formPlay.tbDem.Text = prof.demage + "";
            formPlay.tbRange.Text = prof.range + "";
            formPlay.tbAtackSpeed.Text = prof.fireRate + "";
            formPlay.tbPrice.Text = prof.price + "";
        }
    }
}