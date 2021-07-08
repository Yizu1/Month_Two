using ETL_Common;
using ETL_IRepository.User;
using ETL_Model.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL_Repository.User
{
    public class UserRepository : IUserRepository
    {
        //注入
        private readonly DapperHelper _DapperHelper;

        public UserRepository(DapperHelper DapperHelper)
        {
            _DapperHelper = DapperHelper;
        }

        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="id">需要反填的id</param>
        /// <returns></returns>
        public List<consumer> Fan(int id)
        {
            string sql = $"SELECT * FROM consumer a LEFT JOIN role b ON a.rid = b.rid where user_id = {id}";
            return _DapperHelper.GetList<consumer>(sql);
        }

        /// <summary>
        /// 禁用状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int UptState(int id)
        {
            string sql = $"UPDATE consumer SET state=0 WHERE user_id ={id}";
            return _DapperHelper.CUD(sql);
        }

        /// <summary>
        /// 启用状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int OpenState(int id)
        {
            string sql = $"UPDATE consumer SET state=1 WHERE user_id ={id}";
            return _DapperHelper.CUD(sql);
        }

        /// <summary>
        /// 用户添加
        /// </summary>
        /// <param name="cm"></param>
        /// <returns></returns>
        public int UserAdd(consumer cm)
        {
            string sql = "insert into consumer(user_id,cName,phone,user_name,pass,isadmin,state,rid) values(0,@cName,@phone,@user_name,@pass,@isadmin,1,@rid)";
            return _DapperHelper.CUD(sql,cm);
        }

        /// <summary>
        /// 绑定下拉
        /// </summary>
        /// <returns></returns>
        public List<ETL_Model.Admin.role> UserBangd()
        {
            string sql = "SELECT * FROM role";
            return _DapperHelper.GetList<ETL_Model.Admin.role>(sql);
        }

        /// <summary>
        /// 用户删除
        /// </summary>
        /// <param name="id">删除的id</param>
        /// <returns></returns>
        public int UserDelete(int id)
        {
            string sql = $"DELETE FROM consumer WHERE user_id={id}";
            return _DapperHelper.CUD(sql);
        }

        /// <summary>
        /// 显示查询
        /// </summary>
        /// <param name="nm">姓名</param>
        /// <param name="phone">手机号码</param>
        /// <param name="um">用户名</param>
        /// <returns></returns>
        public List<consumer> UserShow(string nm, string shou, string um)
        {
            string sql = "SELECT * FROM consumer a LEFT JOIN role b ON a.rid = b.rid";
            if (!string.IsNullOrEmpty(nm))
            {
                sql += $" where cname LIKE '%{nm}'";
            }
            if (!string.IsNullOrEmpty(shou))
            {
                sql += $" where phone = '{shou}'";
            }
            if (!string.IsNullOrEmpty(um))
            {
                sql += $" where user_name LIKE '%{um}'";
            }
            return _DapperHelper.GetList<consumer>(sql);
        }

        /// <summary>
        /// 用户修改
        /// </summary>
        /// <param name="cm"></param>
        /// <returns></returns>
        public int UserUpt(consumer cm)
        {
            string sql = $"UPDATE consumer SET cName=@cName,phone=@phone,user_name=@user_name,pass=@pass,isadmin=@isadmin,state=@state,rid=@rid WHERE user_id ={cm.user_id}";
            return _DapperHelper.CUD(sql, cm);
        }

        
    }
}
