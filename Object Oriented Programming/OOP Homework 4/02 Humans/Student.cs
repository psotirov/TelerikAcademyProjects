using System;

namespace _02_Humans
{
    class Student : Human
    {
        private int _grade; // Grade holder

        public int Grade // every Student has a Grade -  number between 1 and 100 as percentage
        {
            get {return this._grade; }
            set
            {
                if (value < 1 || value > 100) throw new ArgumentOutOfRangeException();
                this._grade = value;
            }
        }

        public Student(string names, int grade = 1)
            : base(names)
        {
            this.Grade = grade;
        }

        public override string GetKind()
        {
            return "Student";
        }

        public override string ToString()
        {
            return String.Format("{0} - Name: {1} {2}, Grade: {3}", this.GetKind(), this.FirstName, this.LastName, this.Grade);
        }
    }
}
