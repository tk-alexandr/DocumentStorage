using NHibernate;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Dialect;
using NHibernate.Mapping.ByCode;
using NHibernate.Tool.hbm2ddl;
using System.Reflection;


namespace DocumentStorage.Domain
{
    public class NHibernateHelper
    {
        private static ISessionFactory sessionFactory = null;
        public static ISession OpenSession()
        {
            if (sessionFactory == null)
            {
                var cfg = new Configuration()
                .DataBaseIntegration(db =>
                {
                    db.ConnectionString = @"Server=DESKTOP-285LRRA\SQLEXPRESS;initial catalog=DocumentStorage;Integrated Security=SSPI;";
                    db.Dialect<MsSql2012Dialect>();
                });

                var mapper = new ModelMapper();
                mapper.AddMappings(Assembly.GetExecutingAssembly().GetExportedTypes());
                HbmMapping mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
                cfg.AddMapping(mapping);
                new SchemaUpdate(cfg).Execute(true, true);
                sessionFactory = cfg.BuildSessionFactory();
            }

            return sessionFactory.OpenSession();
        }
    }
}
