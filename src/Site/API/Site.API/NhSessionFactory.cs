using Infrastructure.DataAccess;
using NHibernate;

namespace Site.API;

public static class NhSessionFactory
{
    public static ISessionFactory Instance { get; }

    static NhSessionFactory()
    {
        Instance = new SessionFactoryBuilder()
                   .AddFluentMappingsFrom("DictionarySystem.Application")
                   .Build();
    }
}