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
    public class JianCeRepository : IJianCeRepository<JianCe>
    {
        private readonly SQLServerHelper _JianCe;
        public JianCeRepository(SQLServerHelper JianCe)
        {
            _JianCe = JianCe;
        }
        public List<JianCe> Show()
        {
            string str = $"select * from JianCe";
            var dt = _JianCe.GetDataSet(str).Tables[0];
            var list = _JianCe.DataTableToList<JianCe>(dt);
            return list;

        }
    }
}
