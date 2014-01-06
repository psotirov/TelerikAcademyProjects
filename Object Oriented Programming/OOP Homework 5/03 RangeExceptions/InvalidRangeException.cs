using System;

namespace _03_RangeExceptions
{
    public class InvalidRangeException<T> : ApplicationException
    {
        public InvalidRangeException()
            : base("Bad Range using " + typeof(T))
        {
        }

        public InvalidRangeException(string message)
            : base(message + " using " + typeof(T))
        {
        }

        public InvalidRangeException(string message, Exception innerEx)
            : base(message + " with " + typeof(T))
        {
        }
    }
}
