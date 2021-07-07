using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL_IRepository.sysy_user_role
{
     public interface Isys_user_roleRepository
     {
        int Add(ETL_Model.Admin.sys_user_role m);
     }
}
