using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using EF.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EF.Infrastruct
{
    public class EFDbContext : DbContext, IQueryableUnitOfWork
    {
        public EFDbContext() : base("EFDbContext")
        {
            this.Configuration.ProxyCreationEnabled = true;
            //为true时是贪婪加载，为false是延迟加载，实际情况如此- -
            this.Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Student> Student { get; set; }

        public DbSet<Course> Course { get; set; }

        public DbSet<Teacher> Teacher { get; set; }

        public DbSet<Test> Test { get; set; }

        public DbSet<Trip> Trip { get; set; }

        public DbSet<Activity> Activities { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //配置EF在自动生成表名时不以Class名的复数形式，名字什么样就用什么当表名
            //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //为Name属性设置出最大长度为16，自动生成表时会设置为nvarchar(16)
            modelBuilder.Entity<Student>().Property(s => s.Name).HasMaxLength(16);
            modelBuilder.Entity<Student>().HasMany(s => s.Courses).WithRequired(s => s.Student)
                .HasForeignKey(c => c.StudentId);

            //配置并发非时间戳字段
            //modelBuilder.Entity<Teacher>().Property(t => t.Name).IsConcurrencyToken();
            //默认情况下EF将所有字符串都映射到数据库中的Unicode字符串类型，
            //但是可以配置为不映射成Unicode类型，只能在Fluent API中配置，Data Annotations中没有对应的特性
            modelBuilder.Entity<Teacher>().Property(t => t.Bull).IsUnicode(false);

            //配置时间戳字段，注意只有byte数组类型的字段才能被配置成时间戳字段
            //modelBuilder.Entity<Test>().Property(t => t.RowVersion).IsRowVersion();
            //配置Decimal类型的字段的有效位数，第一个参数是小数点左边的，第二个参数是小数点右边的
            //这样对应的数据库字段类型是decimal(10,3)，同样这个也只能在这里配置，没有对应的特性可用
            modelBuilder.Entity<Test>().Property(t => t.Money).HasPrecision(10, 3);

            //modelBuilder.Entity<Course>().HasRequired(s => s.Student).WithMany(st => st.Courses).HasForeignKey(s => s.StudentId);
            //关闭Course的级联删除，上面设置Student和Course是相互Required的，
            //在删除Student时会默认级联删除Course，这样就关闭了，
            //但是这样删除后由于外键的存在，Course的数据就会出问题，设置时还是要慎重
            //经过测试，在EF6.0中这样配置后在删除数据时会报错，已不允许这样做了，在前面版本可能被允许
            //modelBuilder.Entity<Course>().HasRequired(s => s.Student).WithMany(s => s.Courses).WillCascadeOnDelete(false);
            //将一个类设置成复杂类型，不会为其建表
            //modelBuilder.ComplexType<Address>();

            //设置Guid类型的字段数据库自动算成
            //modelBuilder.Entity<Trip>().Property(t => t.TId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }

        public void Modify<T>(T entity) where T : class
        {
            base.Entry<T>(entity).State = EntityState.Modified;
        }

        public void Modify<T>(T origin, T target) where T : class
        {
            if (base.Entry<T>(origin).State != EntityState.Unchanged)
            {
                base.Entry<T>(origin).State = EntityState.Unchanged;
            }
            base.Entry<T>(origin).CurrentValues.SetValues(target);
        }

        public void Attach<T>(T entity) where T : class
        {
            base.Entry<T>(entity).State = EntityState.Unchanged;
        }

        public IEnumerable<T> ExecuteQuery<T>(string sqlQuery, params object[] parameters) where T : class
        {
            return Database.SqlQuery<T>(sqlQuery, parameters);
        }

        public int ExecuteCommand(string sqlCmd, params object[] parameters)
        {
            return Database.ExecuteSqlCommand(sqlCmd, parameters);
        }

        public IDbSet<T> GetSet<T>() where T : class
        {
            return base.Set<T>();
        }

        public void Commite()
        {
            base.SaveChanges();
        }

        public void RollBack()
        {
            base.ChangeTracker.Entries().ToList().ForEach(m => m.State = EntityState.Unchanged);
        }
    }
}