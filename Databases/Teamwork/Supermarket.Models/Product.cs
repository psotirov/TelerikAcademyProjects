using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models
{
    public class Product
    {
        public int Id { get; set; }

        public int VendorId { get; set; }

        public virtual Vendor Vendor { get; set; }

        public string Name { get; set; }

        public int MeasureId { get; set; }

        public virtual Measure Measure { get; set; }

        public decimal BasePrice { get; set; }
    }
}
