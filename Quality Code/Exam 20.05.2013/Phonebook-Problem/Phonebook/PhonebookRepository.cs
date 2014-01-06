using System;
using System.Collections.Generic;
using System.Linq;

namespace Phonebook
{
    /// <summary>
    /// Holds all information about application's Phonebook 
    /// </summary>
    public class PhonebookRepository : IPhonebookRepository
    {
        public List<PhonebookEntry> Entries = new List<PhonebookEntry>();

        /// <summary>
        /// Adds new entry if the Person Name is not existing in the list
        /// Otherwise updates Person's information about its phone numbers
        /// </summary>
        /// <param name="name">Person Name</param>
        /// <param name="phoneNumbers">Enumeration of phone numbers as strings +359xxxxxxxxxx</param>
        /// <returns>
        /// true, if a new entry has been appended
        /// false, if an existing entry has been updated
        /// </returns>
        public bool AddPhone(string name, IEnumerable<string> phoneNumbers)
        {
            var sameEntries = from entry in this.Entries
                      where entry.Name.ToLowerInvariant() == name.ToLowerInvariant()
                      select entry;

            bool isNewEntry;
            if (sameEntries.Count() == 0)
            {
                PhonebookEntry newEntry = new PhonebookEntry();
                newEntry.Name = name;
                newEntry.PhoneNumbers = new SortedSet<string>();

                foreach (var phoneNumber in phoneNumbers)
                {
                    newEntry.PhoneNumbers.Add(phoneNumber);
                }

                this.Entries.Add(newEntry);
                isNewEntry = true;
            }
            else if (sameEntries.Count() == 1)
            {
                PhonebookEntry existingEntry = sameEntries.First();
                foreach (var phoneNumber in phoneNumbers)
                {
                    existingEntry.PhoneNumbers.Add(phoneNumber);
                }

                isNewEntry = false;
            }
            else
            {
                throw new ApplicationException("Duplicated name in the phonebook found: " + name);
            }

            return isNewEntry;
        }

        /// <summary>
        /// Changes a phone number with new one in all records
        /// </summary>
        /// <param name="oldNumber">Existing phone number as string +359xxxxxxxxx</param>
        /// <param name="newNumber">New phone number as string +359xxxxxxxxx</param>
        /// <returns>number of phone numbers changed actually</returns>
        public int ChangePhone(string oldNumber, string newNumber)
        {
            var entriesFoundList = from entries in this.Entries
                       where entries.PhoneNumbers.Contains(oldNumber)
                       select entries;
            int itemsChanged = 0;
            foreach (var entry in entriesFoundList)
            {
                entry.PhoneNumbers.Remove(oldNumber);
                entry.PhoneNumbers.Add(newNumber);
                itemsChanged++;
            }

            return itemsChanged;
        }

        /// <summary>
        /// Gets a subset of Phonebook entries from the Repository 
        /// </summary>
        /// <param name="start">Starting index of the Repository's array</param>
        /// <param name="count">Number of elements</param>
        /// <returns>
        /// Array of PhonebookEntry if start and count are within Repository's range
        /// Otherwise returns empty array (null)
        /// </returns>
        public PhonebookEntry[] ListEntries(int start, int count)
        {
            if (start < 0 || start + count > this.Entries.Count)
            {
                // returns empty Phonebook List on invalid range requested
                return null;
            }

            this.Entries.Sort();
            PhonebookEntry[] selectedEntries = new PhonebookEntry[count];
            for (int i = start; i <= start + count - 1; i++)
            {
                PhonebookEntry entry = this.Entries[i];
                selectedEntries[i - start] = entry;
            }

            return selectedEntries;
        }
    }
}
