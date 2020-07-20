using App.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            MailManager mm = new MailManager();
            Fax fax = new Fax(mm);
            mm.SimulateNewMail("zgh","zjj","Isn't zjj is a pig?");
            Console.ReadKey();
        }
    }
}
