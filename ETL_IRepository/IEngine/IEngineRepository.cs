using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL_IRepository.IEngine
{
    public interface IEngineRepository<T>
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="model">Model类型的别名</param>
        /// <returns></returns>
       Task< int> Insert(T model);

        /// <summary>
        /// 显示查询
        /// </summary>
        /// <typeparam name="T">Model类型</typeparam>
        /// <returns></returns>
        Task<  List<T> >GetList();

        
        /// <summary>
        /// 删除、批删
        /// </summary>
        /// <param name="ids">主键Id</param>
        /// <returns></returns>
        Task<  int> Delete(string ids);


        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model">Model类型的别名</param>
        /// <returns></returns>
      Task<  int> Update(T model);


        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="id">主键Id</param>
        /// <returns></returns>
       Task< T> TheFill(string id);
    }
}
