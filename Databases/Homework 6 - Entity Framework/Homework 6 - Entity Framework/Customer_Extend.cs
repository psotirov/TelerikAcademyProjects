using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_6___Entity_Framework
{
    public partial class Customer
    {
        public override string ToString()
        {
            return "{ " +
                this.CompanyName + ", " +
                this.ContactName + ", " +
                this.ContactTitle + ", " +
                this.Address + ", " +
                this.City + ", " +
                this.Region + ", " +
                this.PostalCode + ", " +
                this.Country + ", " +
                this.Phone + ", " +
                this.Fax + ", " +
                "}";
        }
    }
}
