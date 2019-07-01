using DocumentStorage.Domain.Entities;
using System.Linq;

namespace DocumentStorage.Domain.Abstract
{
    
    public interface IDocumentsRepository
    {
        IQueryable<Document> Documents { get; }
        IQueryable<Author> Authors { get; }

        void AddDocument(Document document);
    }
}
