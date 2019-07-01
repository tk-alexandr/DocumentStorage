using DocumentStorage.Domain.Abstract;
using DocumentStorage.WebUI.Infrastructure.Abstract;
using DocumentStorage.WebUI.Models;
using System.Web.Mvc;

namespace DocumentStorage.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private IAuthProvider authProvider;
        private IDocumentsRepository repository;
        public AccountController(IAuthProvider auth, IDocumentsRepository rep)
        {
            authProvider = auth;
            repository = rep;
        }

        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {

                if (authProvider.Authenticate(model.UserName, model.Password, repository))
                {
                    return Redirect(returnUrl ?? Url.Action("List", "Document"));
                }
                else
                {
                    ModelState.AddModelError("", "Неверное имя пользователя или пароль");
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Logout()
        {
            authProvider.SignOut();
            return Redirect(Url.Action("List", "Document"));
        }

        
    }
}