using System.Collections.Generic;

namespace DocumentStorage.Domain.Entities
{
    public class Author 
    {
        public virtual int AuthorID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Login { get; set; }
        public virtual string Password { get; set; }

        private IList<Document> _documents;
        public virtual IList<Document> Documents
        {
            get
            {
                return _documents ?? (_documents = new List<Document>());
            }
            set
            {
                _documents = value;
            }
        }
    }
}
