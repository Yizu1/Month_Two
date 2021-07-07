using ETL_IRepository.role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETL_Common;

namespace ETL_Repository.role
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DapperHelper _dapperHelper;

        //注入
        public RoleRepository(DapperHelper dapperHelper)
        {
            _dapperHelper = dapperHelper;
        }

        /// <summary>
        /// 角色反填
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<ETL_Model.Admin.role> Fan(int id)
        {
            string sql = $"SELECT * from Role where rid={id}";
            return _dapperHelper.GetList<ETL_Model.Admin.role>(sql);
        }

        /// <summary>
        /// 角色添加
        /// </summary>
        /// <param name="re"></param>
        /// <returns></returns>
        public int RoleAdd(ETL_Model.Admin.role re)
        {
            string sql = $"insert into role VALUES(0,'{re.rname}')";
            return _dapperHelper.CUD(sql);
        }

        /// <summary>
        /// 角色删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int RoleDelete(int id)
        {
            string sql = $"DELETE FROM role WHERE rid={id}";
            return _dapperHelper.CUD(sql);
        }

        /// <summary>
        /// 角色显示
        /// </summary>
        /// <param name="nm"></param>
        /// <returns></returns>
        public List<ETL_Model.Admin.role> RoleShow(string nm)
        {
            string sql = $"SELECT * FROM role";
            if (!string.IsNullOrEmpty(nm))
            {
                sql += $" where rname LIKE '%{nm}%'";
            }
            return _dapperHelper.GetList<ETL_Model.Admin.role>(sql);
        }

        /// <summary>
        /// 角色修改
        /// </summary>
        /// <param name="re"></param>
        /// <returns></returns>
        public int RoleUpt(ETL_Model.Admin.role re)
        {
            string sql = $"UPDATE role SET rname='{re.rname}' WHERE rid ={re.rid}";
            return _dapperHelper.CUD(sql, re);
        }
    }
}
