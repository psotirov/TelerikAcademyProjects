using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Data.MySql
{
    public class Vendor
    {
        private ICollection<Product> products;

        public Vendor()
        {
            this.products = new HashSet<Product>();
        }

        public virtual ICollection<Product> Products
        {
            get { return products; }
            set { products = value; }
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
