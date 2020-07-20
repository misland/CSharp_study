using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6DI.Infrastruct
{
    public class Computer:ITool
    {
        public void UseTool()
        {
            Console.WriteLine("用电脑撸代码");
        }
    }
}
