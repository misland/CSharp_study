using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Event
{
    internal class MailManager
    {
        public event EventHandler<NewMailEventArgs> NewMail;
        public virtual void OnNewMail(NewMailEventArgs e)
        {
            //这种写法虽然检查了是否为null，但如果在调用NewMail之前，另一个线程可能从委托链中移除一个委托，这样还是成了null
            //所以可以用Volatile.Read方法强迫在调用时读取NewMail
            //if (NewMail != null)
            //    NewMail(this, e);

            //可以这样写
            //EventHandler<NewMailEventArgs> tem = Volatile.Read(ref NewMail);
            //if (tem != null)
            //    tem(this, e);

            //也可以这样写，提高代码复用率
            e.Raise(this, ref NewMail);
        }

        public void SimulateNewMail(string from,string to,string subject)
        {
            NewMailEventArgs e = new NewMailEventArgs(from, to, subject);
            OnNewMail(e);
        }
    }

    //定义一个扩展方法专门用于调用委托时使用，可重用
    public static class EventArgsExtensions
    {
        public static void Raise<TEventArgs>(this TEventArgs e,object sender,ref EventHandler<TEventArgs> eventDelegate)
        {
            EventHandler<TEventArgs> tem = Volatile.Read(ref eventDelegate);
            if (tem != null)
                tem(sender, e);
        }
    }
}
