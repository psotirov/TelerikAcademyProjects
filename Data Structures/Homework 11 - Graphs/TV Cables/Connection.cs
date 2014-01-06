using System;

namespace TV_Cables
{
    class Connection : IComparable<Connection>
    {
        public int StartHouse { get; set; }
        public int EndHouse { get; set; }
        public int CableLength { get; set; }

        public Connection(int start, int end, int length)
        {
            this.StartHouse = start;
            this.EndHouse = end;
            this.CableLength = length;
        }

        public int CompareTo(Connection other)
        {
            int lengthCompared = this.CableLength.CompareTo(other.CableLength);

            if (lengthCompared == 0)
            {
                return this.StartHouse.CompareTo(other.StartHouse);
            }
            return lengthCompared;
        }

        public override string ToString()
        {
            return string.Format("({0} {1}) -> {2}", StartHouse, EndHouse, CableLength);
        }

    }
}
