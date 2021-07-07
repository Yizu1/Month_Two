using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETL_Model.Admin;

namespace ETL_IRepository.role
{
    public interface IRoleRepository
    {
        /// <summary>
        /// 角色显示查询
        /// </summary>
        /// <param name="nm"></param>
        /// <returns></returns>
        List<ETL_Model.Admin.role> RoleShow(string nm);

        /// <summary>
        /// 角色添加
        /// </summary>
        /// <param name="re"></param>
        /// <returns></returns>
        int RoleAdd(ETL_Model.Admin.role re);

        /// <summary>
        /// 角色修改
        /// </summary>
        /// <param name="re"></param>
        /// <returns></returns>
        int RoleUpt(ETL_Model.Admin.role re);

        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        List<ETL_Model.Admin.role> Fan(int id);

        /// <summary>
        /// 角色删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int RoleDelete(int id);
    }
}
