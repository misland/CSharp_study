using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6DI.Infrastruct
{
    public class ModenPerson : Person
    {
        private ITool tool { get; set; }
        public override void Work()
        {
            tool.UseTool();
        }
    }
}
