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
    public class JianCeRepository : IJianCeRepository<ETL_Model.etl_task_info>
    {
        private readonly SQLServerHelper _Jian;
        public JianCeRepository(SQLServerHelper Jian)
        {
            _Jian = Jian;
        }
        public List<ETL_Model.etl_task_info> Show()
        {
            string str = $"select * from etl_task_info";
            //var dt = _Jian.GetDataSet(str).Tables[0];
            var dt = _Jian.GetDataSet(str).Result.Tables[0];
            var list = _Jian.DataTableToList<ETL_Model.etl_task_info>(dt);
            return list;

        }

    }
}
