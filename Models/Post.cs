using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMAprojekt.Models
{
    public class Post
    {
        public int IdPost { get; set; }
        public string Description { get; set; }
        public string Username { get; set; }
        public string Link { get; set; }

        public Post(int id,string desc,string user,string link)
        {
            this.IdPost = id;
            this.Description = desc;
            this.Username=user;
            this.Link = link;
        }
    }
}
