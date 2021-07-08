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
    public class Tid1LxinRepository: ITid1LxinRepository<Tid1Lxin>
    {
        private readonly SQLServerHelper _Tid1Lxin;
        public Tid1LxinRepository(SQLServerHelper Tid1Lxin)
        {
            _Tid1Lxin = Tid1Lxin;
        }

        public List<Tid1Lxin> Bang()
        {
            string str = $"select * from Tid1Lxin";
            var dt = _Tid1Lxin.GetDataSet(str).Result.Tables[0];
            var list = _Tid1Lxin.DataTableToList<Tid1Lxin>(dt);
            return list;
        }
    }
}
