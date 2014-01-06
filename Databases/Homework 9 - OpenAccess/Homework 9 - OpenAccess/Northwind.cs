using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.OpenAccess;

namespace Homework_9___OpenAccess
{
    class Northwind
    {
        static void Main()
        {
            var ctx = new NorthwindEntitiesModel.NorthwindFluentModel();
            using (ctx)
            {
                Console.WriteLine(ctx.Customers.Count());
            }
        }
    }
}
