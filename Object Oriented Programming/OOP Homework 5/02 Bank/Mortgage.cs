using System;

namespace _02_Bank
{
    class Mortgage : Account
    {
        public Mortgage(Customer holder, decimal interest = 0.416m, decimal balance = 100.0m)
            : base(holder, interest, balance)
        {
        }

        public override decimal InterestAmount(int numberOfMonths)
        {
            if (this.Holder is Person)
            {
                // applying Personal Mortgage Interest Rate system

                // calculates interest at 1/2 of the default interest rate for the first 12 months  
                decimal interest = ((numberOfMonths <= 12) ? numberOfMonths : 12) * this.InterestRatePerMonth * this.Balance / 50;

                if (numberOfMonths > 12) interest += base.InterestAmount(numberOfMonths - 12); // the rest of the period is standard
                return interest; 
            }
            if (this.Holder is Company)
            {
                // applying Company Mortgage Interest Rate system
                if (numberOfMonths <= 6) return 0.0m; // no interest for the first 6 months
                return base.InterestAmount(numberOfMonths - 6); // the rest of the period is standard
            }
            // returns result of default calculation
            return base.InterestAmount(numberOfMonths);
        }
    }
}
