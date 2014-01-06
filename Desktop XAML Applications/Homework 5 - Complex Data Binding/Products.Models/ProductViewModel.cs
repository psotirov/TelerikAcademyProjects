using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ModelNumber { get; set; }

        public decimal UnitCost { get; set; }

        public string Description { get; set; }

        public string CategoryName { get; set; }
    }
}
