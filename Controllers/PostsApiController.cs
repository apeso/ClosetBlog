using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PMAprojekt.DtoMappers;
using PMAprojekt.Models;
using PMAprojekt.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace PMAprojekt.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostsApiController : ControllerBase
    {
        private PostService _postservice;
        public PostsApiController(PostService postservice)
        {
            _postservice = postservice;
        }
        [HttpGet]
        public ActionResult<List<Post>> Get()
        {
            return _postservice.GetAll().ToList();
        }
        [HttpPost("save")]
        public ActionResult Save([FromBody] JObject json)
        {
            var post = PostsDto.FromJson(json);
            _postservice.Save(post);
            return Ok();
        }
    }


}
