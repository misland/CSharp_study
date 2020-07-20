using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EF.Models
{
    public class Course
    {
        [Key]
        public virtual int CId { get; set; }
        public virtual string Name { get; set; }
        public virtual int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}