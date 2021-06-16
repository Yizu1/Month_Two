using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL_Model
{
    //任务信息表
    public class etl_task_info
    {
        public string id { get; set; }
        /// <summary>
        /// 任务名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 任务权重级别 0紧急任务1高2中3低
        /// </summary>
        public int weight { get; set; }
        /// <summary>
        /// 任务执行状态 -1待执行 0可执行 1正在执行 2执行完成
        /// </summary>
        public int process_status { get; set; }
        /// <summary>
        /// 任务状态 1无错误0有错误
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 总处理条数
        /// </summary>
        public int total { get; set; }
        /// <summary>
        /// 已处理条数
        /// </summary>
        public int process_total { get; set; }
        /// <summary>
        /// 任务完成度
        /// </summary>
        public decimal proportion { get; set; }
        /// <summary>
        /// 错误条数
        /// </summary>
        public int error_total { get; set; }
        /// <summary>
        /// 总需执行次数
        /// </summary>
        public int execute_total { get; set; }
        /// <summary>
        /// 已完成执行次数
        /// </summary>
        public int complete_execute_total { get; set; }
        /// <summary>
        /// 成功插入条数
        /// </summary>
        public int success_insert_total { get; set; }
        /// <summary>
        /// 成功修改条数
        /// </summary>
        public int success_update_total { get; set; }
        /// <summary>
        /// 成功删除条数
        /// </summary>
        public int success_delete_total { get; set; }
        /// <summary>
        /// 插入失败条数
        /// </summary>
        public int error_add_total { get; set; }
        /// <summary>
        /// 逻辑失败条数
        /// </summary>
        public int error_logic_total { get; set; }
        /// <summary>
        /// 预计完成时间 精确到秒
        /// </summary>
        public int complete_time { get; set; }
        /// <summary>
        /// 累计处理时间 精确到秒
        /// </summary>
        public int grand_total_time { get; set; }
        /// <summary>
        /// 前端json对象
        /// </summary>
        public string process_json { get; set; }
        /// <summary>
        /// 乐观锁
        /// </summary>
        public int revision { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string create_by { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime create_time { get; set; }
        /// <summary>
        /// 更新人
        /// </summary>
        public String update_by { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary> 
        public DateTime update_time { get; set; }

    }
}
