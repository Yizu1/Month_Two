using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL_IRepository.sys_role_modules
{
   public interface Isys_role_modulesRepository
    {
        int Adds(ETL_Model.Admin.sys_role_modules m);
        int Uptuser(ETL_Model.Admin.sys_role_modules a);
        List<ETL_Model.Admin.sys_role_modules> Uptft(string id);
        object cha(string id);
    }
}
