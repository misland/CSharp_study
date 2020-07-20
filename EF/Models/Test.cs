using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models
{
    public class Test
    {
        [Key]
        public virtual int PId { get; set; }
        public virtual string jing { get; set; }
        //Timestamp 是配置时间戳的特性，用于开放式并发环境，类似NHibernate中的乐观锁VersionId，
        //加了这个特性后EF在更新或删除数据库数据时使用这些字段进行并发检查
        //也可以在Dbcontext类中用Fluent API设置
        //只有byte数组类型才能配置成为时间戳字段
        [Timestamp]
        public virtual byte[] RowVersion { get; set; }
        public virtual decimal Money { get; set; }
        public Address Address { get; set; }
    }

    /// <summary>
    /// 这里Address类用作复杂类型，用于Test中的一个属性，要让一个类当作复杂类型来使用要满足两个条件：
    /// 1、类不能有主键，如AddressId后面带Id的字段，只能包含原始属性
    /// 2、在使用复杂类型的类在不能对复杂类型的集合类型，如List，必须是一个单一的实例
    /// 用作复杂类型后EF会在建表时将Address中的属性生成相应的字段放到Test表中
    /// 这样的好处是使Test看起来比较简单整洁
    /// 当然如果定义了***Id类型的字段又想让类作为复杂类型也可以，可以用ComplexType特性，
    /// 这样强制将一个类设置成了复杂类型,也可以用Fluent API设置
    /// </summary>
    /// 注意这个特性在System.ComponentModel.DataAnnotations.Schema命名空间下
    [ComplexType]
    public class Address
    {
        public string District { get; set; }
        public string StreetNo { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
    }
}