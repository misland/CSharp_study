using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace EF.Models
{
    public class Student
    {
        [Key]
        public virtual int SId { get; set; }

        public virtual string Name { get; set; }

        public virtual IList<Course> Courses { get; set; }
    }
}