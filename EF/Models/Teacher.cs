using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EF.Models
{
    public class Teacher
    {
        [Key]
        public int TId { get; set; }

        //将字段设置为并发非时间戳字段，这个特性的作用是EF在进行数据更新时会每次检查Name属性
        //如果Name属性和上一次更新时的属性不同更新就会失败
        //这个不要求字段类型必须是byte数组类型的，同样的也可以在Dbcontext中用Fluent API来配置
        [ConcurrencyCheck]
        public virtual string Name { get; set; }

        public virtual string Bull { get; set; }
        public TeacherInfo Info { get; set; }
    }

    /// <summary>
    /// 这里使用了更复杂的数据类型，嵌套复杂类型，这时即使在两个类中不定义***Id的字段也无法自动建表了
    /// 这个时候就必须在TeacherInfo表上添加ComplexType特性了，Measurement不用添加该特性
    /// 同理，这个也可以用Fluent API来设置
    /// </summary>
    [ComplexType]
    public class TeacherInfo
    {
        public Measurement Weight { get; set; }
        public Measurement Height { get; set; }
        public string DietryRestrictions { get; set; }
    }

    public class Measurement
    {
        public decimal Reading { get; set; }
        public string Units { get; set; }
    }
}