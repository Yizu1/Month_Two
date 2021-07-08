using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL_Model.Admin
{
    /// <summary>
    /// 权限表
    /// </summary>
    public class power
    {
        public int pid { get; set; } //权限id
        public string pname { get; set; } //权限名
        public int tid { get; set; } //上级id
    }
}
