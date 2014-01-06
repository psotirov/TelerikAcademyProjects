using System;

namespace _02_Bank
{
    class Loan:Account
    {
        public Loan(Customer holder, decimal interest = 0.416m, decimal balance = 100.0m)
            : base(holder, interest, balance)
        {
        }

        public override decimal InterestAmount(int numberOfMonths)
        {
            if (this.Holder is Person)
            {
                // applying Personal Mortgage Interest Rate system
                if (numberOfMonths <= 3) return 0.0m; // no interest for the first 3 months
                return base.InterestAmount(numberOfMonths - 3); // the rest of the period is standard
            }
            if (this.Holder is Company)
            {
                // applying Company Mortgage Interest Rate system
                if (numberOfMonths <= 2) return 0.0m; // no interest for the first 2 months
                return base.InterestAmount(numberOfMonths - 2); // the rest of the period is standard
            }
            // returns result of default calculation
            return base.InterestAmount(numberOfMonths);
        }
    }
}
