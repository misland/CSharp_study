using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domains;
using NHibernate;

namespace Dao
{
    public class RolesDao:IRolesDao
    {
        private ISessionFactory factory;
        private ISession session;
        public RolesDao(ISessionFactory factory)
        {
            this.factory = factory;
            this.session = factory.OpenSession();
        }

        public object Save(Domains.Roles entity)
        {
            //var session = factory.OpenSession();
            var result = session.Save(entity);
            session.Flush();
            return result;
        }

        public void Update(Domains.Roles entity)
        {
            //var session = factory.OpenSession();
            session.Update(entity);
            session.Flush();
        }

        public void Delete(Domains.Roles entity)
        {
            //var session = factory.OpenSession();
            session.Delete(entity);
            session.Flush();
        }

        public Domains.Roles Get(int id)
        {
            //var session = factory.OpenSession();
            return session.Get<Roles>(id);
        }
    }
}
