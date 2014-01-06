using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using Bookstore.Data;

namespace Bookstore.Client
{
    public class BookstoreApplication
    {
        public static void Main()
        {
            Console.WriteLine("Welcome to the Bookstore!");
            // Task 1 & 2 - see BookstoreDB.sql that is part of the project
            // Initially there was ISBN Unique key but it was removed due to multiple NULL problem

            // Task 3 - Simple books import
            Console.Write("\nMaking simple import of data....");
            // ImportXML(@"../../simple-books.xml");
            Console.WriteLine("Done.");

            // Task 4 - Complex books import
            Console.Write("\nMaking more complex import of data....");
            //ImportXML(@"../../complex-books.xml", true);
            Console.WriteLine("Done.");

            // Task 5 - Simple search using XML query
            Console.WriteLine("\nMaking simple search in the database using XML quiery....");
            //SearchDatabaseXMLSimple(@"../../simple-query.xml");
            Console.WriteLine("Done.");

            // Task 6 - Simple search using XML query
            Console.Write("\nMaking multiple search of reviews in the database using XML quiery....");
            SearchDatabaseXMLReviews(@"../../reviews-queries.xml", @"../../reviews-search-results.xml");
            Console.WriteLine("Done.");
            
            Console.WriteLine("\n\nPress Enter to finish.");
            Console.ReadLine();
        }

        private static void ImportXML(string filename, bool complexData = false)
        {
            var import = new XmlDocument();
            import.Load(filename);
            var books = import.DocumentElement.ChildNodes;
            foreach (XmlNode book in books)
            {
                var newBook = new Book();
                if (book["title"] == null || book["title"].InnerText.Length == 0)
                {
                    throw new ApplicationException(string.Format("Invalid {0} file - Book Title is missing", filename));
                }

                newBook.Title = book["title"].InnerText;

                if (book["isbn"] != null)
                {
                    newBook.ISBN = book["isbn"].InnerText;
                }

                if (book["price"] != null)
                {
                    newBook.Price = decimal.Parse(book["price"].InnerText);
                }

                if (book["web-site"] != null)
                {
                    newBook.WebSite = book["web-site"].InnerText;
                }

                using (var bookstoreContext = new BookstoreEntities())
                {
                    using (var scope = new System.Transactions.TransactionScope())
                    {
                        if (complexData)
                        {
                            // read current book auhtors - no need to check since authors are not obligatory in a complex import
                            if (book["authors"] != null)
                            {
                                foreach (XmlNode author in book["authors"].ChildNodes)
                                {
                                    newBook.Authors.Add(GetSingleAuthor(bookstoreContext, author));
                                }
                            }

                            // read current book reviews
                            if (book["reviews"] != null)
                            {
                                foreach (XmlNode review in book["reviews"].ChildNodes)
                                {
                                    newBook.Reviews.Add(GetSingleReview(bookstoreContext, review));
                                }
                            }
                        }
                        else
                        {
                            // there is only one author in a simple mode
                            if (book["author"] == null)
                            {
                                throw new ApplicationException(string.Format("Invalid {0} file - Book Author is missing", filename));
                            }

                            newBook.Authors.Add(GetSingleAuthor(bookstoreContext, book["author"]));
                        }

                        // Check if there is a book with the same ISBN - skip it
                        if (bookstoreContext.Books.Where(b => b.ISBN == newBook.ISBN).Count() == 0)
                        {
                            bookstoreContext.Books.Add(newBook);
                        }

                        bookstoreContext.SaveChanges();
                        scope.Complete();
                    }
                }
            }
        }

        static private Author GetSingleAuthor(BookstoreEntities context, XmlNode authorItem)
        {
            if (authorItem.Name != "author" || authorItem.InnerText.Length == 0)
            {
                throw new ApplicationException("Invalid input XML file - Invalid Author tag");
            } 
            
            string authorName = authorItem.InnerText;
            var author = context.Authors.Where(a => a.Name == authorName).ToList();
            if (author.Count == 0)
            {
                var newAuthor = new Author();
                newAuthor.Name = authorName;

                context.Authors.Add(newAuthor);
                context.SaveChanges();
                author.Add(newAuthor);
            }

            return author[0];
        }

        static private Review GetSingleReview(BookstoreEntities context, XmlNode reviewItem)
        {
            if (reviewItem.Name != "review" || reviewItem.InnerText.Length == 0)
            {
                throw new ApplicationException("Invalid input XML file - Invalid Review tag");
            }

            var review = new Review();
            review.ReviewText = reviewItem.InnerText.Trim();
            if (reviewItem.Attributes["date"] != null)
            {
                review.Date = DateTime.Parse(reviewItem.Attributes["date"].InnerText.Trim());
            }
            else
            {
                review.Date = DateTime.Now.Date;
            }

            if (reviewItem.Attributes["author"] != null)
            {
                review.Author = GetSingleAuthor(context, reviewItem.Attributes["author"]);
            }

            return review;
        }

        private static void SearchDatabaseXMLSimple(string filename)
        {
            var import = new XmlDocument();
            import.Load(filename);
            var tags = import.DocumentElement.ChildNodes;
 
            using(var bookstoreContext = new BookstoreEntities())
	        {
                var query = from books in bookstoreContext.Books
                            select new
                            {
                                Title = books.Title,
                                ISBN = books.ISBN,
                                AuthorNames = books.Authors.Select(a => a.Name),
                                ReviewsCount = books.Reviews.Count()
                            };

                foreach (XmlNode item in tags)
                {
                    switch (item.Name)
                    {
                        case "title":
                            query = query.Where(b => b.Title == item.InnerText.Trim());
                            break;
                        case "author":
                            query = query.Where(b => b.AuthorNames.Contains(item.InnerText.Trim()));
                            break;
                        case "isbn":
                            query = query.Where(b => b.ISBN == item.InnerText.Trim());
                            break;
                    }
                }

                var result = query.OrderBy(b => b.Title).ToList();
                if (result.Count > 0)
                {
                    Console.WriteLine("{0} books found:", result.Count);
                    foreach (var item in result)
                    {
                        Console.WriteLine("{0} --> {1} reviews", item.Title, 
                            ((item.ReviewsCount>0)?item.ReviewsCount.ToString():"no"));
                    }
                }
                else
                {
                    Console.WriteLine("Nothing Found");
                }
 	        } 
        }

        private static void SearchDatabaseXMLReviews(string inputFilename, string outputFilename)
        {
            bool hasByPeriodQuery = false;
            var import = new XmlDocument();
            import.Load(inputFilename);
            var tags = import.DocumentElement.ChildNodes;
            var root = new XElement("search-results");
            foreach (XmlNode tag in tags)
            {
                if (tag.Name == "query")
                {
                    DateTime startDate = DateTime.MinValue;
                    DateTime endDate = DateTime.MaxValue;
                    string authorName = "";
                    bool isByPeriodQuery = false;

                    var queryType = tag.Attributes["type"];
                    if (queryType == null || (queryType.Value != "by-period" && queryType.Value != "by-author"))
                    {
                        throw new ApplicationException("Invalid input XML file - Invalid Query Attribute");                        
                    }

                    var resultSetTag = new XElement("result-set");
                    if (queryType.Value == "by-period")
                    {
                        hasByPeriodQuery = true;
                        startDate = DateTime.Parse(tag["start-date"].InnerText.Trim());
                        endDate = DateTime.Parse(tag["end-date"].InnerText.Trim());
                        isByPeriodQuery = true;                   
                    }
                    else
                    {
                        authorName = tag["author-name"].InnerText.Trim();
                    }
                    
                    using (var bookstoreContext = new BookstoreEntities())
                    {
                        var query = bookstoreContext.Reviews.Include("Author").Include("Book").AsQueryable();
                        if (isByPeriodQuery)
                        {
                            query = query.Where(i => i.Date >= startDate && i.Date <= endDate);
                        }
                        else
                        {
                            query = query.Where(i => i.Author.Name == authorName);
                        }

                        var result = query.OrderBy(i => i.Date).ThenBy(i => i.ReviewText).ToList();
 
                        if (result.Count > 0)
                        {
                            foreach (var item in result)
                            {
                                var bookTag = new XElement("book");
                                // inner book tags goes here
                                if (item.Book.Title != null)
                                {
                                    bookTag.Add(new XElement("title", item.Book.Title));
                                }

                                if (item.Book.Authors.Count > 0)
                                {
                                    var authorsTag = "";
                                    foreach (var authorItem in item.Book.Authors.OrderBy(a => a.Name))
	                                {
                                        if (authorsTag.Length > 0)
                                        {
                                            authorsTag += ", ";
                                        }

                                        authorsTag += authorItem.Name;
	                                }

                                    bookTag.Add(new XElement("authors", authorsTag));
                                }

                                if (item.Book.ISBN != null)
                                {
                                    bookTag.Add(new XElement("isbn", item.Book.ISBN));
                                }

                                if (item.Book.WebSite != null)
                                {
                                    bookTag.Add(new XElement("url", item.Book.WebSite));
                                }

                                var reviewTag = new XElement("review",
                                    new XElement("date", string.Format("{0:dd-MMM-yyyy}", item.Date)),
                                    new XElement("content", item.ReviewText),
                                    bookTag);

                                resultSetTag.Add(reviewTag);
                            }
                        }

                        root.Add(resultSetTag);
                    }
                }
            }

            if (!hasByPeriodQuery)
            {
                //throw new ApplicationException("Invalid input XML file - Missing at least one 'by-period' query tag");                        
            }

            var doc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), root);
            doc.Save(outputFilename);
        }
    }
}
