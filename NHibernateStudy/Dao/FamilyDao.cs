using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domains;
using NHibernate;

namespace Dao
{
    public class FamilyDao:IFamilyDao
    {
        private ISessionFactory factory;
        public FamilyDao(ISessionFactory factory)
        {
            this.factory = factory;
        }

        public Family Save(Family entity)
        {
            ISession session = factory.OpenSession();
            var tem= session.Save(entity);
            session.Flush();
            return tem as Family;
        }

        public void Delete(Family entity)
        {
            ISession session = factory.OpenSession();
            session.Delete(entity);
            session.Flush();
        }


        public Family Get(int id)
        {
            ISession session = factory.OpenSession();
            return session.Get<Family>(id);

        }
    }
}
