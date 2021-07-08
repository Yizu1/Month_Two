using ETL_Common;
using ETL_IRepository;
using ETL_IRepository.IEngine;
using ETL_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL_Repository
{

    public class EngineRepository : IEngineRepository<Engine>
    {
        //实例化redis缓存帮助类
        RedisHelper<Engine> dh = new RedisHelper<Engine>();
        string dataredisKey;
        List<Engine> listd = new List<Engine>();

        private readonly SQLServerHelper _Engine;
        public EngineRepository(SQLServerHelper Engine)
        {
            _Engine = Engine;
            dataredisKey = "Engine";

        }

        public async Task<int> Delete(string ids)
        {
            string str = $"delete from Engine where Id in ({ids})";
            var aa = await Task.FromResult(_Engine.ExecuteNonQuery(str));

            return aa.Result;
        }

        public async Task<List<Engine>> GetList()
        {

            string str = $"select * from engine left join tidlxin on tidlxin.tid=engine.tid left join tid1lxin on tid1lxin.tid1=engine.tid1 where 1=1";
            var dt = await Task.FromResult(_Engine.GetDataSet(str).Result.Tables[0]);
            var list = _Engine.DataTableToList<Engine>(dt);

            return list;
        }

        public async Task<int> Insert(Engine model)
        {


            string str = $"insert into Engine values(null,'{model.Tid1}','{model.Name}',1,'{model.Tid}','{model.IId}')";
            return await Task.FromResult(_Engine.ExecuteNonQuery(str)).Result;
            //然后再把集合添加一个数据，先看看能不能添加到数据库


        }


        public async Task<Engine> TheFill(string id)
        {
            string str = $"select * from Engine where Id='{id}'";
            var dt = await Task.FromResult(_Engine.GetDataSet(str).Result.Tables[0]);
            var list = _Engine.DataTableToList<Engine>(dt);
            return list[0];
        }


        public async Task<int> Update(Engine model)
        {
            string str = $"update Engine set Tid1='{model.Tid1}',Name='{model.Name}',TName1='1',Tid='{model.Tid}',IId='{model.IId}'where Id={model.Id}";
            var aa = await Task.FromResult(_Engine.ExecuteNonQuery(str));
            return aa.Result;
        }


    }
}
