using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lesson4CreateObject.IDao;

namespace Lesson4CreateObject.Dao
{
    public class DogDao : IDogDao
    {
        public void Bark()
        {
            Console.WriteLine("wang wang~~~");
        }

        public class Poodle
        {
            public void Run()
            {
                Console.WriteLine("small little legs");
            }
        }
    }
}
