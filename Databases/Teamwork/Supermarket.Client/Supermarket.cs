using System;
using System.Data.Entity;
using Supermarket.Data;
using Supermarket.Data.MySql;
using Supermarket.Data.Migrations;
using Supermarket.Data.XML;



namespace Supermarket.Client
{
    public class Supermarket
    {
        static void Main(string[] args)
        {

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SupermarketEntities, Configuration>());
            //MySQLFiller.Fill();

            //1
            //SqlDatabaseUpdater.TakeDataFromMySql();
            SqlDatabaseUpdater.TakeDataFromExcel();

            //2
            PdfProductReportCreator.GeneratePdfDocument();

            //3
            XMLTransform.GenerateXMLSalesReportByVendors();

            //4
            ProductReportCreator.CreateReports();

            //5
            XMLTransform.ReadExpensesFile();

            //6
            //TotalReportGenerator.GenerateTotalReport();
        }
    }
}
