using System;
using System.Text;
using ServiceStack.Redis;

namespace RedisDictionary
{
    class RedisDictionary
    {
        static void Main(string[] args)
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

            using (var redisClient = new RedisClient("127.0.0.1:6379"))
            {
                for (int i = 0; i < dictionaryData.GetLength(0); i++)
                {
                    if (redisClient.HExists("dictionary", ToByteArray(dictionaryData[i, 0])) == 0)
                    {
                        redisClient.HSetNX("dictionary", ToByteArray(dictionaryData[i, 0]), ToByteArray(dictionaryData[i, 1]));
                    } 
                }

                PrintAllWords(redisClient);
                Console.WriteLine("\nSearch for word \"blob\":");
                FindWord(redisClient, "blob");
            }
        }

        private static void FindWord(RedisClient client, string key)
        {
            if (client.HExists("dictionary", ToByteArray(key)) > 0)
            {
                var translation = IntoString(client.HGet("dictionary", ToByteArray(key)));
                Console.WriteLine(translation);
            }
        }

        private static void PrintAllWords(RedisClient client)
        {
            var words = client.HGetAll("dictionary"); // returns byte[][], where first dimension is [key],[value],..,[key],[value]

            Console.WriteLine("All words in dictionary:");
            for (int i = 0; i < words.GetLength(0); i+=2)
            {
                Console.WriteLine("{0} -> {1}",
                    IntoString(words[i]), IntoString(words[i+1]));    
            }
        }

        public static byte[] ToByteArray(string s)
        {
            byte[] array = new byte[s.Length];

            for (int i = 0; i < s.Length; i++)
            {
                array[i] = (byte)(((int)s[i]) % 256);
            }

            return array;
        }

        public static string IntoString(byte[] arr)
        {
            StringBuilder sb = new StringBuilder(arr.Length);
            for (int i = 0; i < arr.Length; i++)
            {
                sb.Append((char)arr[i]);
            }

            return sb.ToString();
        }

    }
}
