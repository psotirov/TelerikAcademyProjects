using System;
using Supermarket.Data;
using System.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
namespace Supermarket.Client
{
    public class PdfProductReportCreator
    {
        public static void GeneratePdfDocument()
        {
            Document pdfDoc = new Document(PageSize.A4, 5, 5, 15, 15);
            PdfWriter.GetInstance(pdfDoc, new FileStream("report.pdf", FileMode.Create));

            pdfDoc.Open();

            PdfPTable table = new PdfPTable(5);
            PdfPCell cell = new PdfPCell();
            cell.Colspan = 5;
            cell.HorizontalAlignment = Element.ALIGN_MIDDLE;
            cell.Phrase = new Phrase("Aggregated Sales Report");
            table.AddCell(cell);


            SupermarketEntities sqlDb = new SupermarketEntities();
            using (sqlDb)
            {
                var salesProducts = from sales in sqlDb.Sales
                            join products in sqlDb.Products
                            on sales.ProductId equals products.Id
                            join measures in sqlDb.Measures
                            on products.MeasureId equals measures.Id
                            select new
                            {
                                Date=sales.Date,
                                Product=products.Name,
                                Quantity=sales.Quantity,
                                UnitPrice=sales.Price,
                                Sum=sales.Sum,
                                Measures=measures.Name,
                                SupermarketId=sales.SuperMarketId
                            };

                var salesQueryProducts = from sales in salesProducts
                                         join supermarkets in sqlDb.SuperMarkets
                                         on sales.SupermarketId equals supermarkets.Id
                                         select new
                                         {
                                             Date = sales.Date,
                                             Product = sales.Product,
                                             Quantity = sales.Quantity,
                                             UnitPrice = sales.UnitPrice,
                                             Sum = sales.Sum,
                                             Measures=sales.Measures,
                                             Location = supermarkets.Name
                                         };
                var groupedProducts = from groupedSales in salesQueryProducts
                                      group groupedSales by groupedSales.Date;

                foreach (var groupItem in groupedProducts)
                {
                    cell.Phrase = new Phrase("Date: " + groupItem.First().Date.Date);
                    cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    table.AddCell(cell);
                    PdfPCell secondCell = new PdfPCell();
                    secondCell.Phrase = new Phrase("Product");
                    secondCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    secondCell.Phrase.Font.SetStyle(Font.BOLD);
                    table.AddCell(secondCell);
                    secondCell.Phrase = new Phrase("Quantity");
                    secondCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    secondCell.Phrase.Font.SetStyle(Font.BOLD);
                    table.AddCell(secondCell);
                    secondCell.Phrase = new Phrase("UnitPrice");
                    secondCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    secondCell.Phrase.Font.SetStyle(Font.BOLD);
                    table.AddCell(secondCell);
                    secondCell.Phrase = new Phrase("Location");
                    secondCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    secondCell.Phrase.Font.SetStyle(Font.BOLD);
                    table.AddCell(secondCell);
                    secondCell.Phrase = new Phrase("Sum");
                    secondCell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    secondCell.Phrase.Font.SetStyle(Font.BOLD);
                    table.AddCell(secondCell);
                    secondCell.BackgroundColor = BaseColor.WHITE;

                    decimal sum = 0;
                    foreach (var item in groupItem)
                    {
                        secondCell.Phrase = new Phrase(item.Product);
                        table.AddCell(secondCell);
                        secondCell.Phrase = new Phrase(item.Quantity + " " + item.Measures);
                        table.AddCell(secondCell);
                        secondCell.Phrase = new Phrase(item.UnitPrice.ToString());
                        table.AddCell(secondCell);
                        secondCell.Phrase = new Phrase(item.Location);
                        table.AddCell(secondCell);
                        secondCell.Phrase = new Phrase(item.Sum.ToString());
                        table.AddCell(secondCell);
                        
                        sum += item.Sum;
                    }

                    cell.Colspan = 4;
                    cell.BackgroundColor = BaseColor.WHITE;
                    cell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                    cell.Phrase = new Phrase("Total sum for " + groupItem.First().Date.Date);
                    cell.HorizontalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cell);
                    secondCell.Phrase = new Phrase(sum.ToString());
                    table.AddCell(secondCell);
                    cell.Colspan = 5;
                    cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                }
            }

            pdfDoc.Add(table);
            pdfDoc.Close();
        }
    }
}
