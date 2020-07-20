using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domains;

namespace Dao
{
    public interface IStudentDao
    {
        Student Get(int id);

        void Delete(Student entity);
    }
}
