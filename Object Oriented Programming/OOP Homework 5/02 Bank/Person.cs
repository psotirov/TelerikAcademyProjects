using System;

namespace _02_Bank
{
    class Person : Customer
    {
        public string PersonID { get; set; }

        public Person(string name, string personID = "000000000")
            : base(name)
        {
            this.PersonID = personID;
        }

        public override string GetData()
        {
            return String.Format(", Person ID={0}", this.PersonID);
        }
    }
}
