using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL_Model
{
     public class etl_task_input_excel_info
    {
        //任务数据输入excel表
        public string id { get; set; }
        /// <summary>
        /// 节点id
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
        /// excel文件存储位置
        /// </summary>
        public string task_excel_file { get; set; }
        /// <summary>
        /// excel文件读取sheet页
        /// </summary>
        public string task_excel_sheet { get; set; }
        /// <summary>
        /// excel表头信息
        /// </summary>
        public string task_excel_id { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string create_by { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string create_time { get; set; }
        /// <summary>
        /// 修改人
        /// </summary>
        public string update_by { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public string update_time { get; set; }

    }
}
