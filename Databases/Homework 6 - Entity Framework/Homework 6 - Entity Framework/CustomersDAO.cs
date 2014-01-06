using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_6___Entity_Framework
{
    public class CustomersDAO
    {
        const string LastPossibleCustomerId = "ZZZZZ";

        public static Customer Insert(string companyName,
            string contactName = null,
            string contactTitle = null,
            string address = null,
            string city = null,
            string region = null,
            string postalCode = null,
            string country = null,
            string phone = null,
            string fax = null)
        {
            var newCustomer = new Customer();
            newCustomer.CompanyName = companyName; 
            newCustomer.ContactName = contactName;
            newCustomer.ContactTitle = contactTitle; 
            newCustomer.Address = address;
            newCustomer.City = city; 
            newCustomer.Region = region; 
            newCustomer.PostalCode = postalCode; 
            newCustomer.Country = country; 
            newCustomer.Phone = phone;
            newCustomer.Fax = fax;

            string[] getWords = companyName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            newCustomer.CustomerID = getWords[0].Substring(0, 3) + 
                ((getWords.Length > 1) ? getWords[1].Substring(0, 2) : getWords[0].Substring(0, 2));
            newCustomer.CustomerID = newCustomer.CustomerID.ToUpperInvariant();

            using (var ctx = new NorthwindEntities())
            {
                while (ctx.Customers.Find(newCustomer.CustomerID) != null && newCustomer.CustomerID != LastPossibleCustomerId)
                {
                    for (int i = newCustomer.CustomerID.Length-1; i >= 0 ; i--)
                    {
                        if (newCustomer.CustomerID[i] < 'Z')
                        {
                            char[] letters = newCustomer.CustomerID.ToCharArray();
                            letters[i]++;
                            newCustomer.CustomerID = string.Join("", letters);
                            break;
                        }
                    }
                }
                ctx.Customers.Add(newCustomer);
                ctx.SaveChanges();
            }

            return newCustomer;
        }

        public static Customer Modify(string customerID,
            string companyName = null,
            string contactName = null,
            string contactTitle = null,
            string address = null,
            string city = null,
            string region = null,
            string postalCode = null,
            string country = null,
            string phone = null,
            string fax = null)
        {
            using (var ctx = new NorthwindEntities())
            {
                var theCustomer = ctx.Customers.Find(customerID);

                if (theCustomer == null) return null;
                if (companyName != null) theCustomer.CompanyName = companyName;
                if (contactName != null) theCustomer.ContactName = contactName;
                if (contactTitle != null) theCustomer.ContactTitle = contactTitle;
                if (address != null) theCustomer.Address = address;
                if (city != null) theCustomer.City = city;
                if (region != null) theCustomer.Region = region;
                if (postalCode != null) theCustomer.PostalCode = postalCode;
                if (country != null) theCustomer.Country = country;
                if (phone != null) theCustomer.Phone = phone;
                if (fax != null) theCustomer.Fax = fax;
                ctx.SaveChanges();
                return theCustomer;
            }
        }

        public static bool Delete(string customerID)
        {
            using (var ctx = new NorthwindEntities())
            {
                var theCustomer = ctx.Customers.Find(customerID);

                if (theCustomer == null) return false;

                ctx.Customers.Remove(theCustomer);
                if (ctx.SaveChanges() == 0) return false;
            }

            return true;
        }
    }
}
