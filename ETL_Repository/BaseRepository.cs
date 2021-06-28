using ETL_IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL_Repository
{

    public class BaseRepository<T>
    {
        ETL_Common.DapperHelper dh = new ETL_Common.DapperHelper();
        public int Delete(string ids)
        {
            return  dh.CUD(ids).Result;
            //throw new NotImplementedException();
        }

        public List<T> GetList(string sql)
        {
           return ETL_Common.DapperHelper.GetList<T>(sql).Result;
            //throw new NotImplementedException();
        }

        public int Insert(string sql)
        {

            return dh.CUD(sql).Result;
            throw new NotImplementedException();
        }

        public T TheFill(string sql)
        {
            return dh.Fant<T>(sql).Result;

            //throw new NotImplementedException();
        }

        public int Update(string sql)
        {
            return dh.CUD(sql).Result;
            //throw new NotImplementedException();
        }
    }
}
