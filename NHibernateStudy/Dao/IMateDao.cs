using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domains;

namespace Dao
{
    public interface IMateDao
    {
        object Save(Mate entity);

        void Update(Mate entity);

        void Delete(Mate entity);

        Mate Get(int id);
    }
}
