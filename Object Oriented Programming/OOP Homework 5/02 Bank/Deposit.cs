using System;

namespace _02_Bank
{
    class Deposit : Account, IDeposit
    {
        public Deposit(Customer holder, decimal interest = 0.416m, decimal balance = 100.0m)
            : base(holder, interest, balance)
        {
        }

        public override decimal InterestAmount(int numberOfMonths)
        {
            if (this.Balance < 1000.0m) return 0.0m;
            // returns result of default calculation
            return base.InterestAmount(numberOfMonths); 
        }

        public bool Withdraw(decimal amount)
        {
            // withdraw amount should be positive
            if (amount < 0.01m) throw new ArgumentOutOfRangeException("Invalid withdraw amount");
            if ((this.Balance - amount) < 0.01m) return false; // customer may withdraw money up to available balance
            this.Balance -= amount;
            return true;
        }
    }
}
