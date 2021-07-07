using ETL_Common;
using ETL_IRepository.sys_role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL_Repository.sys_role
{
    public class sys_roleRepository : Isys_roleRepository
    {
        RedisHelper<ETL_Model.Admin.sys_role> rl = new RedisHelper<ETL_Model.Admin.sys_role>();
        RedisHelper<ETL_Model.Admin.sys_user> lo = new RedisHelper<ETL_Model.Admin.sys_user>();
        //缓存关键字
        string redisKey;
        string redisLogin;
        //获取全部数据
        List<ETL_Model.Admin.sys_role> rls = new List<ETL_Model.Admin.sys_role>();
        List<ETL_Model.Admin.sys_user> loginls = new List<ETL_Model.Admin.sys_user>();
        public sys_roleRepository()
        {
            redisKey = "role_list";
            rls = rl.GetList(redisKey);
            redisLogin = "loginlist";
            loginls = lo.GetList(redisLogin);
        }
        //显示
        public List<ETL_Model.Admin.sys_role> ShowRoles()
        {
            rls = null;
            try 
            {
               string sql = "select * from sys_role";
               
                if (rls == null || rls.Count == 1)
                {
                    rls = DapperHelper.GetLists<ETL_Model.Admin.sys_role>(sql);
                    rl.SetList(rls, redisKey);
                }
                return rls;
            }
            catch (Exception)
            {

                throw;
            }

        }
        //删除
        public int DelRoles(string id)
        {
           

            string sql = $"delete from sys_role where id='{id}'";

            int i = DapperHelper.Execute(sql);
            if (i > 0)
            {
                string[] arr = id.Split(',');
                foreach (var item in arr)
                {
                    ETL_Model.Admin.sys_role uu = rls.FirstOrDefault(x => x.id.Equals(item));
                    rls.Remove(uu);
                }
                rl.SetList(rls, redisKey);
            }
            return i;
        }
        //添加
        public int insertRoles(ETL_Model.Admin.sys_role a)
        {
            string id = Guid.NewGuid().ToString();
            string sql = $"insert into sys_role VALUES('{id}','{a.role_name}','{a.role_status}','{a.revision}','{a.name}',now(),'{a.name}',now())";
            int i = DapperHelper.Execute(sql);
            if (i > 0)
            {
                ETL_Model.Admin.sys_role mc = DapperHelper.GetLists<ETL_Model.Admin.sys_role>("select * from sys_role order by id desc LIMIT 1").FirstOrDefault();
                a = mc;
                rls.Add(a);
                rl.SetList(rls, redisKey);
            }
  
            return i;
        }
        //修改
        public int UpdateRoles(ETL_Model.Admin.sys_role a)
        {
            string sql = $"Update sys_role set role_name='{a.role_name}',role_status='{a.role_status}',revision='{a.revision}',create_by='{a.name}',create_time=now(),update_by='{a.name}',update_time=now() where id='{a.id}'";
            int i = DapperHelper.Execute(sql);
            if (i > 0)
            {
                rls[rls.IndexOf(rls.FirstOrDefault(x => x.id == a.id))] = a;
                rl.SetList(rls, redisKey);
            }
            return i;
        }

    }
}
