using System;
using System.Collections.Generic;

namespace FriendsInNeed
{
    public class Dijkstra
    {
        public static void FindMinimalPaths(Dictionary<Node, List<Street>> graph, Node source)
        {
            PriorityQueue<Node> queue = new PriorityQueue<Node>();

            foreach (var node in graph)
            {
                if (source.ID != node.Key.ID)
                {
                    node.Key.DijkstraDistance = ulong.MaxValue;
                }
            }

            source.DijkstraDistance = 0;
            queue.Enqueue(source);

            while (queue.Count != 0)
            {
                Node currentNode = queue.Dequeue();

                foreach (var neighbour in graph[currentNode])
                {
                    ulong potDistance = currentNode.DijkstraDistance + neighbour.Distance;

                    if (potDistance < neighbour.Node.DijkstraDistance)
                    {
                        neighbour.Node.DijkstraDistance = potDistance;
                        // adds only modified elements in the queue
                        // thus reordering the queue after each iteration is avoided
                        queue.Enqueue(neighbour.Node);
                    }
                }
            }
        }
    }
}
