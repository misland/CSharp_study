using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domains;
using NHibernate;

namespace Dao
{
    public class UsersDao:IUsersDao
    {
        private ISessionFactory factory;
        private ISession session;
        public UsersDao(ISessionFactory factory)
        {
            this.factory = factory;
            this.session = factory.OpenSession();
        }

        public object Save(Domains.Users entity)
        {
            //var session = factory.OpenSession();
            var result = session.Save(entity);
            session.Flush();
            return result;
        }

        public void Update(Domains.Users entity)
        {
            //var session = factory.OpenSession();
            session.Update(entity);
            session.Flush();
        }

        public void Delete(Domains.Users entity)
        {
            //var session = factory.OpenSession();
            session.Delete(entity);
            session.Flush();
        }

        public Domains.Users Get(int id)
        {
            //var session = factory.OpenSession();
            return session.Get<Users>(id);
        }
    }
}
