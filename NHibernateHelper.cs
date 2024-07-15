using FluentNHibernate.Cfg;
using FluentNHibernate.Data;
using NHibernate;
using NHibernate.Cfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TrainingNHibernate.Domain;
using TrainingNHibernate.Mappings;

namespace TrainingNHibernate
{
    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var cfg = new Configuration();
                    cfg.Configure();
                    _sessionFactory = Fluently.Configure(cfg)
                        .Mappings(
                          m => m.FluentMappings.AddFromAssemblyOf<TrainingOrderMap>()).BuildSessionFactory();
                }
                return _sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
