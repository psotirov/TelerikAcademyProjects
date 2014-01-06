using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models
{
    public class Measure
    {
        private ICollection<Product> products;

        public Measure()
        {
            this.products = new HashSet<Product>();
        }

        public virtual ICollection<Product> Products
        {
            get { return this.products; }
            set { this.products = value; }
        }
        
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
