using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL_Model
{
    //任务数据输入表
    public class etl_task_input_info
    {
        // 任务数据输入表
        public string id { get; set; }
        /// <summary>
        /// 节点ID
        /// </summary>
        public string node_id { get; set; }
        /// <summary>
        /// 节点名称
        /// </summary>
        public string node_name { get; set; }
        /// <summary>
        /// 任务ID
        /// </summary>
        public string task_id { get; set; }
        /// <summary>
        /// 数据库ID
        /// </summary>
        public string database_id { get; set; }
        /// <summary>
        /// 数据库名称
        /// </summary>
        public string database_name { get; set; }
        /// <summary>
        /// 表名称
        /// </summary>
        public string table_name { get; set; }
        /// <summary>
        /// 表别名
        /// </summary>
        public string table_as_name { get; set; }
        /// <summary>
        /// 表字段
        /// </summary>
        public string table_field { get; set; }
        /// <summary>
        /// 表字段别名
        /// </summary>
        public string table_as_field { get; set; }
        /// <summary>
        /// 字段规则
        /// </summary>
        public string field_as_egine_id { get; set; }
        /// <summary>
        /// 乐观锁
        /// </summary>
        public string revision { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string create_by { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string create_time { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        public string update_by { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public string update_time { get; set; }
    }
}
