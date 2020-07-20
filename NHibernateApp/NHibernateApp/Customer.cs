using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NHibernateApp
{
    public class Customer
    {
        public virtual int Id { get; set; }

        public virtual string FirstName { get; set; }

        public virtual string LastName { get; set; }

        public virtual double AverageRating { get; set; }

        public virtual int Points { get; set; }

        public virtual bool HasGoldStatus { get; set; }

        public virtual DateTime MemberSince { get; set; }

        public virtual CustomerCreditRating CreditRating{get;set;}

        public virtual string Street { get; set; }

        public virtual string City { get; set; }

        public virtual string Province { get; set; }

        public virtual string Country { get; set; }

        public virtual int VersionID { get; set; }
    }

    public enum CustomerCreditRating
    {
        Excellent,
        VeryGood,
        Good,
        Netural,
        Poor,
        Terrible
    }
}
