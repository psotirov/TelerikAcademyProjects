using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_BitArray64
{
    public class BitArray64 : IEnumerable<bool>
    {
        private ulong bitsHolder;

        public BitArray64() // default constructor
        {
            this.bitsHolder = 0; // clears explicitly all bits
        }

 
        IEnumerator<bool> IEnumerable<bool>.GetEnumerator()
        {
            for (int i = 0; i < 64; i++)
            {
                yield return this[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<bool>)this).GetEnumerator();
        }

        public bool this[int index]
        {
            get
            {
                if (index < 0 || index > 63) throw new ArgumentOutOfRangeException();

                if ((this.bitsHolder & (1UL << index)) > 0) return true;
                else return false;
            }

            set
            {
                if (index < 0 || index > 63) throw new ArgumentOutOfRangeException();

                if (value) this.bitsHolder = this.bitsHolder | (1UL << index); // sets the bit 
                else this.bitsHolder = this.bitsHolder & ( ulong.MaxValue ^ (1UL << index)); // clears the bit 
            }
        }

        public override bool Equals(object obj) // Equals compares bitsHolder properties (the same as ==) 
        {
            return this.bitsHolder.Equals(((BitArray64)obj).bitsHolder);
        }

        public override int GetHashCode() // returns hashcode of its bitHolder
        {
            return this.bitsHolder.GetHashCode();
        }

        public override string ToString() // returns binary representation of bitHolder property
        {
            // workarounds absence of integrated ulong binary conversion  
            string result = ((this.bitsHolder & 1)==1)?"1":"0"; // converts bit 0
            result = Convert.ToString((long)(this.bitsHolder >> 1), 2).PadLeft(63, '0') + result; // converts bits 63to1 and adds bit 0
            return result;
        }

        public static bool operator ==(BitArray64 obj1, BitArray64 obj2)
        {
            return (obj1.bitsHolder == obj2.bitsHolder);
        }

        public static bool operator !=(BitArray64 obj1, BitArray64 obj2)
        {
            return (obj1.bitsHolder != obj2.bitsHolder);
        }
    }
}
