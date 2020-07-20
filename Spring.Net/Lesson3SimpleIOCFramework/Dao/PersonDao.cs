using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lesson3SimpleIOCFramework.IDao;

namespace Lesson3SimpleIOCFramework.Dao
{
    public class PersonDao : IPersonDao
    {
        public void Print()
        {
            Console.WriteLine("I was executed");
        }
    }
}
