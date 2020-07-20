using Lesson4CreateObject.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4CreateObject.Factory
{
    public class InstanceObjectFactory
    {
        public PersonDao GetInstance()
        {
            return new PersonDao();
        }
    }
}
