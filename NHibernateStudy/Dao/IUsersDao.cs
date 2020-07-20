using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domains;

namespace Dao
{
    public interface IUsersDao
    {
        object Save(Users entity);

        void Update(Users entity);

        void Delete(Users entity);

        Users Get(int id);
    }
}
