using ETL_IRepository;
using ETL_Model;
using System;
using ETL_Common;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL_Repository
{
    public class TidLxinRepository : ITidLxinRepository<TidLxin>
    {
        private readonly SQLServerHelper _TidLxin;
        public TidLxinRepository(SQLServerHelper TidLxin)
        {
            _TidLxin = TidLxin;
        }
        public List<TidLxin> Bang()
        {
            string str = $"select * from TidLxin";
            var dt = _TidLxin.GetDataSet(str).Result.Tables[0];
            var list = _TidLxin.DataTableToList<TidLxin>(dt);
            return list;

        }
    }
}
