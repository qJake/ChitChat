using System.DirectoryServices;
using System.Web;
using System.Web.Http;
using ChitChat.Server.Model;

namespace ChitChat.Server.Controllers
{
    public class UsersController : ApiController
    {
        [HttpGet]
        [Route("api/users/{domain}/{principal}")]
        public User Get(string domain, string principal)
        {
            return Users.GetUser(domain + "\\" + principal);
        }

        [HttpGet]
        [Route("api/users/current")]
        public object Current()
        {
            var currentUser = HttpContext.Current.User.Identity.Name.Split('\\');

            SearchResult adSearchResult;

            using (var de = new DirectoryEntry("LDAP://csiinc.com"))
            {
                using (var adSearch = new DirectorySearcher(de))
                {
                    adSearch.Filter = "(sAMAccountName=" + currentUser[1] + ")";
                    adSearchResult = adSearch.FindOne();
                }
            }

            return new
            {
                Principal = HttpContext.Current.User.Identity.Name,
                Domain = currentUser[0],
                Username = currentUser[1],
                FullName = adSearchResult.Properties["displayname"][0].ToString()
            };
        }
    }
}
