using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMAprojekt.Models;
using PMAprojekt.Repositories;

namespace PMAprojekt.Services
{
    public class PostService
    {
        private readonly PostsRepository _postRepository;
        public PostService(PostsRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public IEnumerable<Models.Post> GetAll()
        {
            return _postRepository.GetAll();
        }

        public void Save(Post post)
        {
            _postRepository.Save(post);
        }
    }
}
