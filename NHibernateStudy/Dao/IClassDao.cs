using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domains;

namespace Dao
{
    public interface IClassDao
    {
        object Save(Class entity);

        void Update(Class entity);

        void Delete(Class entity);

        Class Get(int id);
    }
}
