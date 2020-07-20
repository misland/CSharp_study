using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domains;
using NHibernate;

namespace Dao
{
    public class StudentDao:IStudentDao
    {
        private ISessionFactory factory;
        public StudentDao(ISessionFactory factory)
        {
            this.factory = factory;
        }
        public Student Get(int id)
        {
            ISession session = factory.OpenSession();
            return session.Get<Student>(id);
        }


        public void Delete(Student entity)
        {
            ISession session = factory.OpenSession();
            session.Delete(entity);
            session.Flush();
        }
    }
}
