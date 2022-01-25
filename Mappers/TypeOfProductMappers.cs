using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMAprojekt.Models;

namespace PMAprojekt.Mappers
{
    public class TypeOfProductMappers
    {
        public static TypeOfProduct FromDatabase(DbModels.TypeOfProduct tipprodukta)
        {
            return new TypeOfProduct(
                tipprodukta.IdTypeOfProduct,
                tipprodukta.Name
                );
        }
        public static DbModels.TypeOfProduct ToDatabase(Models.TypeOfProduct tipprodukta)
        {
            return new DbModels.TypeOfProduct
            {
                IdTypeOfProduct = tipprodukta.IdTypeOfProduct,
                Name = tipprodukta.Name
            };
        }

    }
}
