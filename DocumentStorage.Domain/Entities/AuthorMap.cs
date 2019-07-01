using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;

namespace DocumentStorage.Domain.Entities
{
    public class AuthorMap : ClassMapping<Author>
    {
        public AuthorMap()
        {
            Bag(x => x.Documents, c =>
            {
                c.Key(k => k.Column("AuthorID"));
            }, rel => rel.OneToMany());

            Id(x => x.AuthorID, map => map.Generator(Generators.Native));
            Property(x => x.Name);
            Property(x => x.Login, c => c.Unique(true));
            Property(x => x.Password);

        }
    }
}
