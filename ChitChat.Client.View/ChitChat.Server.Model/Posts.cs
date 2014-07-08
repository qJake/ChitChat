using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ChitChat.Server.Model
{
    public static class Posts
    {
        public static IList<Post> GetRecentPosts(int count)
        {
            using (var context = new Entities())
            {
                return (from p in context.Posts.Include(p => p.PostSecurities)
                                               .Include(p => p.Comments)
                                               .Include(p => p.User)
                                               .Include(p => p.Category)
                        orderby p.Created descending
                        select p).Take(count).ToList();
            }
        }

        public static IList<Post> GetPosts()
        {
            using (var context = new Entities())
            {
                return (from p in context.Posts.Include(p => p.PostSecurities)
                                               .Include(p => p.Comments)
                                               .Include(p => p.User)
                                               .Include(p => p.Category)
                        select p).ToList();
            }
        }

        public static Post GetPost(int id)
        {
            using (var context = new Entities())
            {
                return (from p in context.Posts
                        where p.ID == id
                        select p).FirstOrDefault();
            }
        }

        public static void AddPost(Post newPost)
        {
            using (var context = new Entities())
            {
                context.Posts.Add(newPost);
                context.SaveChanges();
            }
        }

        public static void UpdatePost(Post post)
        {
            using (var context = new Entities())
            {
                var original = (from p in context.Posts
                                where p.ID == post.ID
                                select p).First();
                context.Entry<Post>(original).CurrentValues.SetValues(post);
                context.SaveChanges();
            }
        }

        public static void DeletePost(int id)
        {
            using (var context = new Entities())
            {
                DeletePost((from p in context.Posts
                            where p.ID == id
                            select p).First());
            }
        }

        public static void DeletePost(Post post)
        {
            using (var context = new Entities())
            {
                context.Posts.Remove(post);
                context.SaveChanges();
            }
        }
    }
}
