using Lesson4CreateObject.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4CreateObject.Factory
{
    public static class StaticObjectFactory
    {
        public static PersonDao GetInstance()
        {
            return new PersonDao();
        }
    }
}
