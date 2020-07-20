using Lesson3SimpleIOCFramework.IDao;
using Lesson3SimpleIOCFramework.Infrastruct;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson3SimpleIOCFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string dyPath = Directory.GetCurrentDirectory();
            ObjectFactory ob = new ObjectFactory(path + "\\Objects.xml");
            IPersonDao PersonDao = ob.GetObject("PersonDao") as IPersonDao;
            if (PersonDao != null)
                PersonDao.Print();
            Console.ReadKey();
        }
    }
}
