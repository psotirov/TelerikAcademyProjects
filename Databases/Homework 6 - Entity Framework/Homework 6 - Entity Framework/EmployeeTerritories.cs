using System;
using System.Linq;
using System.Data.Linq;

namespace Homework_6___Entity_Framework
{
    public partial class Employee
    {
        public EntitySet<Territory> EntitySetTerritories
        {
            get
            {
                EntitySet<Territory> convert = new EntitySet<Territory>();
                convert.AddRange(this.Territories);
                return convert;
            }
        }
    }
}
