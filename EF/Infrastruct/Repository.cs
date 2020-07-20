using EF.Infrastruct;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EF.Infrastruct
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private IQueryableUnitOfWork unitofwork;

        public Repository(IQueryableUnitOfWork unitofwork)
        {
            this.unitofwork = unitofwork;
        }

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return this.unitofwork;
            }
        }

        public void Add(T entity)
        {
            GetSet().Add(entity);
            unitofwork.Commite();
        }

        public void Attach(T entity)
        {
            unitofwork.Attach<T>(entity);
        }

        public void Dispose()
        {
            if (unitofwork != null)
            {
                unitofwork = null;
            }
        }

        public IEnumerable<T> GetAll()
        {
            return GetSet();
        }

        public T GetById<TId>(TId id)
        {
            return GetSet().Find(id);
        }

        public void Modify(T entity)
        {
            unitofwork.Modify<T>(entity);
            unitofwork.Commite();
        }

        public void Modify(T origin, T target)
        {
            unitofwork.Modify<T>(origin, target);
            unitofwork.Commite();
        }

        public void Remove(T entity)
        {
            unitofwork.Attach<T>(entity);
            GetSet().Remove(entity);
            unitofwork.Commite();
        }

        private IDbSet<T> GetSet()
        {
            return unitofwork.GetSet<T>();
        }
    }
}