using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Homework_6___Entity_Framework
{
    class NorthwindEntitiesCopy : DbContext
    {
    }

    public class Northwind
    {
        public static void Main(string[] args)
        {            
            // Task 2
            Console.WriteLine("Adding new record to Cutomers table in Northwind database...");
            Customer cust1 = CustomersDAO.Insert("Pesho Trading Ltd", country: "Bulgaria", city: "Sofia", contactName: "Pesho Peshov");
            Console.WriteLine("Inserted " + cust1);
            Customer cust2 = CustomersDAO.Insert("Pesho Trading 2 Ltd", country: "Bulgaria", city: "Sofia", contactName: "Pesho Peshov");
            Console.WriteLine("Inserted " + cust2);
            cust2 = CustomersDAO.Modify(cust2.CustomerID, "Pesho Trading 3 Ltd", city: "Plovdiv");
            Console.WriteLine("Modified last record to " + cust2);
            bool OK = CustomersDAO.Delete(cust2.CustomerID);
            Console.WriteLine("Last record " + (OK ? "Deleted " : "FAILED to delete "));

            // Task 3
            Console.WriteLine("\nFinds all customers that placed orders to Canada in 1997 using LINQ:");
            ShowCustomersByOrderYearAndCountry(1997, "Canada");

            // Task 4
            Console.WriteLine("\nFinds all customers that placed orders to Canada in 1997 using SQL:");
            ShowCustomersByOrderYearAndCountrySQL(1997, "Canada");
            
            // Task 5
            Console.WriteLine("\nFinds all orders in year 1997 that are in NM region:");
            ShowOrdersByRegionAndPeriod("NM", new DateTime(1997, 1, 1), new DateTime(1997, 12, 31));
            
            // Task 6
            CopyDatabaseSchema();
            
            // Task 7
            ConcurentChanges();
            
            // Task 8
            ShowFirstEmployeeWithTerritories();

            // Task 9
            AddOrderInTransactionScope();
            
            // Task 10
            /* Created stored procedure in Northwind database
            CREATE PROCEDURE [dbo].[TotalIncomesForGivenSupplier] @SupplierName nvarchar(30), @StartDate datetime, @EndDate datetime AS
                SELECT SUM(p.UnitPrice)
                FROM Orders o JOIN [Order Details] od ON o.OrderId = od.OrderId
                JOIN Products p ON od.ProductId = p.ProductId
                JOIN Suppliers s ON s.SupplierId = p.SupplierId 
                WHERE s.CompanyName = @SupplierName AND o.ShippedDate BETWEEN @StartDate AND @EndDate
            */
            CalculateTotalIncomes();

            // Task 11
            CreateUserInGroup();
        }

        public static void ShowCustomersByOrderYearAndCountry(int year, string country)
        {
            var ctx = new NorthwindEntities();
            var query = from customer in ctx.Customers
                        join order in ctx.Orders
                            on customer.CustomerID equals order.CustomerID
                        where (order.OrderDate.Value.Year == year && order.ShipCountry == country)
                        select customer;

            int count = 1;
            foreach (var item in query)
            {
                Console.WriteLine("{0} - CustomerID: {1}, Company Name: {2}", count++, item.CustomerID, item.CompanyName);
            }

            Console.WriteLine("\nTotal {0} records selected.\n", count - 1);
        }

        public static void ShowCustomersByOrderYearAndCountrySQL(int year, string country)
        {
            var sqlCommand = "SELECT * FROM Customers AS c" +
                             "  JOIN Orders AS o" +
                             "    ON c.CustomerID = o.CustomerID " + 
                             "WHERE YEAR(o.OrderDate) = {0} AND o.ShipCountry = {1}";
            var ctx = new NorthwindEntities();
            var query = ctx.Database.SqlQuery<Customer>(sqlCommand, year, country);
 
            int count = 1;
            foreach (var item in query)
            {
                Console.WriteLine("{0} - CustomerID: {1}, Company Name: {2}", count++, item.CustomerID, item.CompanyName);
            }

            Console.WriteLine("\nTotal {0} records selected.\n", count - 1);
        }

        public static void ShowOrdersByRegionAndPeriod(string region, DateTime startDate, DateTime endDate)
        {
            var ctx = new NorthwindEntities();
            var query = from ordersInPeriod in ctx.Sales_by_Year(startDate, endDate)
                            join orders in ctx.Orders
                                on ordersInPeriod.OrderID equals orders.OrderID
                            where (orders.ShipRegion == region)
                            select orders;

            int count = 1;
            foreach (var item in query)
            {
                Console.WriteLine("Order: {0}, Date: {1:dd/MM}, To: {2}, Price: {3:N2}",
                    item.OrderID, item.ShippedDate, item.ShipName, item.Freight);
                count++;
            }

            Console.WriteLine("\nTotal {0} records selected.\n", count - 1);
        }

        public static void CopyDatabaseSchema()
        {
            Console.WriteLine("Creating copy of Northwind database in the MS SQL server...(wait a moment)");
            IObjectContextAdapter initialDBSchema = new NorthwindEntities();
            string dbScript = initialDBSchema.ObjectContext.CreateDatabaseScript();

            DbContext newDBSchema = new DbContext("Server=localhost;Database=NorthwindTwin;Integrated Security=True;");
            newDBSchema.Database.CreateIfNotExists();
            (newDBSchema as IObjectContextAdapter).ObjectContext.ExecuteStoreCommand(dbScript);            
        }

        public static void ConcurentChanges()
        {
            using (var ctx1 = new NorthwindEntities())
            {
                Employee employeeFromCtx1 = ctx1.Employees.First(e => e.EmployeeID == 1);
                employeeFromCtx1.FirstName = "Pesho";

                // Modify and Save the same employee in another context  
                // i.e. mimicking concurrent access. 
                using (var ctx2 = new NorthwindEntities())
                {
                    Employee employeeFromCtx2 = ctx2.Employees.First(e => e.EmployeeID == 1);
                    employeeFromCtx2.FirstName = "Gosho";
                    ctx2.SaveChanges();
                }
                // Console.ReadLine();
                // Save the changes... This should result in an Exception, but NOT due to EF 5 Optimistic Concurrency 
                ctx1.SaveChanges();
            }
        }

        public static void ShowFirstEmployeeWithTerritories()
        {
            Console.WriteLine("Showing Employee[1] with its territories using EntitySet");
            using (var ctx = new NorthwindEntities())
            {
                var employee = ctx.Employees.First(e => e.EmployeeID == 1);
                Console.WriteLine("Employee[1] name=" + employee.FirstName + " " + employee.LastName);
                foreach (var item in employee.EntitySetTerritories)
	            {
                    Console.WriteLine("Territory: " + item.TerritoryDescription);
	            }
            }
        }

        public static void AddOrderInTransactionScope()
        {
            Console.WriteLine("Adding two orders using TransactionScope...");
            using (NorthwindEntities northwindEntities = new NorthwindEntities())
            {
                Order firstOrder = new Order();
                firstOrder.CustomerID = "TOMSP";
                firstOrder.ShipName = "First Order Ship Name";
                Order secondOrder = new Order();
                secondOrder.CustomerID = "OCEAN";
                secondOrder.ShipName = "Second Order Ship Name";
                
                using (System.Transactions.TransactionScope scope = new System.Transactions.TransactionScope())
                {
                    northwindEntities.Orders.Add(firstOrder);
                    northwindEntities.SaveChanges();

                    northwindEntities.Orders.Add(secondOrder);
                    northwindEntities.SaveChanges();

                    scope.Complete();
                }

                firstOrder = northwindEntities.Orders.Find(firstOrder.OrderID);
                secondOrder = northwindEntities.Orders.Find(secondOrder.OrderID);
                Console.WriteLine("FirstOrder.ShipName={0}, SecondOrder.ShipName={1}", firstOrder.ShipName, secondOrder.ShipName);
            }
        }


        public static void CalculateTotalIncomes()
        {
            Console.WriteLine("Calculates total incomes of Pavlova, Ltd. for year 1997...");
            DateTime startDate = new DateTime(1997, 1, 1);
            DateTime endDate = new DateTime(1998, 1, 1);
            string supplierName = "Pavlova, Ltd.";
            using (var northwindEntities = new NorthwindEntities())
            {
                var totalIncomes = northwindEntities.TotalIncomesForGivenSupplier(supplierName, startDate, endDate).ToList();
                Console.WriteLine("Incomes: {0:N2}", totalIncomes[0]);
            }
        }


        public static void CreateUserInGroup()
        {
            Console.WriteLine("Adding new user 'mancho' and attach it to the 'Admins' group...");
            string username = "mancho";

            using (var northwindEntities = new NorthwindEntities())
            {
                using (var scope = new System.Transactions.TransactionScope())
                {
                    User someUser = new User();
                    someUser.Username = username;
                    someUser.FullName = "Chicho Mancho";
                    someUser.Password = "ilovesnowwhite";

                    string adminGroup = "Admins";
                    var group = northwindEntities.Groups.Where(a => a.Name == adminGroup).ToList();
                    if (group.Count == 0)
                    {
                        Group newGroup = new Group();
                        newGroup.Name = adminGroup;

                        northwindEntities.Groups.Add(newGroup);
                        northwindEntities.SaveChanges();
                        group.Add(newGroup);
                    }

                    someUser.GroupId = group[0].GroupId;
                    northwindEntities.Users.Add(someUser);
                    northwindEntities.SaveChanges();
                    scope.Complete();
                }
            }
        }
    }
}
