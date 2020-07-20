using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Domains;

namespace Dao
{
    public class ClassDao:IClassDao
    {
        private ISessionFactory factory;
        private ISession session;
        public ClassDao(ISessionFactory factory)
        {
            this.factory = factory;
            this.session = factory.OpenSession();
        }

        public object Save(Domains.Class entity)
        {
            //var session = factory.OpenSession();
            var result = session.Save(entity);
            session.Flush();
            return result;
        }

        public void Update(Domains.Class entity)
        {
            //var session = factory.OpenSession();
            session.Update(entity);
            session.Flush();
        }

        public void Delete(Domains.Class entity)
        {
            //var session = factory.OpenSession();
            session.Delete(entity);
            session.Flush();
        }

        public Domains.Class Get(int id)
        {
            //var session = factory.OpenSession();
            return session.Get<Class>(id);
        }
    }
}
