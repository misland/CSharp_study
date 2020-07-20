using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domains
{
    public class Mate
    {
        public virtual int ID { get; set; }

        public virtual string Name { get; set; }

        public virtual Class Class { get; set; }
    }
}
