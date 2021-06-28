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
        private readonly SQLServerHelper _Engine;
        public EngineRepository(SQLServerHelper Engine)
        {
            _Engine = Engine;
        }

        

        public int Delete(string ids)
        {
            string str = $"delete from Engine where Id in ({ids})";
            return _Engine.ExecuteNonQuery(str);


        }

        public IEnumerable<Engine> GetList()
        {
            string str = $"select * from engine left join tidlxin on tidlxin.tid=engine.tid left join tid1lxin on tid1lxin.tid1=engine.tid1 where 1=1";
            var dt = _Engine.GetDataSet(str).Tables[0];
            var list = _Engine.DataTableToList<Engine>(dt);
            return list;
        }

        public int Insert(Engine model)
        {
            string str = $"insert into Engine values(null,'{model.Tid1}','{model.Name}',1,'{model.Tid}','{model.IId}')";
            return _Engine.ExecuteNonQuery(str);

        }

        public Engine TheFill(string id)
        {
            string str = $"select * from Engine where Id='{id}'";
            var dt = _Engine.GetDataSet(str).Tables[0];
            var list = _Engine.DataTableToList<Engine>(dt);
            return list[0];
        }


        public int Update(Engine model)
        {
            string str = $"update Engine set Tid1='{model.Tid1}',Name='{model.Name}',TName1='1',Tid='{model.Tid}',IId='{model.IId}'where Id={model.Id}";
            return _Engine.ExecuteNonQuery(str);
        }

        List<Engine> IBase<Engine>.GetList()
        {
            throw new NotImplementedException();
        }
    }
}
