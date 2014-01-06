using System;
using System.Linq;
using System.Collections.Generic;
using Supermarket.Excel;
using Supermarket.Data;
using Supermarket.Data.MySql;


namespace Supermarket.Client
{
    public class SqlDatabaseUpdater
    {
        public static void TakeDataFromMySql()
        {
            SupermarketEntities sqlDb = new SupermarketEntities();
            using (sqlDb)
            {
                SupermarketData mySql = new SupermarketData();
                using (mySql)
                {
                    List<string> measureNames = mySql.Measures.Select(x => x.Name).ToList();

                    foreach (string measureName in measureNames)
                    {
                        int measurementCount = sqlDb.Measures.Select(x => x.Name).Where(x => x == measureName).Count();
                        if (measurementCount == 0)
                        {
                            sqlDb.Measures.Add(new Measure { Name = measureName });
                        }
                    }

                    sqlDb.SaveChanges();

                    List<string> vendorNames = mySql.Vendors.Select(x => x.Name).ToList();

                    foreach (string vendorName in vendorNames)
                    {
                        int vendorNamesCount = sqlDb.Vendors.Select(x => x.Name).Where(x => x == vendorName).Count();
                        if (vendorNamesCount == 0)
                        {
                            sqlDb.Vendors.Add(new Vendor { Name = vendorName });
                        }
                    }

                    sqlDb.SaveChanges();

                    var products = mySql.Products.ToList();
                    foreach (Product mySqlProduct in products)
                    {
                        string productName = mySqlProduct.Name;
                        string productVendorName = mySqlProduct.Vendor.Name;
                        string productMeasureName = mySqlProduct.Measure.Name;
                        decimal productBasePrice = mySqlProduct.BasePrice;

                        var sqlProduct = sqlDb.Products.Where(x => x.Name == productName).ToList();

                        if (sqlProduct.Count==0)
                        {
                            Product newProduct = new Product
                            {
                                Name=productName
                            };
                            sqlDb.Products.Add(newProduct);
                            sqlProduct.Add(newProduct);
                        }

                        sqlProduct[0].BasePrice = productBasePrice;

                        Vendor sqlVendor = sqlDb.Vendors.Where(
                            x => x.Name == productVendorName).FirstOrDefault();
                        sqlProduct[0].Vendor= sqlVendor;

                        Measure sqlMeasure = sqlDb.Measures.Where(
                             x => x.Name == productMeasureName).FirstOrDefault();
                        sqlProduct[0].Measure = sqlMeasure;

                        sqlDb.SaveChanges();
                    }
                }
            }
        }

        public static void TakeDataFromExcel()
        {
            ExcelHandler.TransformExcel();
        }
    }
}
