using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL_Model.Admin
{
    /// <summary>
    /// 用户表
    /// </summary>
    public class consumer
    {
        public int user_id { get; set; } //用户id
        public string cName { get; set; } //姓名
        public string phone { get; set; } //手机号码
        public string user_name { get; set; } //用户名
        public string pass { get; set; } //密码
        public int isadmin { get; set; } //是否为管理员
        public int state { get; set; } //状态

        public int rid { get; set; } //角色外键
        public string rname { get; set; } //角色名称
    }
}
