using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL_IRepository.IEngine
{
    public interface IEngineRizhiRepository<T>
    {
        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="model">Model类型的别名</param>
        /// <returns></returns>
        Task<int> Rizhi(T model);
    }
}
