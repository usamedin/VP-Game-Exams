using System;
using System.Collections.Generic;
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

        public Stage(Point startPosition, Checkpoint[] checkpoints, int numCP, int classes, int spc)
        {
            this.checkpoints = checkpoints;
            this.startPosition = startPosition;
            this.numCP = numCP;
            this.classes = classes;
            this.studentsPerClas = spc;
        }
    }
}
