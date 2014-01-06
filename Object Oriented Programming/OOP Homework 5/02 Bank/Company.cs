using System;

namespace _02_Bank
{
    class Company : Customer
    {
        public string VatNumber { get; set; }

        public Company(string name, string vatNumber = "BG000000000")
            : base(name)
        {
            this.VatNumber = vatNumber;
        }

        public override string GetData()
        {
            return String.Format(", VAT Number={0}", this.VatNumber);
        }
    }
}
