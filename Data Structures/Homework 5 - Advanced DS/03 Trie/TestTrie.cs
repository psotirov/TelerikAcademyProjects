using System;
using System.Collections;
using System.IO;

namespace Trie
{
    class TestTrie
    {
        static void Main(string[] args)
        {
            //Root Node
            Node root = new Node("", "");

            //Loads Names
            TextReader reader;
            string textLine;

            try
            {
                reader = new StreamReader(@"..\..\names.txt");

                while ((textLine = reader.ReadLine()) != null)
                {
                    root = Trie.InsertNode(textLine, root);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Opening File: " + ex.Message);
            }

            Console.WriteLine("Enter Option");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine("1. DFS on Trie");
            Console.WriteLine("2. BFS on Trie");
            Console.WriteLine("3. Find a Name on the Directory");
            Console.WriteLine("4. Directory Lookup");
            Console.WriteLine("5. Exit");
            Console.WriteLine("--------------------------------------");
            Console.Write("Enter Option:");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    IEnumerator iterator = root.GetDepthNodes();

                    while (iterator.MoveNext())
                    {
                        Node n = (Node)iterator.Current;
                        Console.WriteLine(n.Value);
                    }
                    break;

                case 2:
                    IEnumerator iterator2 = root.GetBreadthNodes();

                    while (iterator2.MoveNext())
                    {
                        Node n = (Node)iterator2.Current;
                        Console.WriteLine(n.Value);
                    }
                    break;

                case 3:
                    Console.Write("Enter Name to Find(Case Sensitive):");
                    string name = Console.ReadLine();
                    bool fnd = Trie.Find(root, name);

                    if (fnd)
                        Console.WriteLine("Found");
                    else
                        Console.WriteLine("Not Found");
                    break;

                case 4:
                    Console.Write("Enter Name to Lookup(Case Sensitive):");
                    string name2 = Console.ReadLine();
                    Trie.GetChildrenStartingFromKey(root, name2);
                    break;
            }

            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Press any key to exit!");
            Console.ReadLine();
        }
    }
}
