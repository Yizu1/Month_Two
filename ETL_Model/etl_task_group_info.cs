using System;

namespace ETL_Model
{

    //任务处理分组表
    public class etl_task_group_info
    {
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
        /// 选择节点ID
        /// </summary>
        public string select_node_id { get; set; }
        /// <summary>
        /// 选择表名称
        /// </summary>
        public string select_table_name { get; set; }
        /// <summary>
        /// 选择表字段
        /// </summary>
        public string select_table_field { get; set; }
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
