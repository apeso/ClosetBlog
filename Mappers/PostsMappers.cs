using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMAprojekt.Models;

namespace PMAprojekt.Mappers
{
    public class PostsMappers
    {
        public static Post FromDatabase(DbModels.Post post)
        {
            return new Post(
                post.IdPost,
                post.Description,
                post.UserName,
                post.Link
                );
        }

        public static DbModels.Post ToDatabase(Models.Post post)
        {
            return new DbModels.Post
            {
                IdPost = post.IdPost,
                Description = post.Description,
                UserName=post.Username,
                Link = post.Link
            };
        }
    }
    
}
