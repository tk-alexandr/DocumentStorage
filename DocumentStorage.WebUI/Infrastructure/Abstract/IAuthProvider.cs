using DocumentStorage.Domain.Abstract;

namespace DocumentStorage.WebUI.Infrastructure.Abstract
{
    public interface IAuthProvider
    {
        bool Authenticate(string username, string password, IDocumentsRepository repository);
        void SignOut();
    }
}
