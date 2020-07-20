using EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EF.Infrastruct
{
    public class ActivityRepository : Repository<Activity>, IActivityRepository
    {
        public ActivityRepository(EFDbContext unitofwork) : base(unitofwork)
        {
        }
    }
}