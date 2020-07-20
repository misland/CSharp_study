using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lesson4CreateObject.IDao;

namespace Lesson4CreateObject.Dao
{
    public class PersonDao : IPersonDao
    {
        public void Print()
        {
            Console.WriteLine("I was executed");
        }
    }
}
