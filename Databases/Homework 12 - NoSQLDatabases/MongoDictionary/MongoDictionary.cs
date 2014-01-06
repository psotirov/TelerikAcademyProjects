using System;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace MongoDictionary
{
    public class MongoDictionary
    {
        private static void Main()
        {
            var dictionaryData = new string[,]
            {
                { ".NET", "platform for applications from Microsoft" },
                { "CLR", "managed execution environment for .NET" },
                { "namespace", "hierarchical organization of classes" },
                { "database", "structured sets of persistent updateable and queriable data" },
                { "blob", "binary large object" },
                { "RDBMS", "relational database management system" },
                { "json", "JavaScript Object Notation" },
                { "xml", "Extensible Markup Language" },
            };

            string connectionString = "mongodb://localhost/";
            MongoClient client = new MongoClient(connectionString);
            MongoServer server = client.GetServer();
            MongoDatabase database = server.GetDatabase("dictionary");
            // database.DropCollection("words");
            var words = database.GetCollection<Word>("words");

            for (int i = 0; i < dictionaryData.GetLength(0); i++)
            {
                Word dictItem = new Word();
                dictItem.KeyWord = dictionaryData[i,0];
                dictItem.Description = dictionaryData[i, 1];
                if (words.AsQueryable().Where(w => w.KeyWord == dictItem.KeyWord).Count() == 0)
                {
                    words.Insert(dictItem);                    
                }
            }

            PrintAllWords(words);
            Console.WriteLine("\nSearch for word \"blob\":");
            FindWord(words, "blob");
        }

        private static void FindWord(MongoCollection<Word> collection, string key)
        {
            var word = collection.AsQueryable().Where(w => w.KeyWord == key).FirstOrDefault();
            Console.WriteLine(word);
        }

        private static void PrintAllWords(MongoCollection<Word> collection)
        {
            var words = collection.AsQueryable().ToList();

            Console.WriteLine("All words in dictionary:");
            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}