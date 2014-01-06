using System;
using System.Linq;

namespace Products.Models
{
    public class DataPersister
    {
        public static ProductViewModel GetById(int id)
        {
            ProductsDbEntities context = new ProductsDbEntities();
            using (context)
            {
                var currentProduct = context.Products.Find(id);
                if (currentProduct != null)
                {
                    return new ProductViewModel
                                         {
                                             Name = currentProduct.ProductName,
                                             ModelNumber = currentProduct.ProductNumber,
                                             UnitCost = currentProduct.UnitCost,
                                             Description = currentProduct.Description,
                                             CategoryName = currentProduct.Category.CategoryName
                                         };
                }
                else 
                {
                    return new ProductViewModel
                    {
                        Name = "No product with such id :)",
                        ModelNumber = "No information",
                        UnitCost = 0,
                        Description = "No description available",
                        CategoryName = "Uknown"
                    };
                }
            }
        }
    }
}
