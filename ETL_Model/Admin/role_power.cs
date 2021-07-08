using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL_Model.Admin
{
    /// <summary>
    /// 角色权限表
    /// </summary>
    public class role_power
    {
        public int rgid { get; set; } //表id
        public int rid { get; set; } //角色id
        public int pid { get; set; }//权限id
    }
}
