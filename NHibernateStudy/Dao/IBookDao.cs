using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domains;

namespace Dao
{
    public interface IBookDao
    {
        object Save(Book entity);

        void Update(Book entity);

        void Delete(Book entity);

        Book Get(BookId id);
    }
}
