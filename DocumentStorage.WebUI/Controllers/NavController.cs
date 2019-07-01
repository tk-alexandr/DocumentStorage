using DocumentStorage.WebUI.Models;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace DocumentStorage.WebUI.Controllers
{
    public class NavController : Controller
    {
        public PartialViewResult Menu()
        {
            

            NavMenuViewModel model = new NavMenuViewModel() {
                ListFilterInfo = (ListFilterInfo)Session["FilterInfo"] ?? new ListFilterInfo()
            };

            bool isAuthorised = Request.IsAuthenticated;
            ViewBag.isAuthorized = isAuthorised;

            if (isAuthorised)
            {
                string cookieName = FormsAuthentication.FormsCookieName;
                HttpCookie authCookie = HttpContext.Request.Cookies[cookieName];
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);
                string UserName = ticket.Name;
                ViewBag.UserName = UserName;
            }
            

            

            return PartialView(model);
        }

    }
}
