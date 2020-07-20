using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using Dao;
using Domains;
using Common.Logging;


namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ILog logger = LogManager.GetLogger(typeof(Program));
            var cfg = new NHibernate.Cfg.Configuration().Configure();
            using (ISessionFactory sessionFactory = cfg.BuildSessionFactory())
            {
                #region Product
                //IProductDao productDao = new ProductDao(sessionFactory);
                Product p = new Product()
                {
                    Id = Guid.NewGuid(),
                    Name = "computer",
                    BuyPrice = 1000,
                    SellPrice = 1000,
                    Code = "com",
                    QuantityPerUnit = "ton",
                    Unit = "abc"
                };
                //add
                //productDao.Save(p);
                //logger.Info("save completed");

                //search
                //var entity = productDao.Get(new Guid("CADC1F01-E4AB-4B71-8E1D-3F925B4A3FA9"));
                //entity.Name = "laptop";//不会同步到数据库
                //Console.WriteLine(entity.Name);
                //logger.Info("get completed");

                //update
                //var entityU = productDao.LoadAll().FirstOrDefault<Product>();
                //entityU.BuyPrice = 800;
                //productDao.Update(entityU);
                //logger.Info("update completed");

                //delete
                //var entity = productDao.LoadAll().FirstOrDefault<Product>();
                //productDao.Delete(entity);

                //load
                //var entitys = productDao.Load(new Guid("EE2313FB-5866-46C7-AEE0-1FFB329219A8"));
                //Console.WriteLine(entitys.QuantityPerUnit);
                //logger.Info("load complete");

                //loadall
                //var entitylist = productDao.LoadAll();
                //foreach (var item in entitylist)
                //{
                //    Console.WriteLine(item.Name);
                //}
                //logger.Info("loadall complete");

                #endregion

                #region Book composite-id
                IBookDao bookDao = new BookDao(sessionFactory);
                //save
                //Book model = new Book();
                //model.Price = 50;
                //model.Id = new BookId() { Name = "asp.net", Author = "tian ping" };
                //bookDao.Save(model);

                //get
                //BookId id = new BookId() { Name = "learning wcf", Author = "unknown" };
                //var entity= bookDao.Get(id);
                //Console.WriteLine(entity.Id.Name + "-" + entity.Id.Author);


                #endregion

                #region 一对一
                
                //IFamilyDao dao = new FamilyDao(sessionFactory);
                //IStudentDao sdao = new StudentDao(sessionFactory);
                //save
                //Student s = new Student() { Name = "zjj" };
                //Family f = new Family() { Address = "kai feng", Stu = s };
                //dao.Save(f);
                

                //get
                //Family fg = dao.Get(5);
                //Console.WriteLine(fg.Address);
                //Console.WriteLine(fg.Stu.Name);

                //Student st = sdao.Get(6);
                //Console.WriteLine(st.Name);
                //Console.WriteLine(st.Fam.Address);

                //delete
                //Family fd = dao.Get(8);
                //dao.Delete(fd);

                //sdao.Delete(st);

                #endregion

                #region 多对一
                IClassDao cd = new ClassDao(sessionFactory);
                //IMateDao md = new MateDao(sessionFactory);
                Mate mone = new Mate() { Name = "zjj" };
                Mate mtwo = new Mate() { Name = "zgh" };
                Class cls = new Class() { Name = "0404" };
                mone.Class = cls;//这样的话下面md.save无法保存，因为cls类还没有save没有持久化，不能使用
                mtwo.Class = cls;//当然这样的话class也无法保存，因为同样的mone和mtwo没有持久化，也不能使用
                cls.Mates.Add(mone);
                cls.Mates.Add(mtwo);
                //md.Save(mone);
                //md.Save(mtwo);
                //cd.Save(cls);//上面两行不注释这里就不能执行，执行这两行是没有设置inverse，设置了就不用了

                //删除
                //Class cdel = cd.Get(13);
                //cd.Delete(cdel);


                #endregion

                #region many to many
                IUsersDao ud = new UsersDao(sessionFactory);
                IRolesDao rd = new RolesDao(sessionFactory);
                Roles rone = new Roles() { Name = "admin" };
                Roles rtwo = new Roles() { Name = "guest" };
                Users uone = new Users() { Name = "zjj", UserRoles = new List<Roles>() { rone, rtwo } };
                Users utwo = new Users() { Name = "zgh", UserRoles = new List<Roles>() { rone, rtwo } };

                //save bag中没有设置cascade时只能分别保存
                //rd.Save(rone);
                //rd.Save(rtwo);
                //ud.Save(uone);
                //ud.Save(utwo);

                //cascade设置后只需要执行这一行即可，会自动分析关系分别生成sql
                //但是inverse=1后反而不能往关系表中插入数据，因为关系表没有在NHibernate中映射，inverse后将控制权交给了关系表，但是又不知道关系表
                //什么样子了，所以NHibernate不会处理
                //ud.Save(utwo);

                //update
                Users up = ud.Get(9);
                up.UserRoles.Clear();
                up.UserRoles.Add(new Roles() { Name = "host" });
                ud.Save(up);
                #endregion

                Console.WriteLine("executed");
                Console.ReadKey();
            }
        }
    }
}
