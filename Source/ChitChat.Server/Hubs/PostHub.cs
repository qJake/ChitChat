using ChitChat.Server.Model;
using Microsoft.AspNet.SignalR;

namespace ChitChat.Server.Hubs
{
    public class PostHub : Hub
    {
        public void RegisterClient()
        {
            if (Context.User.Identity.IsAuthenticated)
            {
                Clients.Caller.RegisterClientResponse(new
                {
                    status = "success",
                    data = ""
                });
            }
            else
            {
                Clients.Caller.RegisterClientResponse(new
                {
                    status = "fail",
                    error = "User is not authenticated."
                });
            }
        }

        public void GetCategory()
        {
            Clients.Caller.GetCategoryResponse(Categories.GetCategories());
        }

        public void CreatePost(Post post)
        {
            Posts.AddPost(post);
            var newPost = Posts.GetPost(post.ID);
            Clients.All.NewPostNotification(newPost);
        }
    }
}