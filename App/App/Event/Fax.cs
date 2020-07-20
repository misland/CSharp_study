using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Event
{
    sealed class Fax
    {
        public Fax(MailManager mm)
        {
            mm.NewMail += FaxMsg;
        }

        private void FaxMsg(object sender,NewMailEventArgs e)
        {
            var test = sender as MailManager;
            if (test != null)
            {
                Console.WriteLine("确实是MailManager类");
            }
            Console.WriteLine("Fax mail message");
            Console.WriteLine("From={0},To={1},Subject={2}", e.From, e.To, e.Subject);
        }

        private void Unregister(MailManager mm)
        {
            mm.NewMail -= FaxMsg;
        }
    }
}
