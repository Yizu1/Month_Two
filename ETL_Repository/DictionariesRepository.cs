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
        public async Task<int> Delete(string ids)
        {
            string sql = $"DELETE from dictionaries WHERE Id in({ids})";
            return await _dapperHelper.CUD(sql);
        }

        /// <summary>
        /// 显示字典
        /// </summary>
        /// <returns></returns>
        public async Task< List<dictionaries>> GetList()
        {
            string sql = "select * from dictionaries";
            return await DapperHelper.GetList<dictionaries>(sql);
        }

        /// <summary>
        /// 新增字典
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task< int> Insert(dictionaries model)
        {
            string sql = $"insert into dictionaries VALUES(NULL,N'{model.Coding}','{model.Name}',{model.PName},{model.Property},{model.States},{model.Sort},'{model.Remark}')";
            return await _dapperHelper.CUD(sql);
        }

        /// <summary>
        /// 反填字典
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task< dictionaries> TheFill(string id)
        {
            string sql = $"select * from dictionaries where id ={id} ";
            return await _dapperHelper.Fant<dictionaries>(sql); 
        }

        /// <summary>
        /// 修改字典
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task< int> Update(dictionaries model)
        {
            string sql = $"UPDATE dictionaries SET Coding='{model.Coding}',Name='{model.Name}',Property={model.Property},States={model.States},Sort={model.Sort},Remark='{model.Remark}' where Id={model.Id}";
            return await _dapperHelper.CUD(sql);
        }
    }
}
