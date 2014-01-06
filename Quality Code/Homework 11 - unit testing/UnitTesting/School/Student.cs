using System;

namespace SchoolNS
{
    public class Student
    {
        private string name;
        private int id;

        public Student(string name, int id)
        {
            this.Name = name;
            this.ID = id;
        }

        public string Name
        {
            get { return this.name; }

            set
            {
                if (value == null || value == string.Empty)
                {
                    throw new ArgumentNullException("Name is missing!");
                }

                this.name = value;
            }
        }

        public int ID
        {
            get { return this.id; }

            set
            {
                if (value < 10000 || value > 99999)
                {
                    throw new ArgumentOutOfRangeException("The student's ID should be between 10000 and 99999!");
                }

                this.id = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Student {0}, ID {1}; ", this.Name, this.ID);
        }
    }
}
