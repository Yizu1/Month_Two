using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ETL_Common
{
    public class SQLServerHelper
    {
        #region

        public int ExecuteNonQuery(string sql)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.conn))
            {
                conn.Open();
                MySqlCommand commd = new MySqlCommand(sql, conn);
                return commd.ExecuteNonQuery();
            }
        }

        //显示显示操作
        public DataSet GetDataSet(string sql)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.conn))
            {
                conn.Open();
                MySqlDataAdapter data = new MySqlDataAdapter(sql, conn);
                var dt = new DataSet();
                data.Fill(dt);
                return dt;
            }
        }

        //DataTable 转为  List
        public List<T> DataTableToList<T>(DataTable dt) where T : class, new()
        {
            var tt = typeof(T);
            //获取所有属性
            PropertyInfo[] p = tt.GetProperties();
            //var props = typeof(T).GetProperties();
            List<T> list = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T t = (T)Activator.CreateInstance(tt);
                //List<T> t = Activator.CreateInstance(typeof(T));
                //  System.Reflection.ac
                foreach (var pro in p)
                {
                    if (dt.Columns.Contains(pro.Name) && row[pro.Name] != null && row[pro.Name] != DBNull.Value)
                    {
                        pro.SetValue(t, row[pro.Name]);
                    }
                }
                list.Add(t);
            }
            return list;
        }


        //调用存储过程不带参数
        public DataSet ExecuteProc(string proName, Dictionary<string, object> parms)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.conn))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = proName;
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;

                foreach (var item in parms)
                {
                    //command.Parameters.Add(new SqlParameter(item.Key,item.Value));
                    command.Parameters.AddWithValue(item.Key, item.Value);
                }

                SqlDataAdapter sqldata = new SqlDataAdapter();
                var ds = new DataSet();
                sqldata.Fill(ds);

                return ds;
            }
        }

        //调用存储过程带查询条件
        public DataSet ExecuteProcByOut(string proName, Dictionary<string, object> parms, string outparamet, out int rowcount)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.conn))
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = proName;
                command.Connection = conn;
                command.CommandType = CommandType.StoredProcedure;

                foreach (var item in parms)
                {
                    SqlParameter parameter = new SqlParameter();
                    //command.Parameters.Add(new SqlParameter(item.Key,item.Value));
                    command.Parameters.AddWithValue(item.Key, item.Value);
                    if (item.Key.ToLower().Equals(outparamet.ToLower()))
                    {
                        parameter.Direction = ParameterDirection.Output;
                        parameter.Size = 50;
                    }
                    command.Parameters.Add(parameter);
                }
                SqlDataAdapter sqldata = new SqlDataAdapter();
                var ds = new DataSet();
                sqldata.Fill(ds);
                rowcount = Convert.ToInt32(command.Parameters[outparamet].Value);

                return ds;
            }
        }

        #endregion

    }
}
