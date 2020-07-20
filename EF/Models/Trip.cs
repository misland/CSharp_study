using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models
{
    public class Trip
    {
        [Key]
        //这个特性用来设置数据库自动生成Guid，如果不设置这个数据库不会调用newid方法生成的
        //同样在Fluent API中也可以设置
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual Guid TId { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual decimal CostUSD { get; set; }
        public virtual List<Activity> Activities { get; set; }
    }
}