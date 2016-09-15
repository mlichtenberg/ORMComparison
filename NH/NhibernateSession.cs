using ContosoUniversity.NH.Domain;
using NHibernate;
using NHConfig = NHibernate.Cfg;
using System.Configuration;
using System;

namespace ContosoUniversity.NH
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
                {
                    string connectionString = ConfigurationManager.ConnectionStrings[_connectionKeyName].ToString();

                    var configuration = new NHConfig.Configuration();
                    configuration.Configure();

                    // Info about loading NH configuration from app settings:
                    // http://stackoverflow.com/questions/1984976/how-to-load-application-settings-to-nhibernate-cfg-configuration-object/
                    configuration.SetProperty(NHConfig.Environment.ConnectionString, connectionString);

                    // ----------------------------------------------
                    // Add optimizations suggested at http://weblogs.asp.net/ricardoperes/on-nhibernate-performance
                    configuration.SetProperty(NHibernate.Cfg.Environment.FormatSql, Boolean.FalseString);
                    configuration.SetProperty(NHibernate.Cfg.Environment.GenerateStatistics, Boolean.FalseString);
                    configuration.SetProperty(NHibernate.Cfg.Environment.Hbm2ddlKeyWords, NHConfig.Hbm2DDLKeyWords.None.ToString());
                    configuration.SetProperty(NHibernate.Cfg.Environment.PrepareSql, Boolean.TrueString);
                    configuration.SetProperty(NHibernate.Cfg.Environment.PropertyBytecodeProvider, "lcg");
                    configuration.SetProperty(NHibernate.Cfg.Environment.PropertyUseReflectionOptimizer, Boolean.TrueString);
                    configuration.SetProperty(NHibernate.Cfg.Environment.QueryStartupChecking, Boolean.FalseString);
                    configuration.SetProperty(NHibernate.Cfg.Environment.ShowSql, Boolean.FalseString);
                    //configuration.SetProperty(NHibernate.Cfg.Environment.StatementFetchSize, "100");
                    configuration.SetProperty(NHibernate.Cfg.Environment.UseProxyValidator, Boolean.FalseString);
                    configuration.SetProperty(NHibernate.Cfg.Environment.UseSecondLevelCache, Boolean.FalseString);
                    // ----------------------------------------------

                    configuration.AddAssembly(typeof(Enrollment).Assembly);
                    _sessionFactory = configuration.BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }

        public static ISession OpenSession(string connectionKeyName)
        {
            _connectionKeyName = connectionKeyName;
            return SessionFactory.OpenSession();
        }
    }
}
