using System;

namespace Methods
{
    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherInfo { get; set; }
        public DateTime Born { get; set; }

        public bool IsOlderThan(Student other)
        {
            return (DateTime.Compare(this.Born, other.Born) <= 0);
        }
    }
}
