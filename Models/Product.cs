using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace PMAprojekt.Models
{
    public class Product
    {
        public int IdProduct { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        
        public int IdTypeOfProduct { get; set; }
        public string UserName { get; set; }
        public Product(int id, string name, string link, int id_produkta, string username)
        {
            this.IdProduct = id;
            this.Name = name;
            this.Link = link;
            this.IdTypeOfProduct = id_produkta;
            this.UserName = username;
        }
    }
}
