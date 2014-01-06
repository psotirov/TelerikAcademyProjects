using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models
{
    public class SuperMarket
    {
        private ICollection<Sale> sales;

        public SuperMarket()
        {
            this.sales = new HashSet<Sale>();
        }

        public ICollection<Sale> Sales
        {
            get { return sales; }
            set { sales = value; }
        }
        
        public int Id { get; set; }

        public string  Name { get; set; }
    }
}
