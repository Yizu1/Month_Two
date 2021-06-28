using ETL_Common;
using ETL_IRepository.IEngine;
using ETL_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL_Repository
{
    public class EngineRizhiRepository : IEngineRizhiRepository<engineRizhi>
    {
        private readonly SQLServerHelper _engineRizhi;
        public EngineRizhiRepository(SQLServerHelper engineRizhi) {
            _engineRizhi = engineRizhi;
        }
        public async Task<int> Rizhi(engineRizhi model)
        {
            string str = $"insert into engineRizhi values (null,'{model.create_by}','{model.create_time}','{model.update_by}','{model.update_time}')";
            var aa =await   _engineRizhi.ExecuteNonQuery(str);
            return aa;
        }
    }
}
