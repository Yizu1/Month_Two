using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL_IRepository.sys_user
{
    public interface Isys_userRepository
    {
        List<ETL_Model.Admin.sys_user> Query();
        int Insert(ETL_Model.Admin.sys_user a);
        int UptState(string id);
        int Uptuser(ETL_Model.Admin.sys_user a);
        int DelUser(string ids);
        List<ETL_Model.Admin. sys_role> Bang();
    }
}
