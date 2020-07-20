using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Event
{
    class NewMailEventArgs:EventArgs
    {
        private string m_from, m_to, m_subject;
        public NewMailEventArgs(string from ,string to,string subject)
        {
            this.m_from = from;
            this.m_to = to;
            this.m_subject = subject;
        }
        public string From { get { return m_from; } }
        public string To { get { return m_to; } }
        public string Subject { get { return m_subject; } }
    }
}
