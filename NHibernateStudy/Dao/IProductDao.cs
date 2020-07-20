using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domains;

namespace Dao
{
    public interface IProductDao
    {
        object Save(Product entity);

        void Update(Product entity);

        void Delete(Product entity);

        Product Get(Guid id);

        Product Load(Guid id);

        IList<Product> LoadAll();
    }
}
