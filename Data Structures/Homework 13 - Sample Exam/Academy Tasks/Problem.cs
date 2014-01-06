using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy_Tasks
{
    public struct Problem
    {
        public int currentIndex;
        public int solvedProblems;
        public int minPleasantness;
        public int maxPleasantness;

        public Problem(int index, int countProblems, int minPl, int maxPl)
        {
            this.currentIndex = index;
            this.solvedProblems = countProblems;
            this.minPleasantness = minPl;
            this.maxPleasantness = maxPl;
        }
    }
}
