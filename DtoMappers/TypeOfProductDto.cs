using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMAprojekt.Models;
using Newtonsoft.Json.Linq;

namespace PMAprojekt.DtoMappers
{
    public class TypeOfProductDto
    {
        public static TypeOfProduct FromJson(JObject json)
        {
            var id = json["idTypeOfProduct"].ToObject<int>();
            var name = json["name"].ToObject<string>();

            return new TypeOfProduct(id, name);
        }
    }
}
