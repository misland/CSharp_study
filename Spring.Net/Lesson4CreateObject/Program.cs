using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Spring.Context;
using Spring.Context.Support;
using Spring.Objects.Factory;
using Lesson4CreateObject.IDao;
using Lesson4CreateObject.Factory;
using Lesson4CreateObject.Dao;
using Lesson4CreateObject.Infrastruct;

namespace Lesson4CreateObject
{
    class Program
    {
        private static string path = Directory.GetCurrentDirectory() + "\\object.xml";
        static void Main(string[] args)
        {
            CreateByConstructor();
            CreateNested();
            CreateByStaticFactory();
            CreateByInstanceFactory();
            CreateGenericClass();
            Console.ReadKey();
        }

        /// <summary>
        /// 该方法通过类的构造方法创建类的实例，这样需要类具有默认的不带参数的构造方法
        /// </summary>
        static void CreateByConstructor()
        {
            IApplicationContext context = new XmlApplicationContext(new string[] { path});
            IObjectFactory factory = (IObjectFactory)context;
            //应该是Spring自动根据id寻找节点并创建对象
            IPersonDao personDao = factory.GetObject("PersonDao") as IPersonDao;
            if (personDao != null)
                personDao.Print();
            Console.WriteLine("constructor method complete");
        }

        /// <summary>
        /// 创建嵌套类型，Poodle是DogDao的嵌套类型，在xml中定义时要用“+”来表示嵌套，具体持xml文件
        /// </summary>
        static void CreateNested()
        {
            IApplicationContext context = new XmlApplicationContext(new string[] { path });
            IObjectFactory factory = (IObjectFactory)context;
            IDogDao DogDao = factory.GetObject("DogDao") as IDogDao;
            if (DogDao != null)
                DogDao.Bark();
            Dao.DogDao.Poodle p = factory.GetObject("Poodle") as Dao.DogDao.Poodle;
            if (p != null)
                p.Run();
            Console.WriteLine("CreateNested method complete");
        }

        /// <summary>
        /// 静态工厂类创建对象，通过定义factory-method方法声明工厂方法，这种方式的前提是工厂类是static
        /// </summary>
        static void CreateByStaticFactory()
        {
            IApplicationContext context = new XmlApplicationContext(new string[] { path });
            IObjectFactory factory = (IObjectFactory)context;
            PersonDao person = factory.GetObject("staticObjectFactory") as PersonDao;
            if (person != null)
                person.Print();
            Console.WriteLine("CreateByStaticFactory method complete");
        }

        /// <summary>
        /// 实例工厂方法，这种方式先创建工厂实例，通过factory-object来设置工厂对象，spring根据这个值创建
        /// 工厂类实例并调用工厂方法创建对象
        /// </summary>
        static void CreateByInstanceFactory()
        {
            IApplicationContext context = new XmlApplicationContext(new string[] { path });
            PersonDao person = ((IObjectFactory)context).GetObject("instancePerson") as PersonDao;
            if (person != null)
                person.Print();
            Console.WriteLine("CreateByInstanceFactory method complete");
        }

        /// <summary>
        /// 创建泛型类，跟普通类的区别是要在xml文件中声明泛型类型
        /// </summary>
        static void CreateGenericClass()
        {
            IApplicationContext context = new XmlApplicationContext(new string[] { path });
            GenericClass<int> generic = ((IObjectFactory)context).GetObject("geneericClass") as GenericClass<int>;
            if (generic != null)
            {
                generic.Run();
            }
            Console.WriteLine("CreateGenericClass method complete");
        }

    }
}
