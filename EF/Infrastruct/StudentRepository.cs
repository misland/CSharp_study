using EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EF.Infrastruct
{
    public class StudentRepository : Repository<Student>, IStudentRepository
    {
        public StudentRepository(EFDbContext unitofwork) : base(unitofwork)
        {

        }
    }
}