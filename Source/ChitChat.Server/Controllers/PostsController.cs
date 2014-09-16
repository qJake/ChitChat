using System.Collections.Generic;
using System.Web.Http;
using ChitChat.Server.Hubs;
using ChitChat.Server.Model;
using Microsoft.AspNet.SignalR;

namespace ChitChat.Server.Controllers
{
    public class PostsController : ApiController
    {
        private static IHubContext HubContext
        {
            get { return GlobalHost.ConnectionManager.GetHubContext<PostHub>(); }
        }

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
            HubContext.Clients.All.NewPostNotification(Posts.GetPost(5));
        }

        [HttpPost]
        public void Create([FromBody] Post post)
        {
            Posts.AddPost(post);
            HubContext.Clients.All.NewPostNotification(post);
        }
    }
}
