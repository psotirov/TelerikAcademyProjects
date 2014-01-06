using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.Data.MySql;

namespace Supermarket.Models
{
    public class Expense
    {
        public int Id { get; set; }

        public int VendorId { get; set; }

        public virtual Vendor Vendor { get; set; }

        public DateTime Month { get; set; }

        public decimal Value { get; set; }
    }
}
