using System;
using System.Collections.Generic;
using System.Collections;

namespace _01_04_3DPoints
{
    public class Path : IEnumerable<Point3D>
    {
        private List<Point3D> path; // a 3D path is simply a list of consecutive 3D points 
        public int Count { get { return path.Count; } } // path has total count of points

        public Path() // default constructor
        {
            path = new List<Point3D>();
        }

        public Point3D this[int index] // indexer
        {
            get { return path[index]; }
        }

        public void Add(int x, int y, int z) // adding point to the path
        {
            path.Add(new Point3D(x,y,z));
        }

        IEnumerator IEnumerable.GetEnumerator() // obsolete form of IEnumerator
        {
            return this.GetEnumerator(); // invokes the default one below
        }

        public IEnumerator<Point3D> GetEnumerator() // implements forearch capability
        {
            for (int i = 0; i < path.Count; i++)
            {
                yield return path[i]; // returns the next element on every call (MoveNext + Current)
            }
        }

        public override string ToString() // returns path as a list of 3D points, i.e. Path: {x1,y1,z1} , {x2,y2,z2} , ... , {xn,yn,zn}
        {
            string result = "Path: ";

            for (int i = 0; i < this.Count; i++)
            {
                result += this.path[i].ToString();
                if (this.Count - i > 1) result += " , "; // puts comma after all elements exept the last
            }
            return result;
        }
    }
}
