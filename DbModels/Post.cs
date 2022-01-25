using System;
using System.Collections.Generic;

namespace PMAprojekt.DbModels
{
    public partial class Post
    {
        public int IdPost { get; set; }
        public string Description { get; set; }
        public string UserName { get; set; }
        public string Link { get; set; }
    }
}
