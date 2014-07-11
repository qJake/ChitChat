using System.Collections.Generic;
using System.Web.Http;
using ChitChat.Server.Hubs;
using ChitChat.Server.Model;
using Microsoft.AspNet.SignalR;

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

        [HttpGet]
        [Route("api/posts/create")]
        public void Post()
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<PostHub>();
            context.Clients.All.NewPostNotification();
        }
    }
}
