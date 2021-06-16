using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace ETL_Common
{
    public class DapperHelper
    {
        #region

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public T Scalar<T>(string sql)
        {
            using (IDbConnection sc = new MySql.Data.MySqlClient.MySqlConnection(ConfigurationManager.conn))
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
            using (IDbConnection sc = new MySql.Data.MySqlClient.MySqlConnection(ConfigurationManager.conn))
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
            using (IDbConnection sc = new MySqlConnection(ConfigurationManager.conn))
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
        /// <param name="MySql"></param>
        /// <returns></returns>
        public int CUD<T>(string sql, T I)
        {
            using (IDbConnection sc = new MySqlConnection(ConfigurationManager.conn))
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
            using (IDbConnection sc = new MySqlConnection(ConfigurationManager.conn))
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
