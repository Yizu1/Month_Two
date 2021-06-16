using ETL_Common;
using ETL_IRepository;
using ETL_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL_Repository
{
    public class DictionariesRepository : IdictionariesRepository
    {
        /// <summary>
        /// 依赖注入
        /// </summary>
        private readonly DapperHelper _dapperHelper;
        public DictionariesRepository(DapperHelper dapperHelper)
        {
            _dapperHelper = dapperHelper;
        }

        /// <summary>
        /// 删除字典
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public int Delete(string ids)
        {
            string sql = $"DELETE from dictionaries WHERE Id in({ids})";
            return _dapperHelper.CUD(sql);
        }

        /// <summary>
        /// 显示字典
        /// </summary>
        /// <returns></returns>
        public List<dictionaries> GetList()
        {
            string sql = "select * from dictionaries";
            return _dapperHelper.GetList<dictionaries>(sql);
        }

        /// <summary>
        /// 新增字典
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Insert(dictionaries model)
        {
            string sql = $"insert into dictionaries VALUES(NULL,N'{model.Coding}','{model.Name}',{model.PName},{model.Property},{model.States},{model.Sort},'{model.Remark}')";
            return _dapperHelper.CUD(sql);
        }

        /// <summary>
        /// 反填字典
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public dictionaries TheFill(int id)
        {
            string sql = "select * from dictionaries";
            return _dapperHelper.GetList<dictionaries>(sql).FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// 修改字典
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Update(dictionaries model)
        {
            string sql = $"UPDATE dictionaries SET Coding='{model.Coding}',Name='{model.Name}',PName={model.PName},Property={model.Property},States={model.States},Sort={model.Sort},Remark='{model.Remark}' where Id={model.Id}";
            return _dapperHelper.CUD(sql);
        }
    }
}
