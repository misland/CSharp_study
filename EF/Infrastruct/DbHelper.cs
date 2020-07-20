using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EF.Infrastruct
{
    public class DbHelper:IQueryableUnitOfWork
    {
        public static EFDbContext context = new EFDbContext();        

        public void Modify<T>(T entity) where T : class
        {
            context.Entry<T>(entity).State = EntityState.Modified;
        }

        public void Modify<T>(T origin, T target) where T : class
        {
            if (context.Entry<T>(origin).State == EntityState.Unchanged)
            {
                context.Entry<T>(origin).State = EntityState.Unchanged;
            }
            context.Entry<T>(origin).CurrentValues.SetValues(target);
        }

        public void Attach<T>(T entity) where T : class
        {
            context.Entry<T>(entity).State = EntityState.Unchanged;
        }

        public IEnumerable<T> ExecuteQuery<T>(string sqlQuery, params object[] parameters) where T : class
        {
            return context.Database.SqlQuery<T>(sqlQuery, parameters);
        }

        public int ExecuteCommand(string sqlCmd, params object[] parameters)
        {
            return context.Database.ExecuteSqlCommand(sqlCmd, parameters);
        }

        public IDbSet<T> GetSet<T>() where T : class
        {
            return context.Set<T>();
        }

        public void Commite()
        {
            context.SaveChanges();
        }

        public void RollBack()
        {
            context.ChangeTracker.Entries().ToList().ForEach(x =>
            {
                x.State = EntityState.Unchanged;
            });
        }

        public void Dispose()
        {
            //
        }
    }
}