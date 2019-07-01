using DocumentStorage.Domain.Abstract;
using DocumentStorage.Domain.Entities;
using NHibernate;
using System.Linq;

namespace DocumentStorage.Domain.Concrete
{
    public class NHibernateDocumentRepository : IDocumentsRepository
    {
        ISession session = NHibernateHelper.OpenSession();
        public IQueryable<Document> Documents
        {
            get {
                return session.QueryOver<Document>().List().AsQueryable();
            }
        }

        public IQueryable<Author> Authors
        {
            get
            {
                return session.QueryOver<Author>().List().AsQueryable();
            }
        }

        public void AddDocument(Document document)
        {
            var trasaction = session.BeginTransaction();
            session.Save(document);
            trasaction.Commit();
        }
    }
}
