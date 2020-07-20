using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domains
{
    public class Family
    {
        public virtual int Id { get; set; }

        public virtual string Address { get; set; }

        public virtual Student Stu { get; set; }
    }
}
