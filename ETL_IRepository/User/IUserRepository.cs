using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETL_Model.Admin;

namespace ETL_IRepository.User
{
    public interface IUserRepository
    {
        /// <summary>
        /// 显示查询
        /// </summary>
        /// <param name="nm">姓名</param>
        /// <param name="phone">手机号码</param>
        /// <param name="um">用户名</param>
        /// <returns></returns>
        List<consumer> UserShow(string nm, string shou, string um);

        /// <summary>
        /// 用户添加
        /// </summary>
        /// <param name="cm"></param>
        /// <returns></returns>
        int UserAdd(consumer cm);

        /// <summary>
        /// 用户修改
        /// </summary>
        /// <param name="cm"></param>
        /// <returns></returns>
        int UserUpt(consumer cm);

        /// <summary>
        /// 反填
        /// </summary>
        /// <returns></returns>
        List<consumer> Fan(int id);

        /// <summary>
        /// 禁用状态
        /// </summary>
        /// <param name="id">修改的id</param>
        /// <returns></returns>
        int UptState(int id);

        /// <summary>
        /// 启用状态
        /// </summary>
        /// <param name="id">修改的id</param>
        /// <returns></returns>
        int OpenState(int id);

        /// <summary>
        /// 用户删除
        /// </summary>
        /// <param name="id">需要删除的id</param>
        /// <returns></returns>
        int UserDelete(int id);

        /// <summary>
        /// 绑定下拉
        /// </summary>
        /// <returns></returns>
        List<ETL_Model.Admin.role> UserBangd();
    }
}
