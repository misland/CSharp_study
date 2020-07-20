using Lesson5Scope.Dao;
using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5Scope
{
    class Program
    {
        private static string path= Directory.GetCurrentDirectory() + "\\object.xml";
        static void Main(string[] args)
        {
            IApplicationContext context = new XmlApplicationContext(new string[] { path });
            PersonDao person = context.GetObject("PersonDao") as PersonDao;
            PersonDao person2 = context.GetObject("PersonDao") as PersonDao;

            person.Print();

            Person p1 = context.GetObject("Person") as Person;
            Person p2 = context.GetObject("Person") as Person;
            Console.WriteLine("输入");
            Console.ReadKey();
            PersonServer p3 = context.GetObject("PersonServer") as PersonServer;


            Console.ReadKey();
        }
    }
}
