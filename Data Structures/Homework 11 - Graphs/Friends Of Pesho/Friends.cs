using System;
using System.IO;
using System.Collections.Generic;

namespace Friends_Of_Pesho
{
    class Friends
    {
        static int countNodes;
        static int countStreets;
        static int countHospitals;

        static Dictionary<int, Node> hospitals = new Dictionary<int,Node>();
        static Dictionary<int, Node> nodes = new Dictionary<int, Node>();
        static Dictionary<Node, List<Street>> map = new Dictionary<Node, List<Street>>();

        static void Main()
        {
            Console.SetIn(new StreamReader(@"..\..\input.txt"));
            GetInput();

            ulong minDistance = ulong.MaxValue;
            foreach (var hospital in hospitals)
            {
                Dijkstra.FindMinimalPaths(map, hospital.Value);
                ulong totalDistance = GetTotalDistance();
                if (totalDistance < minDistance)
                {
                    minDistance = totalDistance;
                }
            }

            Console.WriteLine(minDistance);            
        }

        static void GetInput()
        {
            // first input line
            string[] nodesData = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            countNodes = int.Parse(nodesData[0]);
            countStreets = int.Parse(nodesData[1]);
            countHospitals = int.Parse(nodesData[2]);

            // second input line
            string[] hospitalsData = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < countHospitals; i++)
            {
                int hospitalID = int.Parse(hospitalsData[i]);
                hospitals.Add(hospitalID, new Node(hospitalID, true));
            }

            for (int i = 1; i <= countNodes; i++)
            {
                if (hospitals.ContainsKey(i))
                {
                    nodes.Add(i, hospitals[i]);
                }
                else
                {
                    nodes.Add(i, new Node(i));
                }
            }

            // third to third + countStreets input lines - gets the map (connections between nodes)
            for (int i = 0; i < countStreets; i++)
            {
                string[] streetData = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                Node startNode = nodes[int.Parse(streetData[0])];
                Node endNode = nodes[int.Parse(streetData[1])];
                ulong distance = ulong.Parse(streetData[2]);

                // connection between start node and end node
                if (!map.ContainsKey(startNode))
                {
                    map.Add(startNode, new List<Street>());
                }

                map[startNode].Add(new Street(endNode, distance));

                // connection between end node and start node
                if (!map.ContainsKey(endNode))
                {
                    map.Add(endNode, new List<Street>());
                }

                map[endNode].Add(new Street(startNode, distance));
            }
        }

        static ulong GetTotalDistance()
        {
            ulong distance = 0;

            foreach (var node in nodes)
            {
                if (!node.Value.IsHospital)
                {
                    distance += node.Value.DijkstraDistance;
                }
            }

            return distance;
        }
    }
}
