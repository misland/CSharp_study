using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlApp
{
    public class QueryModel
    {

        public QueryModel()
        {

            Mode = new List<Guid>();
            ExamRoom = new List<Guid>();
            VisitType = new List<Guid>();
            Device = new List<Guid>();
            ReportingDoctor = new List<Guid>();
            FilmingDoctor = new List<Guid>();
            VerifyingDoctor = new List<Guid>();
            CliniDoctor = new List<Guid>();
            RegistingDoctor = new List<Guid>();
            FeeType = new List<Guid>();
            StudyStatus = new List<int>();
            CliniDepartment = new List<Guid>();
            FeeItem = new List<Guid>();
            ItemType = new List<Guid>();
            Item = new List<Guid>();
        }
        public List<Guid> Mode { get; set; }

        public List<Guid> ExamRoom { get; set; }

        public List<Guid> VisitType { get; set; }

        public int TimeType { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public List<Guid> Device { get; set; }

        public List<Guid> ReportingDoctor { get; set; }

        public List<Guid> FilmingDoctor { get; set; }

        public List<Guid> VerifyingDoctor { get; set; }

        public List<Guid> CliniDoctor { get; set; }

        public List<Guid> RegistingDoctor { get; set; }

        public List<Guid> FeeType { get; set; }

        public List<int> StudyStatus { get; set; }

        public List<Guid> CliniDepartment { get; set; }

        public List<Guid> FeeItem { get; set; }


        public List<Guid> ItemType { get; set; }

        public List<Guid> Item { get; set; }


        /// <summary>
        /// 根据检查模式统计
        /// </summary>
        public bool GroupByMode { get; set; }
        /// <summary>
        /// 根据就诊类型统计
        /// </summary>
        public bool GroupByVisitType { get; set; }
        /// <summary>
        /// 根据检查地点统计
        /// </summary>
        public bool GroupByExamRoom { get; set; }
        /// <summary>
        /// 根据收费类型统计
        /// </summary>
        public bool GroupByFeeType { get; set; }
        /// <summary>
        /// 根据检查设备统计
        /// </summary>
        public bool GroupByDevice { get; set; }
        /// <summary>
        /// 根据申请科室统计
        /// </summary>
        public bool GroupByCliniDepartment { get; set; }
        /// <summary>
        /// 根据申请医生统计
        /// </summary>
        public bool GroupByCliniDoctor { get; set; }
        /// <summary>
        /// 根据登记医生统计
        /// </summary>
        public bool GroupByRegistingDoctor { get; set; }
        /// <summary>
        /// 根据摄片医生统计
        /// </summary>
        public bool GroupByFilmingDoctor { get; set; }
        /// <summary>
        /// 根据报告医生统计
        /// </summary>
        public bool GroupByReportingDoctor { get; set; }
        /// <summary>
        /// 根据审核医生统计
        /// </summary>
        public bool GroupByVerifyingDoctor { get; set; }

        /// <summary>
        /// 根据检查项目明细统计
        /// </summary>
        public bool GroupByItem { get; set; }

        /// <summary>
        /// 根据检查项目大类统计
        /// </summary>
        public bool GroupByItemType { get; set; }

        /// <summary>
        /// 根据费用项目统计
        /// </summary>
        public bool GroupByFeeItem { get; set; }

        /// <summary>
        /// 根据阴性阳性
        /// </summary>
        public bool GroupByQulatitive { get; set; }
    }
}
