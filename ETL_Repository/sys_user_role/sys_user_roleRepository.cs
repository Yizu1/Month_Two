﻿using ETL_Common;
using ETL_IRepository.sysy_user_role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL_Repository.sys_user_role
{
    public class sys_user_roleRepository: Isys_user_roleRepository
    {
        RedisHelper<ETL_Model.Admin.sys_user_role> ur = new RedisHelper<ETL_Model.Admin.sys_user_role>();
        string redisKey;
        List<ETL_Model.Admin.sys_user_role> lst = new List<ETL_Model.Admin.sys_user_role>();
        public sys_user_roleRepository()
        {
            redisKey = "sys_ruser_list";
            lst = ur.GetList(redisKey);
        }
        public int Add(ETL_Model.Admin.sys_user_role m)
        {
            string sql = $"insert into sys_user_role values(uuid(),'{m.role_id}','{m.user_id}')";

            int i = DapperHelper.Execute(sql);
            if (i > 0)
            {
                m = DapperHelper.GetLists<ETL_Model.Admin.sys_user_role>("select * from sys_user_role order by id desc LIMIT 1").FirstOrDefault();
                List<ETL_Model.Admin.sys_user_role> ss = new List<ETL_Model.Admin.sys_user_role>();
                ss.Add(m);
                lst = ss;
                ur.SetList(lst, redisKey);
            }
            return i;
        }

    }
}
