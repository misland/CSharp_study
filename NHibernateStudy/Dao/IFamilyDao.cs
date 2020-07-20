using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domains;

namespace Dao
{
    public interface IFamilyDao
    {
        Family Save(Family entity);

        void Delete(Family entity);

        Family Get(int id);
    }
}
