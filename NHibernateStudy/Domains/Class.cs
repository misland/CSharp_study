using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domains
{
    public class Class
    {
        public Class()
        {
            Mates = new List<Mate>();
        }
        public virtual int ID { get; set; }

        public virtual string Name { get; set; }

        public virtual IList<Mate> Mates { get; set; }
    }
}
