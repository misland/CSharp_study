using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5Scope.Dao
{
    public class PersonDao
    {

        public PersonDao()
        {
            Console.WriteLine("PersonDao被实例");
        }

        public void Print()
        {
            Console.WriteLine("我是PersonDao，我执行了");
        }
    }
}
