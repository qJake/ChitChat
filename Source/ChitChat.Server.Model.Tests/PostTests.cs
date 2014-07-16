using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ChitChat.Server.Model.Tests
{
    [TestClass]
    public class PostTests
    {
        [TestMethod]
        public void GetPosts()
        {
            var posts = Posts.GetPosts();

            Assert.IsTrue(posts.Count > 0);
        }

        [TestMethod]
        public void AddPost()
        {
            var post = new Post
            {
                CatID = Categories.GetCategory(1).ID,
                UserID = Users.GetUser(@"CSIINC\Jake").ID,
                Body = Faker.Lorem.Sentence(10)
            };

            Posts.AddPost(post);

            Assert.AreNotEqual(0, post.ID);
        }
       
        [TestMethod]
        public void DeletePost()
        {
            var posts = Posts.GetPosts().OrderByDescending(p => p.ID).ToList();
            if (posts.Count > 0)
            {
                var firstPost = posts[0];
                var firstPostID = firstPost.ID;
                Posts.DeletePost(firstPost);

                Assert.IsNull(Posts.GetPost(firstPostID));
            }
        }
    }
}
