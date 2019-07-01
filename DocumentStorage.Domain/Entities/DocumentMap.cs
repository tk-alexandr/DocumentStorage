using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace DocumentStorage.Domain.Entities
{
    public class DocumentMap : ClassMapping<Document>
    {
        public DocumentMap()
        {
            ManyToOne(x => x.Author, c =>
            {

                c.Column("AuthorID");
            });
            

            Id(x => x.DocumentID, map => map.Generator(Generators.Native));
            Property(x => x.Date);
            Property(x => x.Name);
            Property(x => x.Url);
        }
    }
}
