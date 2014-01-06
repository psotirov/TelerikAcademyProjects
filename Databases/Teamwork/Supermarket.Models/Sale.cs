using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Supermarket.Data.MySql;

namespace Supermarket.Models
{
    public class Sale
    {
        public int Id { get; set; }

        public int SuperMarketId { get; set; }

        public virtual SuperMarket Supermarket { get; set; }

        public DateTime Date { get; set; }

        public int ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Sum { get; set; }
    }
}
