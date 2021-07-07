using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL_IRepository.sys_role
{
    public interface Isys_roleRepository
    {
        List<ETL_Model.Admin.sys_role> ShowRoles();
        int DelRoles(string id);
        int insertRoles(ETL_Model.Admin.sys_role a);
        int UpdateRoles(ETL_Model.Admin.sys_role a);
    }
}
