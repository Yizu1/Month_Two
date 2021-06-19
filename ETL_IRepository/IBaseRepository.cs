using System;
using System.Collections.Generic;

namespace ETL_IRepository
{
    public interface IBaseRepository<T>
    {

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model">Model类型的别名</param>
        /// <returns></returns>
        int Insert(T model);


        /// <summary>
        /// 显示查询
        /// </summary>
        /// <typeparam name="T">Model类型</typeparam>
        /// <returns></returns>
        List<T> GetList();


        /// <summary>
        /// 删除、批删
        /// </summary>
        /// <param name="ids">主键Id</param>
        /// <returns></returns>
        int Delete(string ids);


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model">Model类型的别名</param>
        /// <returns></returns>
        int Update(T model);


        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
        T TheFill(string id);
    }
}
