using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Student_exams
{
    class Data
    {
        public static Checkpoint[] checkpointS1 = { new Checkpoint(3, 200), new Checkpoint(4, 260), new Checkpoint(3, 20), new Checkpoint(2, 420), new Checkpoint(1, 350), new Checkpoint(2, 100), new Checkpoint(3, 600), new Checkpoint(2, 420), new Checkpoint(0, 700) };
        public static Checkpoint [] checkpointS2 = { new Checkpoint(3, 700), new Checkpoint(4, 260), new Checkpoint(3, 100), new Checkpoint(2, 420), new Checkpoint(0, 700) };
        public static Checkpoint[] checkpointS3 = { new Checkpoint(3, 700), new Checkpoint(4, 460), new Checkpoint(0, 0) };
        public static Stage[] stages = { new Stage(new Point(1, 100), checkpointS1, 9, 4, 20, 2500, 60, 3), new Stage(new Point(1, 100), checkpointS2, 5, 5, 20, 7500, 250, 3), new Stage(new Point(1, 80), checkpointS3, 3, 7, 5, 8300, 300, 1) };
       
    }
}
