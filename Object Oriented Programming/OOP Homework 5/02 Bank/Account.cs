using System;

namespace _02_Bank
{
    public abstract class Account
    {
        public Customer Holder { get; protected set; }

        private decimal balance;
        public decimal Balance
        {
            get { return this.balance; }
            protected set
            {
                // the balance must be positive (don't mix it with overdraft)
                if (value < 0.01m) throw new ArgumentOutOfRangeException("Invalid balance amount");
                this.balance = value;
            }
        }

        private decimal interest; // interest rate in %
        public decimal InterestRatePerMonth
        {
            get { return this.interest; }
            protected set
            {
                // the interest rate must be positive (or zero in special cases)
                if (value < 0.0m) throw new ArgumentOutOfRangeException("Invalid Interest rate");
                this.interest = value;
            }
        }


        public Account(Customer holder, decimal interest = 0.416m, decimal balance = 100.0m)
        // default interestRate is 5% per year (0.416% per month) and the default balance is 100.0 
        {
            this.Holder = holder;
            this.InterestRatePerMonth = interest;
            this.Balance = balance;
            this.Holder.Accounts.Add(this); // automatically appends current account to the customer's list of accounts
        }

        public void Deposit(decimal amount)
        {
            // deposit amount should be positive
            if (amount < 0.01m) throw new ArgumentOutOfRangeException("Invalid deposit amount");
            this.Balance += amount;
        }

        public virtual decimal InterestAmount(int numberOfMonths)
        {
            // returns result of default calculation
            return numberOfMonths * this.InterestRatePerMonth * this.Balance / 100; // divided by 100 since we are holding interest rate in % 
        }

        public override string ToString()
        {
            // extracts only the class name (deletes leading data such as project name, etc.)
            string shapeType = this.GetType().ToString();
            if (shapeType.IndexOf('.') >= 0) shapeType = shapeType.Substring(shapeType.LastIndexOf('.') + 1);

            // returns whole structure data
            return String.Format("{0} {{ name={1}{2}, Balance={3} }}", shapeType, this.Holder.Name, this.Holder.GetData(), this.Balance);
        }
    }
}
