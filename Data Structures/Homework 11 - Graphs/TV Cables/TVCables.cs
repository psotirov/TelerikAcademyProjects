using System;
using System.Collections.Generic;

namespace TV_Cables
{
    class TVCables
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Finds minimal length of TV cables, using Kruskal algorithm\n");
            List<Connection> connections = new List<Connection>();

            Initialize(connections);
            Console.WriteLine("Initial distances between houses(in rows and columns):");
            PrintConnections(connections);

            Console.WriteLine("Minimal spanning tree of TV cables:");
            List<Connection> minimalCables = FindMinimumSpanningTree(connections);
            PrintConnections(minimalCables);
        }

        private static List<Connection> FindMinimumSpanningTree(List<Connection> connections)
        {
            List<Connection> minimalTree = new List<Connection>();
            int[] tree = new int[connections.Count * 2]; // the maximal limit case is when each connection has two unique houses
            int treesCount = 1;
            connections.Sort();

            foreach (var connection in connections)
            {
                if (tree[connection.StartHouse] == 0) // not visited
                {
                    if (tree[connection.EndHouse] == 0) // both ends are not visited
                    {
                        tree[connection.StartHouse] = tree[connection.EndHouse] = treesCount;
                        treesCount++;
                    }
                    else
                    {
                        // attach the start node to the tree of the end node
                        tree[connection.StartHouse] = tree[connection.EndHouse];
                    }

                    minimalTree.Add(connection);
                }
                else // the start is part of a tree
                {
                    if (tree[connection.EndHouse] == 0)
                    {
                        //attach the end node to the tree;
                        tree[connection.EndHouse] = tree[connection.StartHouse];
                        minimalTree.Add(connection);
                    }
                    else if (tree[connection.EndHouse] != tree[connection.StartHouse]) // combine the trees
                    {
                        int oldTreeNumber = tree[connection.EndHouse];

                        for (int i = 0; i < tree.Length; i++)
                        {
                            if (tree[i] == oldTreeNumber)
                            {
                                tree[i] = tree[connection.StartHouse];
                            }
                        }

                        minimalTree.Add(connection);
                    }
                }
            }

            return minimalTree;
        }

        private static void PrintConnections(List<Connection> usedConnections)
        {
            int totalLength = 0;
            foreach (var connection in usedConnections)
            {
                Console.WriteLine(connection);
                totalLength += connection.CableLength;
            }

            Console.WriteLine("\nTotal length: {0}\n\n", totalLength);
        }

        private static void Initialize(List<Connection> connections)
        {
            // the TV cable connections are as follows:
            // we have 3 rows x 4 columns of houses (numbered from 1 to 12, first row 1 2 3 4)
            // distances: column 1 to 2 = 5, column 2 to 3 = 11, column 3 to 4 = 7
            // distances: row 1 to 2 = 4, row 2 to 3 = 13
            // we have connection between houses in each row and in each column

            connections.Add(new Connection(1, 2, 5)); // row 1
            connections.Add(new Connection(2, 3, 11));
            connections.Add(new Connection(3, 4, 7));

            connections.Add(new Connection(5, 6, 5)); // row 2
            connections.Add(new Connection(6, 7, 11));
            connections.Add(new Connection(7, 8, 7));

            connections.Add(new Connection(9, 10, 5)); // row 3
            connections.Add(new Connection(10, 11, 11));
            connections.Add(new Connection(11, 12, 7));


            connections.Add(new Connection(1, 5, 4)); // column 1
            connections.Add(new Connection(5, 9, 13)); 

            connections.Add(new Connection(2, 6, 4)); // column 2
            connections.Add(new Connection(6, 10, 13)); 

            connections.Add(new Connection(3, 7, 4)); // column 3
            connections.Add(new Connection(7, 11, 13)); 

            connections.Add(new Connection(4, 8, 4)); // column 4
            connections.Add(new Connection(8, 12, 13));
        }

    }
}
