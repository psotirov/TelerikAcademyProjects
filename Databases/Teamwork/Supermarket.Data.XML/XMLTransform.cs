using System;
using System.Linq;
using System.Xml.Linq;
using Supermarket.Data.MySql;
using Supermarket.Models;

namespace Supermarket.Data.XML
{
    public class XMLTransform
    {
        public static void ReadExpensesFile(string filename = "Vendors-Expenses.xml")
        {
            XDocument xmlDoc = XDocument.Load(filename);
            var salesData =
                from sales in xmlDoc.Descendants("sale")
                select new
                {
                    Vendor = sales.Attribute("vendor").Value,
                    Expenses = from expenses in sales.Elements("expenses")
                               select new
                               {
                                   Date = expenses.Attribute("month").Value,
                                   Sum = expenses.Value
                               }
                };

            //Console.WriteLine("Found {0} sales:", salesData.Count());
            //foreach (var item in salesData)
            //{
            //    Console.WriteLine("Vendor: " + item.Vendor);
            //    foreach (var exp in item.Expenses)
            //    {
            //        Console.WriteLine("Date: {0}, Sum: {1}", exp.Date, exp.Sum);
            //    }
            //}

            if (salesData != null && salesData.Count() > 0)
            {
                using (var sqlContext = new SupermarketEntities())
                {
                    foreach (var sale in salesData)
                    {
                        using (var scope = new System.Transactions.TransactionScope())
                        {
                            var vendor = sqlContext.Vendors.Where(v => v.Name == sale.Vendor).ToList();
                            if (vendor.Count == 0)
                            {
                                var newVendor = new Vendor();
                                newVendor.Name = sale.Vendor;

                                sqlContext.Vendors.Add(newVendor);
                                // sqlContext.SaveChanges();
                                vendor.Add(newVendor);
                            }

                            foreach (var exp in sale.Expenses)
                            {
                                var expense = new Expense();
                                expense.VendorId = vendor[0].Id;
                                expense.Value = decimal.Parse(exp.Sum);
                                expense.Month = DateTime.Parse("1-" + exp.Date);
                                if (sqlContext.Expenses.Where(
                                    e => e.Month == expense.Month && e.VendorId==expense.VendorId).Count() == 0)
                                {
                                    sqlContext.Expenses.Add(expense);                          
                                }
                            }

                            sqlContext.SaveChanges();
                            scope.Complete();
                        }
                    }
                }
            }
        }

        public static void GenerateXMLSalesReportByVendors(string filename = "Sales-by-Vendors-report.xml")
        {
            using (var sqlContext = new SupermarketEntities())
            {
                //var firstQuery = from sales in sqlContext.Sales
                //                 join products in sqlContext.Products
                //                 on sales.ProductId equals products.Id
                //                 join vendors in sqlContext.Vendors
                //                 on products.VendorId equals vendors.Id
                //                 group new
                //                 {
                //                     SaleDate = sales.Date,
                //                     Sum = sales.Sum
                //                 } by vendors.Name;

                //var secondQuery= from inner in firstQuery
                //                 group inner by inner.SaleDate



                var vendorGroupedReport = from sales in sqlContext.Sales
                                          join products in sqlContext.Products on sales.ProductId equals products.Id
                                          join vendors in sqlContext.Vendors on products.VendorId equals vendors.Id
                                          group new
                                          {
                                              SaleDate = sales.Date,
                                              Sum = sales.Sum
                                          } by vendors.Name;

                var xmlTree = new XElement("sales");
                foreach (var item in vendorGroupedReport)
                {
                    var sale = new XElement("sale", new XAttribute("vendor", item.Key));
                    var aggregatedReport = from aggregated in item
                                           group aggregated by aggregated.SaleDate into p
                                           select new
                                           {
                                               Date = p.Distinct().Select(d => d.SaleDate).FirstOrDefault(),
                                               Total = p.Sum(s => s.Sum)
                                           };

                    foreach (var inner in aggregatedReport)
                    {
                        var summary = new XElement("summary", new XAttribute("date",
                            string.Format("{0:dd-MMM-yyyy}", inner.Date)),
                            new XAttribute("total-sum", inner.Total));
                        sale.Add(summary);
                    }
                    xmlTree.Add(sale);
                }

                var output = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), xmlTree);
                //Console.WriteLine(output);
                output.Save(filename);
             }
        }
    }
}