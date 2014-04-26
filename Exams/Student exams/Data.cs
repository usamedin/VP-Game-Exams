using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Student_exams
{
    class Data
    {
        public static Checkpoint [] checkpointS1 = { new Checkpoint(3, 700), new Checkpoint(4, 260), new Checkpoint(3, 100), new Checkpoint(2, 420), new Checkpoint(0, 700) };
        public static Stage[] stages = { new Stage(new Point(1,100), checkpointS1, 5, 1, 10,2000,100,3) };
       
    }
}
