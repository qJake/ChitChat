using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ChitChat.Server.Controllers
{
    [Authorize]
    public class SecureController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Username = HttpContext.User.Identity.Name;
            ViewBag.Roles = Roles.GetRolesForUser(HttpContext.User.Identity.Name);
            return View();
        }
	}
}