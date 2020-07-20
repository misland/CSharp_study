using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;

namespace Dao
{
    public class ProductDao:IProductDao
    {
        private ISessionFactory factory;
        public ProductDao(ISessionFactory factory)
        {
            this.factory = factory;
        }
        public object Save(Domains.Product entity)
        {
            ISession session = factory.OpenSession();
            var id = session.Save(entity);
            entity.Code = "def";//会同步到数据库
            session.Flush();
            return id;
        }

        public void Update(Domains.Product entity)
        {
            ISession session = factory.OpenSession();
            session.Update(entity);
            entity.SellPrice = 1200;//会同步到数据库
            session.Flush();
        }

        public void Delete(Domains.Product entity)
        {
            ISession session = factory.OpenSession();
            session.Delete(entity);
            session.Flush();
        }

        public Domains.Product Get(Guid id)
        {
            ISession session = factory.OpenSession();
            var result= session.Get<Domains.Product>(id);
            return result;
        }

        public Domains.Product Load(Guid id)
        {
            ISession session = factory.OpenSession();
            var result = session.Load<Domains.Product>(id);
            //result.QuantityPerUnit = "tai";//不会同步到数据库
            return result;
        }

        public IList<Domains.Product> LoadAll()
        {
            ISession session = factory.OpenSession();
            return session.Query<Domains.Product>().ToList();
        }
    }
}
