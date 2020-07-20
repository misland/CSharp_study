using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Infrastruct
{
    public interface IUnitOfWork
    {
        void Commite();

        void RollBack();
    }
}
