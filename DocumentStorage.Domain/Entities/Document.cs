using System;

namespace DocumentStorage.Domain.Entities
{
    public class Document
    {
        public virtual int DocumentID { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual Author Author { get; set; }
        public virtual string Url { get; set; }
    }
}
