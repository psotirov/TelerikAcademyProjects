using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.Data.MySql;

namespace Supermarket.Models
{
    public class Tax
    {
        public int Id { get; set; }

        public double Value { get; set; }

        public int ProductId { get; set; }

        public virtual  Product Product { get; set; }
    }
}
