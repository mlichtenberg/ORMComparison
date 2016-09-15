using ContosoUniversity.FluentNH.Domain;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Configuration;

namespace ContosoUniversity.FluentNH
{
    public class NhibernateSession
    {
        private static ISessionFactory _sessionFactory;
        private static string _connectionKeyName;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitializeSessionFactory();
                return _sessionFactory;
            }
        }

        private static void InitializeSessionFactory()
        {
            string connectionString = ConfigurationManager.ConnectionStrings[_connectionKeyName].ToString();

            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(connectionString).ShowSql())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Enrollment>())
                // ----------------------------------------------
                // Add optimizations suggested at http://weblogs.asp.net/ricardoperes/on-nhibernate-performance
                .BuildConfiguration().SetProperty(NHibernate.Cfg.Environment.FormatSql, Boolean.FalseString)
                .SetProperty(NHibernate.Cfg.Environment.GenerateStatistics, Boolean.FalseString)
                .SetProperty(NHibernate.Cfg.Environment.Hbm2ddlKeyWords, NHibernate.Cfg.Hbm2DDLKeyWords.None.ToString())
                .SetProperty(NHibernate.Cfg.Environment.PrepareSql, Boolean.TrueString)
                .SetProperty(NHibernate.Cfg.Environment.PropertyBytecodeProvider, "lcg")
                .SetProperty(NHibernate.Cfg.Environment.PropertyUseReflectionOptimizer, Boolean.TrueString)
                .SetProperty(NHibernate.Cfg.Environment.QueryStartupChecking, Boolean.FalseString)
                .SetProperty(NHibernate.Cfg.Environment.ShowSql, Boolean.FalseString)
                //.SetProperty(NHibernate.Cfg.Environment.StatementFetchSize, "100")
                .SetProperty(NHibernate.Cfg.Environment.UseProxyValidator, Boolean.FalseString)
                .SetProperty(NHibernate.Cfg.Environment.UseSecondLevelCache, Boolean.FalseString)
                // ----------------------------------------------
                .BuildSessionFactory();
        }

        public static ISession OpenSession(string connectionKeyName)
        {
            _connectionKeyName = connectionKeyName;
            return SessionFactory.OpenSession();
        }
    }
}
