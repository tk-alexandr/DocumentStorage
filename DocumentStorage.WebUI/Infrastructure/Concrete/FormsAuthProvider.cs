using DocumentStorage.Domain.Entities;
using DocumentStorage.Domain.Abstract;
using DocumentStorage.WebUI.Infrastructure.Abstract;
using System.Linq;
using System.Web.Security;

namespace DocumentStorage.WebUI.Infrastructure.Concrete
{

    public class FormsAuthProvider : IAuthProvider
    {

        public bool Authenticate(string username, string password, IDocumentsRepository repository)
        {
            Author author = repository.Authors.FirstOrDefault(a => a.Login ==username && a.Password == password);
            bool result = author != null;
            if (result)
            {
                FormsAuthentication.SetAuthCookie(username, false);
            }

            return result;
        }

        public void SignOut()
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

    }
}