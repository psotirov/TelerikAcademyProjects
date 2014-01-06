using System;
using MySql.Data.MySqlClient;

namespace MySQL_9
{
    class MySQL
    {
        static void Main()
        {
            var dbCon = new MySqlConnection("Server=localhost;Database=books;Uid=root;Pwd=;");
            dbCon.Open();
            using (dbCon)
            {
                // Shows list of all books in database
                Console.WriteLine("\n\nList of books:");
                var cmdAllBooks = new MySqlCommand(
                  "SELECT * FROM books", dbCon);
                var reader = cmdAllBooks.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string bookTitle = (string)reader["Title"];
                        string bookAuthor = (string)reader["Author"];
                        string bookPublishDate = reader["PublishDate"].ToString();
                        string bookISBN = (string)reader["ISBN"];
                        Console.WriteLine("{0}, {1}, {2}, {3}", bookTitle, bookAuthor, bookPublishDate, bookISBN);
                    }
                }

                // Inserts new book in database
                Console.WriteLine("\n\nInserting new book into the database...");
                string bkTitle = "Advanced Joomla!";
                string bkAuthor = "Dan Rahmel";
                string bkPublishDate = "2013-01-01 00:00:00";
                string bkISBN = "978-1-4302-1628-5";
                var cmdInsertBook = new MySqlCommand("INSERT INTO books " +
                    "VALUES (NULL, @bkTitle, @bkAuthor, @bkPublishDate, @bkISBN)", dbCon);
                cmdInsertBook.Parameters.AddWithValue("@bkTitle", bkTitle);
                cmdInsertBook.Parameters.AddWithValue("@bkAuthor", bkAuthor);
                cmdInsertBook.Parameters.AddWithValue("@bkPublishDate", bkPublishDate);
                cmdInsertBook.Parameters.AddWithValue("@bkISBN", bkISBN);
                cmdInsertBook.ExecuteNonQuery();
                Console.WriteLine("NEW: {0}, {1}, {2}, {3}", bkTitle, bkAuthor, bkPublishDate, bkISBN);

                // Finds specific book in database
                Console.WriteLine("\n\nSearching in Book Titles...");
                Console.Write("Please enter a search pattern: ");
                string search = Console.ReadLine().Trim();
                search = "%" + (search.Length == 0 ? "_" : "") + System.Text.RegularExpressions.Regex.Replace(search, "[\\'\\\\\\\"%_]", "") + "%"; // [ \' \\ \" ]
                var cmdFindBook = new MySqlCommand("SELECT * FROM books " +
                                                    "WHERE Title LIKE @searchPattern", dbCon);
                cmdFindBook.Parameters.AddWithValue("@searchPattern", search);
                reader = cmdFindBook.ExecuteReader();
                using (reader)
                {
                    while (reader.Read())
                    {
                        string bookTitle = (string)reader["Title"];
                        string bookAuthor = (string)reader["Author"];
                        string bookPublishDate = reader["PublishDate"].ToString();
                        string bookISBN = (string)reader["ISBN"];
                        Console.WriteLine("{0}, {1}, {2}, {3}", bookTitle, bookAuthor, bookPublishDate, bookISBN);
                    }
                }
            }
        }
    }
}
