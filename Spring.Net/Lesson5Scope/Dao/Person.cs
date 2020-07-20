using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5Scope.Dao
{
    public class Person
    {
        public Person()
        {
            Console.WriteLine("我是Person，实例化");
        }

        ~Person()
        {
            Console.WriteLine("被销毁");
        }
    }
}
