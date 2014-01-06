using System;
using System.Linq;
using MongoDB.Driver;
using Supermarket.Models;
using Supermarket.Data;
using Supermarket.Data.Sqlite;
using System.Collections.Generic;

namespace Supermarket.Client
{
    public class TotalReportGenerator
    {
        public static void GenerateTotalReport()
        {
            FillSqliteWithProductsReportsFromMongo();
            GenerateExcelVendorReport();
        }
        private static void FillSqliteWithProductsReportsFromMongo()
        {
            var mongoClient = new MongoClient("mongodb://localhost/");
            var mongoServer = mongoClient.GetServer();
            var supermarketDb = mongoServer.GetDatabase("supermarket");
            var productsReport = supermarketDb.GetCollection("productsReport");

            var allReports = productsReport.FindAllAs<ProductReportMongo>();
            foreach (var report in allReports)
            {
                ProductReports reportSqlite = new ProductReports
                {
                    ProductId=report.ProductId,
                    ProductName=report.ProductName,
                    VendorName=report.VendorName,
                    TotalQuantitySold=report.TotalQuantitySold,
                    TotalIncomes=report.TotalIncomes
                };

                SupermarketSqliteEntities sqliteDb = new SupermarketSqliteEntities();
                using (sqliteDb)
                {
                    sqliteDb.ProductReports.Add(reportSqlite);
                    sqliteDb.SaveChanges();
                }

            }
        }

        private static void GenerateExcelVendorReport()
        {
            SupermarketEntities sqlDb = new SupermarketEntities();

            using (sqlDb)
            {
                SupermarketSqliteEntities sqliteDb = new SupermarketSqliteEntities();
                using (sqliteDb)
                {
                    var vendorsInfo = from sales in sqlDb.Sales
                                      join products in sqlDb.Products
                                      on sales.ProductId equals products.Id
                                      join vendors in sqlDb.Vendors
                                      on products.VendorId equals vendors.Id
                                      join expenses in sqlDb.Expenses
                                      on vendors.Id equals expenses.VendorId
                                      group new
                                      {
                                          ProductName = products.Name,
                                          VendorName = vendors.Name,
                                          Sum = sales.Sum,
                                          Expenses = expenses.Value,
                                      }
                                      by vendors.Name;
                    var slqTaxes = sqliteDb.Taxes;

                    foreach (var vendor in vendorsInfo)
                    {
                        Console.WriteLine(vendor.Key);

                        foreach (var inner in vendor)
                        {
                            foreach (var tax in inner.ProductName)
                            {
                                
                            }
                        }
                    }
                }
            }
        }
    }
}
