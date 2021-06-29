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
        public async Task< T> Fant<T>(string sql)
        {
            using (IDbConnection sc = new SqlConnection(ConfigurationManager.serverconn))
            {
                try
                {
                    var result = sc.QueryFirstAsync<T>(sql);
                    return result.Result;

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
        public async Task<int> CUD(string sql)
        {
            using (IDbConnection sc = new SqlConnection(ConfigurationManager.serverconn))
            {
                try
                {
                    sc.Open();
                    return await sc.ExecuteAsync(sql);
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
        public async Task<int> CUD<T>(string sql, T I)
        {
            using (IDbConnection sc = new SqlConnection(ConfigurationManager.serverconn))
            {
                sc.Open();
                try
                {
                    return await sc.ExecuteAsync(sql, I);
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
        public async Task<List<T>> GetList<T>(string sql)
        {
            using (IDbConnection sc = new SqlConnection(ConfigurationManager.serverconn))
            {
                try
                {
                    IEnumerable<T> result =await sc.QueryAsync<T>(sql);
                    return (List<T>)result;
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
