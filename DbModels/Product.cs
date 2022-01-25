using System;
using System.Collections.Generic;

namespace PMAprojekt.DbModels
{
    public partial class Product
    {
        public int IdProduct { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public int IdTypeOfProduct { get; set; }
        public string Username { get; set; }

        public virtual TypeOfProduct IdTypeOfProductNavigation { get; set; }
    }
}
