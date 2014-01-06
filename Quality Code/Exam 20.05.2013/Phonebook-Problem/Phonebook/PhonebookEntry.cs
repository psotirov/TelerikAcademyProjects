using System;
using System.Collections.Generic;
using System.Text;

namespace Phonebook
{
    /// <summary>
    /// Each object of this class hold a single Phonebook entry, i.e. PersonName and sorted list of canonical phonenumbers
    /// </summary>
    public class PhonebookEntry : IComparable<PhonebookEntry>
    {
        public string Name { get; set; }
        public SortedSet<string> PhoneNumbers { get; set; }

        /// <summary>
        /// String representtion of the Phoneboook entry
        /// </summary>
        /// <returns>string: [name: +359xxxxxxxx, +359xxxxxxxxx, ...]</returns>
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append('[');
            result.Append(this.Name);
            bool flag = true;
            foreach (var phone in this.PhoneNumbers)
            {
                if (flag)
                {
                    result.Append(": ");
                    flag = false;
                }
                else
                {
                    result.Append(", ");
                }

                result.Append(phone);
            }

            result.Append(']');
            return result.ToString();
        }

        /// <summary>
        /// Compares two Phonebook entries by their PersonName
        /// </summary>
        /// <returns>
        /// Less than 0 (zero) - this is less than other.
        /// 0 (zero) - this equals other.
        /// Greater than 0 (zero) - this is greater than other.
        /// </returns>
        public int CompareTo(PhonebookEntry other)
        {
            return this.Name.ToLowerInvariant().CompareTo(other.Name.ToLowerInvariant());
        }
    }

}
