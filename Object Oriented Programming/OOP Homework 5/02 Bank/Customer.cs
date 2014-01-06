using System;
using System.Collections.Generic;

namespace _02_Bank
{
    public abstract class Customer : ICustomer
    {
        public string Name { get; set; }
        public List<Account> Accounts { get; private set; }


        protected Customer(string name)
        {
            this.Name = name;
            this.Accounts = new List<Account>();
        }

        public virtual string GetData() // the method is virtual since some inherit classes could not provide such data 
        {
            return String.Empty;
        }

        public override string ToString()
        {
            // extracts only the class name (deletes leading data such as project name, etc.)
            string shapeType = this.GetType().ToString();
            if (shapeType.IndexOf('.') >= 0) shapeType = shapeType.Substring(shapeType.LastIndexOf('.') + 1);

            // returns whole structure data
            string result = String.Format("{0} {{ name={1}{2}, Account(s) {{\r\n", shapeType, this.Name, this.GetData());
            for (int i = 0; i < this.Accounts.Count; i++)
            {
                result += "    " + this.Accounts[i].ToString();
                if (i < this.Accounts.Count - 1) result += ",\r\n"; // puts separator except the last one
            }
            result += " }";
            return result;
        }

    }
}
