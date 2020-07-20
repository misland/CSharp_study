using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4CreateObject.Infrastruct
{
    public class GenericClass<T>
    {
        public void Run()
        {
            Console.WriteLine(typeof(T).ToString());
        }
    }
}
