using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using System.Reflection;
using NHibernate;
using NHibernate.SqlCommand;

namespace NHibernateApp
{
    class Program
    {

        private static ISessionFactory SessionFactory;

        static void Main(string[] args)
        {
            //HibernatingRhinos.Profiler.Appender.NHibernate.NHibernateProfiler.Initialize();
            var cfg = new Configuration();
            
            //通过配置文件配置属性，二者选一，均可行，注意配置文件属性要设置为嵌入的资源+总是复制
            //当然代码也能弥补xml，如下配置显示sql，等于xml中的show_sql
            //cfg.DataBaseIntegration(x =>
            //{
            //    x.LogSqlInConsole = true;
            //});
            cfg.Configure();

            //通过代码设置NHibernate的必须属性：连接字条串、驱动、方言
            //cfg.DataBaseIntegration(x =>
            //{
            //    x.ConnectionString = "server=risserver;database=SpringNet18;uid=sa;pwd=fris;";
            //    x.Driver<SqlClientDriver>();
            //    x.Dialect<MsSql2008Dialect>();
            //});
            //cfg.AddAssembly(Assembly.GetExecutingAssembly());


            SessionFactory = cfg.BuildSessionFactory();

            //插入数据
            //var customer = new Customer()
            //{
            //    FirstName = "san",
            //    LastName = "zhang",
            //    Points = 100,
            //    CreditRating = CustomerCreditRating.Terrible,
            //    MemberSince = DateTime.Now.AddYears(-5)
            //};
            //int id = Insert(customer);
            //Console.WriteLine(id);

            #region 一级缓存
            //一级缓存，即session从数据库中取出数据成为持久化对象，放在session持久化对象缓存池中，
            //之后若再访问同一个实体，session就人缓存池中读取而不再从数据库中再次查询
            //但是前提是属于同一个session，否则依然会再次从数据库中读取
            //一个持久化对象有一个单独的session，互不影响
            //using (var session=SessionFactory.OpenSession())
            //{
            //    var c1 = session.Get<Customer>(5);
            //    var c2 = session.Get<Customer>(5);
            //    Console.WriteLine(c1.FirstName + " " + c1.LastName);
            //    Console.WriteLine(c2.FirstName + " " + c2.LastName); 
            //}

            //测试更新对一级缓存的影响
            //发现更新后第二次查询也没有生成新的sql，说明更新对一级缓存没有影响，下次依然从缓存中获取
            //这样的话说明更新后连带着将一级缓存也更新了
            //using (var session = SessionFactory.OpenSession(new LogSql()))
            //{
            //    var c1 = session.Get<Customer>(5);
            //    c1.FirstName = "what";
            //    session.SaveOrUpdate(c1);
            //    session.Flush();
            //    var c2 = session.Get<Customer>(5);
            //    Console.WriteLine(c1.FirstName + " " + c1.LastName);
            //    Console.WriteLine(c2.FirstName + " " + c2.LastName);
            //}

            //可以将缓存清空，清空后再次查询同一条数据就会再次从数据库中读取
            //using (var session = SessionFactory.OpenSession())
            //{
            //    var c1 = session.Get<Customer>(5);
            //    session.Clear();
            //    var c2 = session.Get<Customer>(5);
            //    Console.WriteLine(c1.FirstName + " " + c1.LastName);
            //    Console.WriteLine(c2.FirstName + " " + c2.LastName);
            //}

            //也可以用Evict方法将对象从session中删除，这样和上面一样，再次查询同一条数据时从数据库中读取
            //可以用Contains方法查询缓存池中是否有对象的缓存
            //using (var session = SessionFactory.OpenSession())
            //{
            //    var c1 = session.Get<Customer>(5);
            //    session.Evict(c1);
            //    Console.WriteLine(session.Contains(c1));
            //    var c2 = session.Get<Customer>(5);
            //    Console.WriteLine(c1.FirstName + " " + c1.LastName);
            //    Console.WriteLine(c2.FirstName + " " + c2.LastName);
            //}

            #endregion

            #region 二级缓存
            //每次查询完会释放session资源，但是这里虽然查询了两次却生成并执行了一次sql，这就是二级缓存，对所有的session共享
            //只要有就会从缓存中读取
            //var fc1 = GetById(5);
            //var fc2 = GetById(5);
            //Console.WriteLine(fc1.FirstName + " " + fc1.LastName);
            //Console.WriteLine(fc2.FirstName + " " + fc2.LastName);

            //如果数据更新了二级缓存如何处理？
            //根据测试发现当usage设置为read-only时会报错，因为更新后要更新二级缓存而又设置为了只读程序执行不下去只好抛出异常
            //若设置为read-write，则会更新二级缓存，第二次查询时会重新生成sql并查询出最新的数据
            //若设置为nonstrict-read-write则实体更新后不会更新二级缓存，这样就会导致缓存中的数据与数据库中不一致
            //而transactional级别的缓存看源代码在4.0版本中被注释掉了，原因未知
            //var fcp1 = GetById(5);
            //Console.WriteLine(fcp1.FirstName + " " + fcp1.LastName);
            //fcp1.FirstName = "land";
            //Update(fcp1);
            //var fcp2 = GetById(5);
            //Console.WriteLine(fcp1.FirstName + " " + fcp1.LastName);
            //Console.WriteLine(fcp2.FirstName + " " + fcp2.LastName);

            //var tem = GetById(5);
            //tem.LastName = "luo";
            //Update(tem);

            #endregion

            #region 自定义查询开启二级缓存
            //通过代码开启自定义查询的二级缓存，要结合配置文件一起使用
            //using (var session = SessionFactory.OpenSession())
            //{
            //    IList<Customer> customers = session.CreateQuery(" from Customer where id>2")
            //        .SetCacheable(true)     //这个就是开启缓存的
            //        .SetCacheRegion("customer_cache")//这个是指定缓存存放的地方，相当于为缓存取了一个名字
            //        .List<Customer>();
            //    foreach (var item in customers)
            //    {
            //        Console.WriteLine(item.FirstName + "~" + item.LastName);
            //    }
            //}
            //EvictQueries方法名起的有歧义，是删除指定Region的缓存而不是根据查询名字
            //这里添加这行代码会把指定Region的缓存删除，第二次查询时就会重新从数据库中查询，因为没有缓存了
            SessionFactory.EvictQueries("customer_cache");

            //using (var session = SessionFactory.OpenSession())
            //{
            //    IList<Customer> customers = session.CreateQuery(" from Customer where id>2")
            //        .SetCacheable(true)
            //        //取了名字后第二次也要指定名字，否则就会从重新数据库中查询
            //        .SetCacheRegion("customer_cache")
            //        //这个是设置缓存机制的，Refresh表示每次查询都刷新缓存，所以这次查询不会用缓存而是重新从数据库中查询
            //        //五种模式和Customer.hbm.xml中的query节点中的cache-mode一样
            //        //.SetCacheMode(CacheMode.Refresh)
            //        .List<Customer>();
            //    foreach (var item in customers)
            //    {
            //        Console.WriteLine(item.FirstName + "~" + item.LastName);
            //    }
            //}

            //通过实体配置文件中自定义的查询进行查询，配置见Customer.hbm.xml文件的query节点
            //但是这种方式当SessionFactory只用于这一个查询时可以正常使用缓存
            //而如果在执行这个查询前SessionFactory还用于其它用途了，比如插入数据
            //那缓存就不起作用了，如果是在这个查询之后再插入数据，那缓存能正常使用！
            //为什么？？？答案还未找到
            //using (var session = SessionFactory.OpenSession())
            //{
            //    IList<Customer> customers = session.GetNamedQuery("select_customer")
            //        .List<Customer>();
            //    foreach (var item in customers)
            //    {
            //        Console.WriteLine(item.LastName + " " + item.FirstName);
            //    }
            //}

            ////这行代码并不起作用，说明这个方法确实只是针对Region而言的
            //SessionFactory.EvictQueries("select_customer");

            //using (var session = SessionFactory.OpenSession())
            //{
            //    IList<Customer> customers = session.GetNamedQuery("select_customer")
            //        .List<Customer>();
            //    foreach (var item in customers)
            //    {
            //        Console.WriteLine(item.LastName + " " + item.FirstName);
            //    }
            //}

            //执行完上面的查询后再插入数据，上面的查询二级缓存能正常使用
            //var customer = new Customer()
            //{
            //    FirstName = "si",
            //    LastName = "li",
            //    Points = 100,
            //    CreditRating = CustomerCreditRating.Terrible,
            //    MemberSince = DateTime.Now.AddYears(-5)
            //};
            //int id = Insert(customer);
            //Console.WriteLine(id);

            #endregion

            #region 二级缓存管理

            //using (var session = SessionFactory.OpenSession())
            //{
            //    var customer = session.Get<Customer>(6);
            //}

            ////将Customer类型的缓存从二级缓存中删除，这样第二次查询时依然会重新从数据库中查询
            //SessionFactory.Evict(typeof(Customer));

            //using (var session = SessionFactory.OpenSession())
            //{
            //    var customer = session.Get<Customer>(6);
            //}


            #endregion

            #region 乐观锁
            //乐观锁更新控制
            //using (var session = SessionFactory.OpenSession())
            //{
            //    var one = session.Get<Customer>(1);
            //    var two = session.Get<Customer>(1);
            //    one.FirstName = "an";
            //    session.Update(one);
            //    session.Flush();
            //    //加了乐观锁之后，只有最后一次数据提交会被执行，之前的提交会被自动回滚
            //    two.FirstName = "ming";
            //    session.Update(two);
            //    session.Flush();
            //}

            //乐观锁删除
            using (var session = SessionFactory.OpenSession())
            {
                var one = session.Get<Customer>(1);
                var two = session.Get<Customer>(2);
                session.Delete(one);
                session.Flush();
                //同一个实体，第一次删除完毕flush后就已经从数据库删除了，第二次删除时找不到就会报错，执行不下去了
                session.Delete(two);
                session.Flush();
            }


                #endregion


                Console.WriteLine("completed");
            Console.ReadKey();
        }

        static IList<Customer> GetAll()
        {
            using (var session = SessionFactory.OpenSession())
            {
                IList<Customer> list = session.CreateCriteria<Customer>().List<Customer>();
                return list;
            }
        }

        static Customer GetById(int id)
        {
            using (var session = SessionFactory.OpenSession())
            {
                var result = session.Get<Customer>(id);
                return result;
            }
        }

        static int Insert(Customer entity)
        {
            using (var session = SessionFactory.OpenSession())
            {
                var id = session.Save(entity);
                session.Flush();
                return Convert.ToInt32(id);
            }
        }

        static void Update(Customer entity)
        {
            using (var session = SessionFactory.OpenSession(new LogSql()))
            {
                session.SaveOrUpdate(entity);
                session.Flush();
            }
        }

        static void Delete(int id)
        {
            using (var session = SessionFactory.OpenSession())
            {
                session.Delete(session.Get<Customer>(id));
                session.Flush();
            }
        }
    }

    public class LogSql : EmptyInterceptor
    {
        public override SqlString OnPrepareStatement(SqlString sql)
        {
            Console.WriteLine("the sql is:    " + sql);
            return base.OnPrepareStatement(sql);
        }
    }
}
