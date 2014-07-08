using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChitChat.Server.Model
{
    public class Categories
    {
        public static IList<Category> GetCategories()
        {
            using (var context = new Entities())
            {
                return (from c in context.Categories
                        select c).ToList();
            }
        }

        public static Category GetCategory(int id)
        {
            using (var context = new Entities())
            {
                return (from c in context.Categories
                        where c.ID == id
                        select c).FirstOrDefault();
            }
        }

        public static Category GetCategory(string name)
        {
            using (var context = new Entities())
            {
                return (from c in context.Categories
                        where c.Name == name
                        select c).FirstOrDefault();
            }
        }

        public static void AddCategory(Category newCategory)
        {
            using (var context = new Entities())
            {
                context.Categories.Add(newCategory);
                context.SaveChanges();
            }
        }

        public static void UpdateCategory(Category category)
        {
            using (var context = new Entities())
            {
                var original = (from c in context.Categories
                                where c.ID == category.ID
                                select c).First();
                context.Entry<Category>(original).CurrentValues.SetValues(category);
                context.SaveChanges();
            }
        }

        public static void DeleteCategory(Category category)
        {
            using (var context = new Entities())
            {
                context.Categories.Remove(category);
                context.SaveChanges();
            }
        }

        public static void DeleteCategory(int id)
        {
            using (var context = new Entities())
            {
                DeleteCategory((from c in context.Categories
                                where c.ID == id
                                select c).First());
            }
        }
    }
}
