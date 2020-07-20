using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Infrastruct
{
    public interface IRepository<T> :IDisposable where T:class
    {
        IUnitOfWork UnitOfWork { get; }

        void Add(T entity);

        void Modify(T entity);

        void Modify(T origin, T target);

        void Remove(T entity);

        void Attach(T entity);

        IEnumerable<T> GetAll();

        T GetById<TId>(TId id);


    }
}
