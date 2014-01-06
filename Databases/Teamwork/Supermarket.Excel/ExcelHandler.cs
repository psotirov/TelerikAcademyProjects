using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.OpenAccess;
using System.IO;
using System.Data.OleDb;
using System.Data;
using Supermarket.Models;
using Supermarket.Data;
using Ionic.Zip;

namespace Supermarket.Excel
{
    public class ExcelHandler
    {
        public static void TransformExcel()
        {
            string zipPath = @"Sample-Sales-Reports.zip";
            string unzipDirectory = @"ExtractedZip";
            UnzipFile(zipPath, unzipDirectory);
            FindExcelFiles(unzipDirectory);
           // Directory.Delete(unzipDirectory, true);
        }

        private static void FindExcelFiles(string directoryPath)
        {
            var excelFiles = Directory.EnumerateFiles(directoryPath, "*.xls");
            foreach (var file in excelFiles)
            {
                ReadExcelsFromDirectory(file);
            }

            var directories = Directory.EnumerateDirectories(directoryPath);
            foreach (var directory in directories)
            {
                //try
                {
                    FindExcelFiles(directory);
                }
                //catch (Exception e)
                {

                    //Console.WriteLine(e.Message);
                }
            }
        }

        private static void ReadExcelsFromDirectory(string filePath)
        {
            DataTable dt = new DataTable("newtable");

            using (OleDbConnection connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 12.0;HDR=NO;IMEX=1\""))
            {
                connection.Open();
                string selectSql = @"SELECT * FROM [Sales$]";
                using (OleDbDataAdapter adapter = new OleDbDataAdapter(selectSql, connection))
                {
                    adapter.FillSchema(dt, SchemaType.Source);
                    adapter.Fill(dt);
                }
                connection.Close();
            }


            string location = dt.Rows[1][0].ToString();
 
            SuperMarket newSupermarket = new SuperMarket()
            {
                Name = location,
            }; 
            
            for (int i = 3; i < dt.Rows.Count - 1; i++)
            {
                int prodId = 0;
                string productId = dt.Rows[i][0].ToString();
                int.TryParse(productId, out prodId);
                if (prodId > 0)
                {
                    using (var ctx = new SupermarketEntities())
                    {
                        if (ctx.Products.Find(prodId) != null)
                        {
                            var supermarket = ctx.SuperMarkets.Where(s => s.Name == newSupermarket.Name).ToList();
                            if (supermarket.Count == 0)
                            {
                                ctx.SuperMarkets.Add(newSupermarket);
                                supermarket.Add(newSupermarket);
                            }

                            Sale newSale = new Sale()
                            {                                
                                ProductId = prodId,
                                SuperMarketId = supermarket[0].Id,
                                Date = DateTime.Now,
                                Quantity = int.Parse(dt.Rows[i][1].ToString()),
                                Price = decimal.Parse(dt.Rows[i][2].ToString()),
                                Sum = decimal.Parse(dt.Rows[i][3].ToString())
                            };

                            ctx.Sales.Add(newSale);
                            ctx.SaveChanges();
                        }
                    }
                }
            }
        }

        private static void UnzipFile(string zipPath, string unzipDirectory)
        {
            using (ZipFile zip = ZipFile.Read(zipPath))
            {
                foreach (ZipEntry e in zip)
                {
                    e.Extract(unzipDirectory, ExtractExistingFileAction.OverwriteSilently);
                }
            }
        }
    }
}
