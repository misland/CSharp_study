using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Infrastruct
{
    public interface IQueryableUnitOfWork:IUnitOfWork,IDisposable
    {

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        void Modify<T>(T entity) where T : class;

        /// <summary>
        /// 更新实体部分属性
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="origin"></param>
        /// <param name="target"></param>
        void Modify<T>(T origin, T target) where T : class;

        /// <summary>
        /// 设置实体状态为未改变
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        void Attach<T>(T entity) where T : class;

        /// <summary>
        /// 执行sql查询语句，返回枚举类型的数据集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IEnumerable<T> ExecuteQuery<T>(string sqlQuery, params object[] parameters) where T : class;

        /// <summary>
        /// 执行sql命令，返回执行结果
        /// </summary>
        /// <param name="sqlCmd"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        int ExecuteCommand(string sqlCmd, params object[] parameters);

        /// <summary>
        /// 获取一个实体的集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IDbSet<T> GetSet<T>() where T : class;

    }
}
