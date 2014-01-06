using System;

namespace _02_Humans
{
    public abstract class Human : IComparable<Human>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Human(string names) // constructor mist have at least one parameter - concatenated both names of the human 
        {
            string[] ns = names.Split(' ');
            if (ns.Length > 1)
            {
                this.FirstName = ns[0];
                this.LastName = ns[1];
            }
            else this.LastName = ns[0]; // if there is only one name this should be last name
        }

        public abstract string GetKind(); // abstract method that must return the Kind of Human, i.e. Student or Worker

        public int CompareTo(Human another) // compares two humans initially by their first name and if they are equal then checks their last names
        {
            if (another == null) return 1;
            int result = this.FirstName.CompareTo(another.FirstName);
            if (result == 0) result = this.LastName.CompareTo(another.LastName);
            return result;
        }
    }
}
