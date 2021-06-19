using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL_Common
{
   public  class ServerDapperHerper
    {
        #region

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public T Scalar<T>(string sql)
        {
            using (IDbConnection sc = new SqlConnection(ConfigurationManager.serverconn))
            {
                try
                {
                    var result = sc.QueryFirst<T>(sql);
                    return result;

                }
                catch (System.Exception ex)
                {
                    string nn = ex.Message;
                    return default(T);
                    throw;
                }
            }
        }

        /// <summary>
        /// 反填
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public T Fant<T>(string sql)
        {
            using (IDbConnection sc = new SqlConnection(ConfigurationManager.serverconn))
            {
                try
                {
                    var result = sc.QueryFirst<T>(sql);
                    return result;

                }
                catch (System.Exception ex)
                {
                    string nn = ex.Message;
                    return default(T);
                    throw;
                }
            }
        }

        /// <summary>
        /// 增删改
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int CUD(string sql)
        {
            using (IDbConnection sc = new SqlConnection(ConfigurationManager.serverconn))
            {
                try
                {
                    sc.Open();
                    return sc.Execute(sql);
                }
                catch (System.Exception ex)
                {
                    string nn = ex.Message;
                    return -1;
                    throw;
                }
            }
        }
        /// <summary>
        /// 新增，修改等
        /// </summary>
        /// <param name="Sql"></param>
        /// <returns></returns>
        public int CUD<T>(string sql, T I)
        {
            using (IDbConnection sc = new SqlConnection(ConfigurationManager.serverconn))
            {
                sc.Open();
                try
                {
                    return sc.Execute(sql, I);
                }
                catch (System.Exception ex)
                {
                    string nn = ex.Message;
                    return 0;
                    throw;
                }
            }
        }
        /// <summary>
        /// 显示
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>

        public List<T> GetList<T>(string sql)
        {
            using (IDbConnection sc = new SqlConnection(ConfigurationManager.serverconn))
            {
                try
                {
                    var result = sc.Query<T>(sql).ToList();
                    return result;
                }
                catch (System.Exception ex)
                {
                    string nn = ex.Message;
                    return null;
                    throw;
                }
            }
        }

        #endregion
    }
}
