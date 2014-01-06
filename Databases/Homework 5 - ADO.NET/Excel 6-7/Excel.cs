using System;
using System.Data.OleDb;

namespace Excel
{
    class Excel
    {
        static void Main()
        {
            var excelConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=..\\..\\TestBook.xlsx; " +
                "Extended Properties=\"Excel 12.0 Xml;HDR=YES;\"");
            excelConn.Open();
            using (excelConn)
            {
                // Task 6
                Console.WriteLine("\n\nName and Score Cells:");
                var cmdScores = new OleDbCommand("SELECT * FROM [Scores$]", excelConn);
                var reader = cmdScores.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string name = reader["Name"].ToString();
                        string score = reader["Score"].ToString();
                        Console.WriteLine("{0,-15} - {1}", name, score);
                    }
                }

                // Task 7
                Console.WriteLine("\n\nInserting new row into the excel sheet Scores...");
                string scName = "Some Student";
                double scScore = 21;
                var cmdInsertProduct = new OleDbCommand("INSERT INTO [Scores$]([Name],[Score]) VALUES (@scName, @scScore)", excelConn);
                cmdInsertProduct.Parameters.AddWithValue("@scName", scName);
                cmdInsertProduct.Parameters.AddWithValue("@scScore", scScore);
                cmdInsertProduct.ExecuteNonQuery();
                Console.WriteLine("Name: {0} - Score: {1}", scName, scScore);
            }
        }
    }
}
