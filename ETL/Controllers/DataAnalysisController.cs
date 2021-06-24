using ETL_IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL.Controllers
{
    /// <summary>
    /// 枚举类型
    /// </summary>
    public enum enum_DataBase
    {
        MySQL = 1,
        SqlServer = 2
    }

    [Route("api/[controller]")]
    [ApiController]
    public class DataAnalysisController : ControllerBase
    {
        /// <summary>
        /// 依赖注入
        /// </summary>
        private readonly IData_AnalysisRepository _idata_AnalysisRepository;
        public DataAnalysisController(IData_AnalysisRepository idata_AnalysisRepository)
        {
            _idata_AnalysisRepository = idata_AnalysisRepository;
        }


        //数据库树         public async Task<string>  DatabaseTree()
        [Route("/api/DatabaseTree")]
        [HttpGet]
        public string DatabaseTree()
        {
            try
            {
                //获取MySql全部数据
                List<ETL_Model.GetDataBases> getDataBases = _idata_AnalysisRepository.GetDatabaseName(1);
                //获取SQLserver全部数据
                List<ETL_Model.GetDataBases> getDataBasesSql = _idata_AnalysisRepository.GetDatabaseName(2);

                //用于拼接的字符串
                StringBuilder builder = new StringBuilder();

                //MySQL的拼接
                #region
                builder.Append("{");
                builder.Append("AAAid:1");
                builder.Append(",label:'MYSQL数据库'");
                builder.Append(",children:[");
                //MySql第一层循环 拼接数据库名
                for (int i = 0; i < getDataBases.Count; i++)
                {
                    builder.Append("{");
                    builder.Append("BBBid:" + (i + 1));
                    builder.Append(",label:'" + getDataBases[i].SCHEMA_NAME + "'");


                    List<ETL_Model.GetTables> getTables = _idata_AnalysisRepository.GetTableName(getDataBases[i].SCHEMA_NAME, 1);
                    builder.Append(",children:[");

                    //MySql第二层循环 拼接数据库下的表名
                    for (int j = 0; j < getTables.Count; j++)
                    {
                        builder.Append("{id:" + (j + 1));
                        builder.Append(",label:'" + getTables[j].Table_Name + "'},");
                    }

                    builder.Append("]},");

                }
                builder.Append("]},");
                #endregion

                //SqlServer的拼接
                #region
                builder.Append("{");
                builder.Append("AAAid:2");
                builder.Append(",label:'SqlServer数据库'");
                builder.Append(",children:[");
                //SqlServer第一层循环 拼接数据库名
                for (int i = 0; i < getDataBasesSql.Count; i++)
                {
                    builder.Append("{");
                    builder.Append("BBBid:" + (i + 1));
                    builder.Append(",label:'" + getDataBasesSql[i].SCHEMA_NAME + "'");


                    List<ETL_Model.GetTables> getTablesSql = _idata_AnalysisRepository.GetTableName(getDataBasesSql[i].SCHEMA_NAME, 2);
                    builder.Append(",children:[");

                    //SqlServer第二层循环 拼接数据库下的表名
                    for (int j = 0; j < getTablesSql.Count; j++)
                    {

                        builder.Append("{id:" + (j + 1));
                        builder.Append(",label:'" + getTablesSql[j].Table_Name + "'},");
                    }

                    builder.Append("]},");

                }
                builder.Append("]},");
                #endregion

                //返回字符串并去掉末尾逗号
                return builder.ToString().TrimEnd(',');
            }
            catch (System.Exception ex)
            {
                string nn = ex.Message;
                return null;
                throw;
            }
        }



        /// <summary>
        /// 根据数据库名称获取其中表数据
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="name">数据库名称</param>
        /// <returns></returns>
        [Route("/api/SqlGetJson")]
        [HttpGet]
        public string SqlGetJson(string sql, string name, int flag)
        {
            try
            {
                enum_DataBase ed = (enum_DataBase)flag;
                string json = "";
                switch (ed)
                {
                    case enum_DataBase.MySQL:
                        //获取全部数据
                        json = _idata_AnalysisRepository.GetDataTable(sql, name);
                        break;
                    case enum_DataBase.SqlServer:
                        //获取全部数据
                        json = _idata_AnalysisRepository.GetDataTableSql(sql, name);
                        break;
                }

                return json;
            }
            catch (System.Exception ex)
            {
                string nn = ex.Message;
                return null;
                throw;
            }
        }
    }
}
