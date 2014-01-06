using System;
using System.Collections.Generic;

namespace Phonebook
{
    public interface IPhonebookRepository
    {
        bool AddPhone(string name, IEnumerable<string> phoneNumbers);

        int ChangePhone(string oldPhoneNumber, string newPhoneNumber);

        PhonebookEntry[] ListEntries(int startIndex, int count);
    }
}
