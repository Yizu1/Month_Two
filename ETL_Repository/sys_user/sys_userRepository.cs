using ETL_Common;
using ETL_IRepository.sys_user;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL_Repository.sys_user
{

    public class sys_userRepository : Isys_userRepository
    {
        RedisHelper<ETL_Model.Admin.sys_user> us = new RedisHelper<ETL_Model.Admin.sys_user>();
        RedisHelper<ETL_Model.Admin.sys_user> loginre = new RedisHelper<ETL_Model.Admin.sys_user>();
        string redisKey;
        string redislogin;
        List<ETL_Model.Admin.sys_user> lst = new List<ETL_Model.Admin.sys_user>();
        List<ETL_Model.Admin.sys_user> loginls = new List<ETL_Model.Admin.sys_user>();
        DapperHelper db = new DapperHelper();
        public sys_userRepository()
        {
            redisKey = "sys_user_list";
            lst = us.GetList(redisKey);
            redislogin = "loginlist";
            loginls = loginre.GetList(redislogin);
        }
        public List<ETL_Model.Admin.sys_user> Query()
        {
            lst = null;
            string sq = "SELECT a.*,b.role_name FROM sys_user a JOIN sys_role b ON a.rid=b.id";
            if (lst == null || lst.Count == 0)
            {
                lst = DapperHelper.GetLists<ETL_Model.Admin.sys_user>(sq);
                us.SetList(lst, redisKey);
            }
            return lst;
        }
        public List<ETL_Model.Admin.sys_role> Bang()
        {
            string sql = $"select id,role_name from sys_role";
            return DapperHelper.GetLists<ETL_Model.Admin.sys_role>(sql);
        }
        public int Insert(ETL_Model.Admin.sys_user a)
        {
            string id= Guid.NewGuid().ToString();

            string sql = $"insert into sys_user(id,name,email,phone,img_url,username,password,is_admin,status,revision,create_by,create_time,update_by,UPDATED_TIME,rid) values(uuid(),@name,null,@phone,null,@username,@password,null,null,null,null,null,null,null,@role_id)";
            int i = db.CUD(sql,a);
            return i;
        }
        public int UptState(string id)
        {


            ETL_Model.Admin.sys_user ls = DapperHelper.GetLists<ETL_Model.Admin.sys_user>($"select * from sys_user where id='{id}'").FirstOrDefault();
            if (ls.status == 0)
            {
                ls.status = 1;
            }
            else
            {
                ls.status = 0;
            }
            string sql = $"Update sys_user set status='{ls.status}' where id='{ls.id}'";
            int i= DapperHelper.Execute(sql);
            if (i>0)
            {
                lst.FirstOrDefault(x => x.id.Equals(id)).status = ls.status;
                us.SetList(lst, redisKey);

            }
            return i;
        }

        public int Uptuser(ETL_Model.Admin.sys_user a)
        {
            string sql = $"Update sys_user set name='{a.name}',email=null,phone='{a.phone}',img_url=null,username='{a.username}',password='{a.password}',is_admin=null,status=0,revision=0,create_by=null,create_time=now(),update_by=null,UPDATED_TIME=now(),rid='{a.role_id}' where id='{a.id}'";
            int i = db.CUD(sql);
            return i;

        }
        public int DelUser(string ids)
        {
            string sql = $"delete from sys_user where id='{ids}'";
             
            int i= DapperHelper.Execute(sql);
            if (i>0)
            {
                string[] arr = ids.Split(',');
                foreach (var item in arr)
                {
                    ETL_Model.Admin.sys_user uu = lst.FirstOrDefault(x => x.id.Equals(item));
                    lst.Remove(uu);
                }
                us.SetList(lst, redisKey);
            }
            return i;

        }
    }
}
