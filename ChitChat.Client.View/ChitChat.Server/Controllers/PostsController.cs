using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ChitChat.Server.Model;

namespace ChitChat.Server.Controllers
{
    public class PostsController : ApiController
    {
        [HttpGet]
        [Route("api/posts/all")]
        public IEnumerable<Post> All()
        {
            return Posts.GetPosts();
        }

        [HttpGet]
        [Route("api/posts/{id}")]
        public Post Get(int id)
        {
            return Posts.GetPost(id);
        }

        [HttpGet]
        [Route("api/posts/recent/{count}")]
        public IEnumerable<Post> Recent(int count = 10)
        {
            return Posts.GetRecentPosts(count);
        }
    }
}
