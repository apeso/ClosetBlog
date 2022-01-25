using System;
using System.Collections.Generic;

namespace PMAprojekt.DbModels
{
    public partial class TypeOfProduct
    {
        public TypeOfProduct()
        {
            Product = new HashSet<Product>();
        }

        public int IdTypeOfProduct { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
