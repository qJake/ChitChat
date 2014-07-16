using System.Collections.Generic;
using System.Web.Http;
using ChitChat.Server.Model;

namespace ChitChat.Server.Controllers
{
    public class CategoriesController : ApiController
    {
        [HttpGet]
        [Route("api/categories/all")]
        public IEnumerable<Category> All()
        {
            return Categories.GetCategories();
        }

        [HttpGet]
        [Route("api/categories/get/{id}")]
        public Category Get(int id)
        {
            return Categories.GetCategory(id);
        }
    }
}
