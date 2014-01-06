using System;

namespace WCFStringCompare
{
    public class StringCount : IStringCount
    {
        public int GetSubstringCount(string input, string substring)
        {
            int count = 0;
            int startIndex = input.IndexOf(substring);
            while (startIndex >= 0)
            {
                count++;
                startIndex = input.IndexOf(substring, startIndex + 1);
            }

            return count;
        }
    }
}