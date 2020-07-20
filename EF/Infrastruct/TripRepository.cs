using EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EF.Infrastruct
{
    public class TripRepository : Repository<Trip>,ITripRepository
    {
        public TripRepository(EFDbContext unitofwork) : base(unitofwork)
        {
        }
    }
}