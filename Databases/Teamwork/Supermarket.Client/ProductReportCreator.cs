using System;
using Supermarket.Data;
using System.Linq;
using System.IO;
using Newtonsoft.Json;
using MongoDB.Driver;
using Supermarket.Models;
using MongoDB;
using MongoDB.Driver.Linq;

namespace Supermarket.Client
{
    public class ProductReportCreator
    {
        public static void CreateReports()
        {
            SupermarketEntities sqlDb = new SupermarketEntities();
            using (sqlDb)
            {
                var queryProducts = from vendors in sqlDb.Vendors
                                    join products in sqlDb.Products
                                    on vendors.Id equals products.VendorId
                                    join sales in sqlDb.Sales
                                    on products.Id equals sales.ProductId
                                    select new
                                    {
                                        ProductId = products.Id,
                                        PriductName = products.Name,
                                        VendorName = vendors.Name,
                                        Quantity = sales.Quantity,
                                        Income = sales.Sum
                                    };

                var goupedProducts = from products in queryProducts
                                     group products by products.ProductId into p
                                     select new
                                     {
                                         ProductId = p.Select(a => a.ProductId).FirstOrDefault(),
                                         ProductName = p.Select(a => a.PriductName).FirstOrDefault(),
                                         VendorName = p.Select(a => a.VendorName).FirstOrDefault(),
                                         TotalQuantitySold = p.Sum(a => a.Quantity),
                                         TotalIncomes = p.Sum(a => a.Income)
                                     };

                foreach (var grouped in goupedProducts)
                {
                    string json = JsonConvert.SerializeObject(grouped);
                    string path = "..\\Product-Reports\\" + grouped.ProductId + ".json";
                    using (StreamWriter writer = new StreamWriter(path, false))
                    {
                        writer.WriteLine(json);
                    }

                    var mongoClient = new MongoClient("mongodb://localhost/");
                    var mongoServer = mongoClient.GetServer();
                    var supermarketDb = mongoServer.GetDatabase("supermarket");
                    var productsReport = supermarketDb.GetCollection("productsReport");

                    ProductReportMongo prodReport = new ProductReportMongo
                    {
                        ProductId = grouped.ProductId,
                        ProductName = grouped.ProductName,
                        VendorName = grouped.VendorName,
                        TotalQuantitySold = grouped.TotalQuantitySold,
                        TotalIncomes = grouped.TotalIncomes
                    };

                    productsReport.Insert(prodReport);
                }
            }
        }
    }
}
