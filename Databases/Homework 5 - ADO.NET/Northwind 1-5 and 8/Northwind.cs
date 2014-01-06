using System;
using System.Data.SqlClient;

namespace Northwind_1_5
{
    class Northwind
    {
        static void Main(string[] args)
        {
            var dbCon = new SqlConnection("Server=localhost; Database=Northwind; Integrated Security=true");
            dbCon.Open();
            using (dbCon)
            {
                // Task 1
                var cmdCount = new SqlCommand(
                    "SELECT COUNT(*) FROM Categories", dbCon);
                int categoriesRowCount = (int)cmdCount.ExecuteScalar();
                Console.WriteLine("Categories table row count: {0} ", categoriesRowCount);

                // Task 2
                Console.WriteLine("\n\nCategories Name and Description:");
                var cmdAllCategories = new SqlCommand(
                  "SELECT CategoryName, Description FROM Categories ORDER BY CategoryName", dbCon);
                var reader = cmdAllCategories.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string catName = (string)reader["CategoryName"];
                        string catDescription = (string)reader["Description"];
                        Console.WriteLine("{0,-15} - {1}", catName, catDescription);
                    }
                }

                // Task 3
                Console.WriteLine("\n\nCategory Name and Product Names:");
                var cmdProducts = new SqlCommand("SELECT c.CategoryName, p.ProductName " +
                                                    "FROM Products AS p " +
                                                    "JOIN Categories AS c ON p.CategoryID = c.CategoryID " +
                                                    "ORDER BY c.CategoryName", dbCon);
                reader = cmdProducts.ExecuteReader();
                using (reader)
                {
                    string lastCatName = "";
                    while (reader.Read())
                    {
                        string catName = (string)reader["CategoryName"];
                        if (catName == lastCatName)
                        {
                            catName = "";
                        }
                        else
                        {
                            lastCatName = catName;
                            Console.WriteLine();
                        }
                        string prodName = (string)reader["ProductName"];
                        Console.WriteLine("{0,-15} - {1}", catName, prodName);
                    }
                }

                // Task 4
                Console.WriteLine("\n\nInserting new product into the database...");
                string prName = "Beer Tuborg";
                int prSupplier = 1;
                int prCategory = 1;
                string prUnitQtty = "6 bottles";
                double prPrice = 12.5;
                var cmdInsertProduct = new SqlCommand("INSERT INTO Products " +
                    "VALUES (@prName, @prSupplier, @prCategory, @prUnitQtty, @prPrice, 0, 0, 0, 0)", dbCon);
                cmdInsertProduct.Parameters.AddWithValue("@prName", prName);
                cmdInsertProduct.Parameters.AddWithValue("@prSupplier", prSupplier);
                cmdInsertProduct.Parameters.AddWithValue("@prCategory", prCategory);
                cmdInsertProduct.Parameters.AddWithValue("@prUnitQtty", prUnitQtty);
                cmdInsertProduct.Parameters.AddWithValue("@prPrice", prPrice);
                cmdInsertProduct.ExecuteNonQuery();
                Console.WriteLine("Product: {0} - UnitQtty: {1} - Price: {2}", prName, prUnitQtty, prPrice);

                // Task 5
                Console.WriteLine("\n\nCategories Name and Picture - save to disk:");
                var cmdPictures = new SqlCommand(
                  "SELECT CategoryName, Picture FROM Categories ORDER BY CategoryName", dbCon);
                reader = cmdPictures.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string catName = (string)reader["CategoryName"];
                        byte[] catPicture = (byte[])reader["Picture"];
                        string fileName = "..\\..\\" + System.Text.RegularExpressions.Regex.Replace(catName, "\\W", "") + ".jpeg";
                        Array.Copy(catPicture, 78, catPicture, 0, catPicture.Length - 78);
                        try
                        {
                            System.IO.File.WriteAllBytes(fileName, catPicture);
                            Console.WriteLine("File  {0} was succesfully saved to disk", fileName);
                        }
                        catch (System.IO.IOException)
                        {
                            Console.WriteLine("Failed to write file: {0}", fileName);
                        }
                    }
                }

                // Task 8
                Console.WriteLine("\n\nSearching in Product Names...");
                Console.Write("Please enter a search pattern: ");
                string search = Console.ReadLine().Trim();
                search = "%" + (search.Length == 0?"_":"") + System.Text.RegularExpressions.Regex.Replace(search, "[\\'\\\\\\\"%_]", "") + "%"; // [ \' \\ \" ]
                cmdProducts = new SqlCommand("SELECT ProductName, QuantityPerUnit, UnitPrice FROM Products " +
                                                    "WHERE ProductName LIKE @searchPattern", dbCon);
                cmdProducts.Parameters.AddWithValue("@searchPattern", search); 
                reader = cmdProducts.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string prodName = (string)reader["ProductName"];
                        string prodQtty = (string)reader["QuantityPerUnit"];
                        string prodPrice = reader["UnitPrice"].ToString();
                        Console.WriteLine("{0,-32} - {1, -22} - {2}", prodName, prodQtty, prodPrice);
                    }
                }
            }
        }
    }
}
