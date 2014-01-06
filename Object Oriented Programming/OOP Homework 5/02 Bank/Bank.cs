using System;
using System.Collections.Generic;

namespace _02_Bank
{
    class Bank
    {
        static void Main()
        {
            Console.WriteLine("Task 02 - Bank Implementation\r\n");

            // creates some customers wihtout any accounts
            List<Customer> customers = new List<Customer>();
            customers.Add(new Company("Titanic EOOD", "BG123456789"));
            customers.Add(new Company("Udavihmese AD", "BG987654321"));
            customers.Add(new Person("Bai Tosho", "4409091111"));
            customers.Add(new Person("Pesho Peshov", "8911102222"));
            customers.Add(new Person("Rosko Riapata", "6506013333"));

            // creates ome accounts and attaches to the existing customers 
            List<Account> accounts = new List<Account>();
            accounts.Add(new Loan(customers[0], 1.0m, 100000));
            accounts.Add(new Deposit(customers[1], 0.2m, 50000));
            accounts.Add(new Deposit(customers[2], 0.8m, 10000));
            accounts.Add(new Loan(customers[3], 2.5m, 7500));
            accounts.Add(new Mortgage(customers[3], 0.3m, 150000));
            accounts.Add(new Loan(customers[4], 3.0m, 5000));
            accounts.Add(new Loan(customers[4], 2.0m, 15000));

            // prints all accounts to Console and calculates 12-months interest
            Console.WriteLine("All accounts:");
            foreach (Account item in accounts)
            {
                Console.WriteLine(item);
                Console.WriteLine("    Interest for 12 months with {0}% monthly rate is {1}", item.InterestRatePerMonth, item.InterestAmount(12));
            }

            // some operations
            if ((accounts[2] as Deposit).Withdraw(2000)) Console.WriteLine("\r\nSuccessful withdrawing of 2000 from:\r\n    " + accounts[2]);
            accounts[4].Deposit(1000);
            Console.WriteLine("Successful depositing of 1000 to:\r\n    " + accounts[4]);

            // prints all customers and their accounts to Console
            Console.WriteLine("\r\nBank customers state:");
            foreach (Customer item in customers)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\r\nPress Enter to finish");
            Console.ReadLine();
        }
    }
}
