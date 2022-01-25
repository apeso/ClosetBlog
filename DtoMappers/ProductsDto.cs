using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMAprojekt.Models;
using Newtonsoft.Json.Linq;

namespace PMAprojekt.DtoMappers
{
    public class ProductsDto
    {
        public static Product FromJson(JObject json)
        {
            var id = json["idProduct"].ToObject<int>();
            var name = json["name"].ToObject<string>();
            var link = json["link"].ToObject<string>();
            var id_produkta = json["idTypeOfProduct"].ToObject<int>();
            var username = json["username"].ToObject<string>();

            return new Product(id, name, link, id_produkta, username);
        }
    }
}
