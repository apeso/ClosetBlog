
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMAprojekt.DbModels;


namespace PMAprojekt.Mappers
{
    public class ProductsMappers
    {
        public static Models.Product FromDatabase(DbModels.Product product)
        {
            return new Models.Product(
                product.IdProduct,
                product.Name,
                product.Link,
                product.IdTypeOfProduct,
                product.Username
                );
        }

        public static DbModels.Product ToDatabase(Models.Product product)
        {
            return new DbModels.Product
            {
                IdProduct= product.IdProduct,
                Name= product.Name,
                Link= product.Link,
                IdTypeOfProduct= product.IdTypeOfProduct,
                Username= product.UserName
            };
        }
    }
}
