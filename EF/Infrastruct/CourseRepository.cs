using EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EF.Infrastruct
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(EFDbContext unitofwork) : base(unitofwork)
        {
        }
    }
}