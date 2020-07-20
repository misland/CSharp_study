using Lesson6DI.Infrastruct;
using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6DI
{
    class Program
    {
        static void Main(string[] args)
        {
            IApplicationContext context = ContextRegistry.GetContext();
            ModenPerson person = context.GetObject("ModenPerson") as ModenPerson;
            person.Work();
            Console.ReadKey();
        }
    }
}
