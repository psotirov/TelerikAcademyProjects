using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Supermarket.Data.MySql;
using System.Threading.Tasks;

namespace Supermarket.Client
{
    public class MySQLFiller
    {
        static Random randomVendor = new Random();
        static Random randomMeasure = new Random();

        public static void Fill()
        {
            SupermarketData mySql = new SupermarketData();
            using (mySql)
            {
                List<Measure> measures = new List<Measure>();
                List<Vendor> vendors = new List<Vendor>();
                List<Product> products = new List<Product>();

                string[] measuresNames = new string[]{
                    "liters", "pieces", "kilograms",
                    "boxes","packets"
                };

                string[] vendorNames = new string[]{
                    "Nestle Sofia Corp.","Zagorka Corp.","Targovishte Bottling Company Ltd.","17th Street Bar & Grill","A & J's Homemade Ice Cream",
                    "Adam McKinney Food Services","Adam McKinney Food Services 2","Ala Carte Catering The Skillet","Alan McKinney Food Services","Alan McKinney Food Services 2",
                    "Baskin Robbins","Brown's Concession","BT Extreme 4 LLC","Buck's Concessions","Caplis Enterprises 3",
                    "Caplis Enterprises","Caplis Enterprises 2","Christian County YMCA","Ciao Babies","Coleman Concessions"
                };

                string[] productNames = new string[]{
                    "Beer Beck’s","Chocolate Milka","Bread Trakia","Rakia Burgas","Beer Zagorka",
                    "Vodka Targovishte","Kentish ale","Kentish strong ale","Newcastle Brown Ale ","Rutland bitter",
                    "Bonchester cheese","Dovedale cheese","Single Gloucester","Stilton White cheese ","Stilton Blue cheese",
                    "Teviotdale cheese","Swaledale ewes cheese","West Country farmhouse Cheddar cheese","Gloucestershire cider","Gloucestershire perry",
                    "Arbroath Smokies","Cornish Sardines","Isle of Man Queenies","Lough Neagh Eel","Scottish Farmed Salmon",
                    "Herefordshire cider","Herefordshire perry","Worcestershire cider","Worcestershire perry","Cornish Clotted Cream",
                    "Traditional Grimsby smoked fish","Whitstable Oysters","Gloucestershire Old Spots","Isle of Man Loaghtan Lamb","Lakeland Herdwick",
                    "Orkney beef","Orkney lamb","Scotch beef","Scotch lamb","Shetland lamb",
                    "Traditional farmfresh turkey","Welsh Beef","Welsh lamb","West Country Lamb","West Country Beef",
                    "Armagh Bramleys","Jersey Royal potatoes","Yorkshire Forced Rhubarb","Plymouth Gin","Scotch Whisky"
                };

                decimal[] bestPrices = new decimal[]{
                    23,45,23,54,3,23,6,23,54,12,
                    12,45,23,233,12,23,45,23,54,53,
                    23,45,23,54,23,23,45,66,86,12,
                    76,45,23,89,12,23,45,36,54,12,
                    23,45,23,566,98,13,45,23,54,33
                };

                for (int count = 0; count < 5; count++)
                {
                    Measure newMeasure = new Measure
                    {
                        Id = count + 1,
                        Name = measuresNames[count]
                    };

                    mySql.Add(newMeasure);
                    mySql.SaveChanges();

                    measures.Add(newMeasure);
                }

                for(int counter = 0; counter < 20; counter++)
                {
                    Vendor newVendor = new Vendor
                    {
                        Id = counter+1,
                        Name = vendorNames[counter]
                    };

                    mySql.Add(newVendor);
                    vendors.Add(newVendor);
                }

                for (int counter = 0; counter < 50; counter++)
                {
                    Product newProduct = new Product
                    {
                        Id = counter + 1,
                        Vendor = vendors[randomVendor.Next(vendors.Count)],
                        Measure = measures[randomMeasure.Next(measures.Count)],
                        Name = productNames[counter],
                        BasePrice = bestPrices[counter] 
                    };

                    mySql.Add(newProduct);
                    products.Add(newProduct);
                }

                mySql.SaveChanges();
            }
        } 
    }
}
