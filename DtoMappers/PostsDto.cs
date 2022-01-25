using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMAprojekt.Models;
using Newtonsoft.Json.Linq;

namespace PMAprojekt.DtoMappers
{
    public class PostsDto
    {
        public static Post FromJson(JObject json)
        {
            var id = json["idPost"].ToObject<int>();
            var desc = json["description"].ToObject<string>();
            var user = json["username"].ToObject<string>();
            var link = json["link"].ToObject<string>();

            return new Post(id, desc, user, link);

        }
    }
}
