using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChitChat.Server.Model
{
    public static class Users
    {
        public static User GetUser(string principal)
        {
            using (var context = new Entities())
            {
                return (from u in context.Users
                        where u.Principal == principal
                        select u).FirstOrDefault();
            }
        }

        public static void AddUser(User newUser)
        {
            using (var context = new Entities())
            {
                context.Users.Add(newUser);
                context.SaveChanges();
            }
        }

        public static void UpdateUser(User user)
        {
            using (var context = new Entities())
            {
                var original = (from u in context.Users
                                where u.ID == user.ID
                                select u).First();
                context.Entry<User>(original).CurrentValues.SetValues(user);
                context.SaveChanges();
            }
        }
    }
}
