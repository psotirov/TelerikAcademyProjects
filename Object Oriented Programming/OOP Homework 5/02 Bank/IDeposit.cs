using System;

namespace _02_Bank
{
    public interface IDeposit
    {
        bool Withdraw(decimal amount);
    }
}
