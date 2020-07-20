using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domains;

namespace Dao
{
    public interface IRolesDao
    {
        object Save(Roles entity);

        void Update(Roles entity);

        void Delete(Roles entity);

        Roles Get(int id);
    }
}
