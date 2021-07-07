using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Newtonsoft.Json;

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
            using (IDbConnection sc = new MySqlConnection(ConfigurationManager.conn))
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

        /// <summary>
        /// 获取数据_BI数据分析
        ///</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static List<T> GetList_BI<T>(string sql, string name, int flag = 1)
        {
            try
            {
                if (flag != 1)
                {
                    string conn = ConfigurationManager.ConnNameSql + name;
                    using (IDbConnection db = new SqlConnection(conn))
                    {
                        return db.Query<T>(sql).ToList();
                    }
                }
                else
                {
                    using (IDbConnection db = new MySqlConnection(ConfigurationManager.conn))
                    {
                        return db.Query<T>(sql).ToList();
                    }
                }

            }
            catch (Exception ex)
            {
                string nn = ex.Message;
                return null;
                throw;
            }
        }


        /// <summary>
        /// 获取首行首列
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object Exescalar(string sql)
        {
            try
            {
                using (IDbConnection db = new MySqlConnection(ConfigurationManager.conn))
                {
                    return db.ExecuteScalar(sql);
                }
            }
            catch (Exception ex)
            {
                string nn = ex.Message;
                return null;
                throw;
            }
        }

        /// <summary>
        /// 根据数据库名称获取其中表数据MySql
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="name">数据库名称</param>
        /// <returns></returns>
        public static string GetDataTable(string sql, string name)
        {
            try
            {
                using (IDbConnection db = new MySqlConnection(ConfigurationManager.ConnName + name))
                {
                    var reader = db.Query(sql);

                    string json = JsonConvert.SerializeObject(reader);

                    return json;
                }
            }
            catch (Exception ex)
            {
                string nn = ex.Message;
                return null;
                throw;
            }
        }

        /// <summary>
        /// 根据数据库名称获取其中表数据SqlServer
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="name">数据库名称</param>
        /// <returns></returns>
        public static string GetDataTableSql(string sql, string name)
        {
            try
            {
                using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnNameSql + name))
                {
                    var reader = db.Query(sql);

                    string json = JsonConvert.SerializeObject(reader);

                    return json;
                }
            }
            catch (Exception ex)
            {
                string nn = ex.Message;
                return null;
                throw;
            }
        }

        /// <summary>
        /// 获取数据
        /// MySql.Data.MySqlClient.MySqlException:“Unknown column 'a.WarehouseId' in 'field list'”</summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static List<T> GetLists<T>(string sql)
        {
            try
            {
                using (IDbConnection db = new MySqlConnection(ConfigurationManager.conn))
                {
                    return db.Query<T>(sql).ToList();
                }
            }
            catch (Exception ex)
            {
                string e = ex.Message;
                throw;
            }
        }
        /// <summary>
        /// 获取受影响行数
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int Execute(string sql)
        {
            try
            {
                using (IDbConnection db = new MySqlConnection(ConfigurationManager.conn))
                {
                    return db.Execute(sql);
                }
            }
            catch (Exception ex)
            {
                string e = ex.Message;
                throw;
            }
        }
        /// <summary>
        /// 获取首行首列
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object Exescalars(string sql)
        {
            try
            {
                using (IDbConnection db = new MySqlConnection(ConfigurationManager.conn))
                {
                    return db.ExecuteScalar(sql);
                }
            }
            catch (Exception ex)
            {
                string e = ex.Message;
                throw;
            }
        }
        #endregion

    }
}
