using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domains
{
    public class Book
    {
        public virtual BookId Id { get; set; }

        public virtual string Name { get; set; }

        public virtual string Author { get; set; }

        public virtual int Price { get; set; }
    }

    public class BookId
    {
        public virtual string Name { get; set; }

        public virtual string Author { get; set; }

        public override bool Equals(object obj)
        {
            var entity = obj as BookId;
            if (entity == null)
                return false;
            return entity.Name == this.Name && entity.Author == this.Author;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
