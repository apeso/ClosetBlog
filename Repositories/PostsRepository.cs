using PMAprojekt.Mappers;
using PMAprojekt.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace PMAprojekt.Repositories
{
    public class PostsRepository
    {
        private readonly ClosetContext _dbContext;
        public PostsRepository(ClosetContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Models.Post> GetAll()
        {
            return _dbContext.Post.Select(x => PostsMappers.FromDatabase(x));
        }
        public void Save(Models.Post post)
        {
            var dbPost = PostsMappers.ToDatabase(post); //podatak pogodan za bazu
            _dbContext.Post.Add(dbPost);
            _dbContext.SaveChanges();
        }
    }
}
