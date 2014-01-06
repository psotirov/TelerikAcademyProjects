using System;

namespace FriendsInNeed
{
    public class Node : IComparable
    {
        public int ID { get; private set; }
        public bool IsHospital { get; set; }
        public ulong DijkstraDistance { get; set; }

        public Node(int id, bool isHospital = false)
        {
            this.ID = id;
            this.IsHospital = isHospital;
        }

        public int CompareTo(object obj)
        {
            return this.DijkstraDistance.CompareTo((obj as Node).DijkstraDistance);
        }
    }
}
