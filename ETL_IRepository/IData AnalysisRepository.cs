using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL_IRepository
{
    public interface IData_AnalysisRepository
    {
        /// <summary>
        /// 根据数据库名称获取其中表数据MySql
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="name">数据库名称</param>
        /// <returns></returns>
        string GetDataTable(string sql, string name);
        /// <summary>
        /// 根据数据库名称获取其中表数据SqlServer
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="name">数据库名称</param>
        /// <returns></returns>
        string GetDataTableSql(string sql, string name);

        /// <summary>
        /// 根据数据库名获取表名 MySQL
        /// </summary>
        /// <param name="databasename">数据库名称</param>
        /// <returns></returns>
        List<ETL_Model.GetTables> GetTableName(string databasename, int flag);

        /// <summary>
        /// 获取数据库名 
        /// </summary>
        /// <returns></returns>
        List<ETL_Model.GetDataBases> GetDatabaseName(int flag);

        /// <summary>
        /// SQL语句耗时
        /// </summary>
        /// <returns></returns>
        object GetSelTime();
    }
}
