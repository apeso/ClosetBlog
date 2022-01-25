using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMAprojekt.Models
{
    public class TypeOfProduct
    {
        public int IdTypeOfProduct { get; set; }
        public string Name { get; set; }

        public TypeOfProduct(int id, string name)
        {
            this.IdTypeOfProduct = id;
            this.Name = name;
        }
    }
}
