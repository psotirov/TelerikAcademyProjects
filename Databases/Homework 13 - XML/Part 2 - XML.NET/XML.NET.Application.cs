using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.Xml.Linq;
using System.IO;
using System.Xml.Schema;

namespace Part_2___XML.NET
{
    class XML_NET_Application
    {
        static void Main()
        {
            // Task 1 - create albums catalogue - see attached xml file

            // Task 2
            GetDifferentArtists();

            // Task 3
            GetDifferentArtistsXPath();

            // Task 4
            RemoveAlbumsWithGreaterPrice(20);

            // Task 5
            GetAllSongTitles();

            // Task 6
            GetAllSongTitlesLINQ();

            // Task 7
            CreateXMLFromTextFile();

            // Task 8
            ConvertXMLFile();

            // Task 9
            SaveSubdirectoriesAndFilesIntoXMLFile(@"C:/Install");

            // Task 10
            SaveSubdirectoriesAndFilesIntoXMLFileLINQ(@"C:/Install");

            // Task 11
            GetPricesOfAllAlbumsPublishedBeforeYears(5);

            // Task 12
            GetPricesOfAllAlbumsPublishedBeforeYearsLINQ(5);
            
            // Task 13
            // See file catalogue.xslt, attached to the current project

            // Task 14
            ApplyXSLTransformationOnXMLFile();

            // Task 15
            ValidateXMLFileUsingXSD();
           
            
            Console.WriteLine("\n\nPress Enter to finish");
            Console.ReadLine();
        }

        static void GetDifferentArtists()
        {
            Console.WriteLine("List of different artists along with number of their albums:\n");
            var artists = new Dictionary<string, int>();
            var catalogue = new XmlDocument();
            catalogue.Load(@"../../Catalogue.xml");
            var albums = catalogue.DocumentElement.ChildNodes;
            foreach (XmlNode album in albums)
            {
                string artist = album["artist"].InnerText;
                if (!artists.ContainsKey(artist))
                {
                    artists.Add(artist, 0);
                }

                artists[artist]++;
            }

            foreach (var item in artists)
            {
                Console.WriteLine("{0} - {1} albums", item.Key, item.Value);
            }
        }

        static void GetDifferentArtistsXPath()
        {
            Console.WriteLine("\n\nList of different artists along with number of their albums XPATH:\n");
            var artists = new Dictionary<string, int>();
            var catalogue = new XmlDocument();
            catalogue.Load(@"../../Catalogue.xml");
            foreach (XmlNode artistNode in catalogue.SelectNodes("/catalogue/album/artist"))
            {
                string artist = artistNode.InnerText;
                if (!artists.ContainsKey(artist))
                {
                    artists.Add(artist, 0);
                }

                artists[artist]++;
            }

            foreach (var item in artists)
            {
                Console.WriteLine("{0} - {1} albums", item.Key, item.Value);
            }
        }

        static void RemoveAlbumsWithGreaterPrice(decimal price)
        {
            Console.WriteLine("\n\nRemoves all albums that have price, greater than {0:N2}:\n", price);
            var catalogue = new XmlDocument();
            catalogue.Load(@"../../Catalogue.xml");
            foreach (XmlNode album in catalogue.SelectNodes("/catalogue/album"))
            {
                decimal albumPrice = 0;
                decimal.TryParse(album["price"].InnerText, out albumPrice);
                if (albumPrice >= price)
                {
                    album.ParentNode.RemoveChild(album);
                }
            }

            catalogue.Save(@"../../CatalogueUpdated.xml");
        }

        static void GetAllSongTitles()
        {
            Console.WriteLine("\n\nList of song titles using XmlReader:\n");

            using (XmlReader reader = XmlReader.Create(@"../../Catalogue.xml"))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) &&
                        (reader.Name == "title"))
                    {
                        Console.WriteLine(reader.ReadElementString());
                    }
                }
            }
        }

        static void GetAllSongTitlesLINQ()
        {
            Console.WriteLine("\n\nList of song titles using LINQ:\n");

            XDocument xmlDoc = XDocument.Load(@"../../Catalogue.xml");
            var titles =
                from song in xmlDoc.Descendants("song")
                select song.Element("title").Value;
            foreach (var title in titles)
            {
                Console.WriteLine(title);
            }
        }

        public static void CreateXMLFromTextFile()
        {
            Console.WriteLine("\n\nConvert NameBook.txt into NameBook.xlm:\n");

            var namebook = new XElement("namebook");
            using (var inputFile = new System.IO.StreamReader(@"../../NameBook.txt"))
            {
                int count = 0;
                var item = new XElement("person");
                while (!inputFile.EndOfStream)
                {
                    string line = inputFile.ReadLine();
                    switch (count++ % 3)
                    {
                        case 0:
                            item.Add(new XElement("name", line));
                            break;
                        case 1:
                            item.Add(new XElement("address", line));
                            break;
                        default:
                            item.Add(new XElement("phone", line));
                            namebook.Add(item);
                            item = new XElement("person");
                            break;
                    }
                }

                if (!item.IsEmpty)
                {
                    namebook.Add(item);                    
                }

                var doc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), namebook);
                doc.Save(@"../../NameBook.xml");
            }
        }

        public static void ConvertXMLFile()
        {
            Console.WriteLine("\n\nConvert data  from Catalogue.xlm to Albums.xlm:\n");

            string title = "";
            string author = "";
            using (XmlReader reader = XmlReader.Create(@"../../Catalogue.xml"))
            {
                using (XmlTextWriter writer = new XmlTextWriter(@"../../Albums.xml",
                    System.Text.Encoding.GetEncoding("utf-8")))
                {
                    writer.Formatting = Formatting.Indented;
                    writer.IndentChar = ' ';
                    writer.Indentation = 4;
                    writer.WriteStartDocument();
                    writer.WriteStartElement("albums");


                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element && 
                            reader.Name == "name")
                        {
                            title = reader.ReadElementString();
                        }

                        if (reader.NodeType == XmlNodeType.Element &&
                             reader.Name == "artist")
                        {
                            author = reader.ReadElementString();
                        }

                        if (title.Length > 0 && author.Length > 0)
                        {
                            writer.WriteStartElement("album");
                            writer.WriteAttributeString("title", title);
                            writer.WriteAttributeString("author", author);
                            writer.WriteEndElement();
                            title = "";
                            author = "";
                        }
                    }

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                } 
            }
        }

        public static void SaveSubdirectoriesAndFilesIntoXMLFile(string root)
        {
            Console.WriteLine("\n\nCreating a sink list of all files and subdirectiries f {0}:\n", root);

            using (XmlTextWriter writer = new XmlTextWriter(@"../../DirTree.xml",
                System.Text.Encoding.GetEncoding("utf-8")))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = ' ';
                writer.Indentation = 4;
                writer.WriteStartDocument();
                writer.WriteStartElement("directoryTree");

                var rootDir = new DirectoryInfo(root);
                writer.WriteStartElement("dir");
                writer.WriteAttributeString("name", root);

                GetDirectoriesTree(writer, rootDir);
                    
                writer.WriteEndElement();
 
                writer.WriteEndElement();
                writer.WriteEndDocument();
            } 
        }

        private static void GetDirectoriesTree(XmlTextWriter writer, DirectoryInfo currentDir)
        {
            // fetch files
            try
            {
                var currentDirFiles = currentDir.EnumerateFiles();
                foreach (var file in currentDirFiles)
                {
                    writer.WriteStartElement("file");
                    writer.WriteAttributeString("name", file.Name);
                    writer.WriteAttributeString("size", file.Length.ToString());
                    writer.WriteEndElement();
                }
            }
            catch (UnauthorizedAccessException)
            {
                // "Access denied!" - skips file silently
            }

            // fetch directories using DFS
            try
            {
                var currentSubDirs = currentDir.EnumerateDirectories();
                foreach (var subDir in currentSubDirs)
                {
                    writer.WriteStartElement("dir");
                    writer.WriteAttributeString("name", subDir.Name);
                    GetDirectoriesTree(writer, subDir);
                    writer.WriteEndElement();
                }
            }
            catch (UnauthorizedAccessException)
            {
                // "Access denied!" - skips dir silently
            }
        }

        public static void SaveSubdirectoriesAndFilesIntoXMLFileLINQ(string root)
        {
            Console.WriteLine("\n\nCreating a LINQ sink list of all files and subdirectories of {0}:\n", root);

            var rootDir = new DirectoryInfo(root);
            XElement rootXmlElement = new XElement("dir",
                             new XAttribute("name", rootDir.Name));
            GetDirectoriesTreeLINQ(rootXmlElement, rootDir);
            var doc = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), rootXmlElement);
            doc.Save(@"../../DirTreeLINQ.xml");
        }


        private static void GetDirectoriesTreeLINQ(XElement parentXmlElement, DirectoryInfo currentDir)
        {
            // fetch files
            try
            {
                var currentDirFiles = currentDir.EnumerateFiles();
                foreach (var file in currentDirFiles)
                {
                    parentXmlElement.Add(new XElement("file",
                        new XAttribute("name", file.Name),
                        new XAttribute("size", file.Length.ToString())));
                }
            }
            catch (UnauthorizedAccessException)
            {
                // "Access denied!" - skips file silently
            }

            // fetch directories using DFS
            try
            {
                var currentSubDirs = currentDir.EnumerateDirectories();
                foreach (var subDir in currentSubDirs)
                {
                    var childXmlElement = new XElement("dir",
                        new XAttribute("name", subDir.Name));
                    GetDirectoriesTreeLINQ(childXmlElement, subDir);
                    parentXmlElement.Add(childXmlElement);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // "Access denied!" - skips dir silently
            }
        }

        public static void GetPricesOfAllAlbumsPublishedBeforeYears(int years)
        {
            Console.WriteLine("\n\nGets prices of all albums released before {0} years:\n", years);

            DateTime currentDate = DateTime.Now;
            int year = currentDate.Year - years;
            XmlDocument catalogue = new XmlDocument();
            catalogue.Load(@"../../Catalogue.xml");
            string xPathQuery = "catalogue/album[year < " + year + "]";

            XmlNodeList albums = catalogue.SelectNodes(xPathQuery);
            foreach (XmlNode album in albums)
            {
                string price = album.SelectSingleNode("price").InnerText;
                string name = album.SelectSingleNode("name").InnerText;
                string albumYear = album.SelectSingleNode("year").InnerText;
                Console.WriteLine("Album {0} - Year: {1} - Price: {2}", name, albumYear, price);
            }
        }

        public static void GetPricesOfAllAlbumsPublishedBeforeYearsLINQ(int years)
        {
            Console.WriteLine("\n\nGets LINQ prices of all albums released before {0} years:\n", years); 
            
            DateTime currentDate = DateTime.Now;
            int year = currentDate.Year - years;
            XDocument catalogue = XDocument.Load(@"../../Catalogue.xml");

            var albums =
                from album in catalogue.Descendants("album")
                where int.Parse(album.Element("year").Value) < year
                select new
                {
                    Title = album.Element("name").Value,
                    Year = album.Element("year").Value,
                    Price = album.Element("price").Value,
                };

            foreach (var album in albums)
            {
                Console.WriteLine("Album {0} - Year: {1} - Price: {2}", album.Title, album.Year, album.Price);
            }

        }

        public static void ApplyXSLTransformationOnXMLFile()
        {
            var xslt = new System.Xml.Xsl.XslCompiledTransform();
            xslt.Load("../../catalogue.xslt");
            xslt.Transform("../../catalogue.xml", "../../catalog.html");
        }

        public static void ValidateXMLFileUsingXSD()
        {
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add("", "../../albumsCatalog.xsd");
            Console.WriteLine("\n\nAttempting to validate albumsCatalog.xml");

            // Valid xml document
            XDocument catalogue = XDocument.Load("../../albumsCatalog.xml");

            // Invalid xml document removed some tags from the last album.
            // XDocument catalogue = XDocument.Load("../../albumsCatalog2.xml");
            bool errors = false;
            catalogue.Validate(schemas, (o, e) =>
            {
                Console.WriteLine("{0}", e.Message);
                errors = true;
            });
            Console.WriteLine("Catalogue {0}", errors ? "did not validate" : "validated");

        }
    }
}
