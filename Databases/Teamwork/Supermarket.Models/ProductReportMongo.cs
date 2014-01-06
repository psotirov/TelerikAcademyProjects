using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text;
using System.Threading.Tasks;

namespace Supermarket.Models
{
    public class ProductReportMongo
    {
        [BsonId]
        public ObjectId Id { get; set; }
        
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string VendorName { get; set; }

        public int TotalQuantitySold { get; set; }

        public decimal TotalIncomes { get; set; }
    }
}
