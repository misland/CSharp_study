using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domains
{
    public class Student
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }

        public virtual Family Fam { get; set; }
    }
}
