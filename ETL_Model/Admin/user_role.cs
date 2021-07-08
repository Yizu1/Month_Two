using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL_Model.Admin
{
    /// <summary>
    /// 用户角色表
    /// </summary>
    public class user_role
    {
        public int urid { get; set; } //表id
        public int user_id { get; set; } //用户id
        public int rid { get; set; } //角色id
    }
}
