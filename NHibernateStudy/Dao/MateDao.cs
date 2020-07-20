using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Domains;

namespace Dao
{
    public class MateDao:IMateDao
    {
        private ISessionFactory factory;
        public MateDao(ISessionFactory factory)
        {
            this.factory = factory;
        }

        public object Save(Domains.Mate entity)
        {
            var session = factory.OpenSession();
            var result = session.Save(entity);
            session.Flush();
            return result;
        }

        public void Update(Domains.Mate entity)
        {
            var session = factory.OpenSession();
            session.Update(entity);
            session.Flush();
        }

        public void Delete(Domains.Mate entity)
        {
            var session = factory.OpenSession();
            session.Delete(entity);
            session.Flush();
        }

        public Domains.Mate Get(int id)
        {
            var session = factory.OpenSession();
            return session.Get<Mate>(id);
        }
    }
}
