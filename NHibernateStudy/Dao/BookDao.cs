using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using Domains;

namespace Dao
{
    public class BookDao:IBookDao
    {
        private ISessionFactory factory;
        public BookDao(ISessionFactory factory)
        {
            this.factory = factory;
        }

        public object Save(Domains.Book entity)
        {
            var session = factory.OpenSession();
            var result = session.Save(entity);
            session.Flush();
            return result;
        }

        public void Update(Domains.Book entity)
        {
            var session = factory.OpenSession();
            session.Update(entity);
            session.Flush();
        }

        public void Delete(Domains.Book entity)
        {
            var session = factory.OpenSession();
            session.Delete(entity);
            session.Flush();
        }

        public Domains.Book Get(BookId id)
        {
            var session = factory.OpenSession();
            return session.Get<Book>(id);
        }
    }
}
