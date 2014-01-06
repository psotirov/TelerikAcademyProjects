using System;
using System.Collections.Generic;

namespace _02_Bank
{
    public interface ICustomer
    {
        // the customer must have at least Name and List of Accounts
        string Name { get; set; }
        List<Account> Accounts { get; }
    }
}
