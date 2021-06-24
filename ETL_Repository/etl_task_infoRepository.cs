using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETL_Repository.etl_task_info
{
    public class etl_task_infoRepository : ETL_IRepository.Ietl_task_infoRepository
    {
        private readonly ETL_Common.DapperHelper _logger;

        public etl_task_infoRepository(ETL_Common.DapperHelper logger)
        {
            _logger = logger;
        }

        public int Delete(string ids)
        {
            string sql = $"delete from etl_task_info where id in({ids})";
            return _logger.CUD(sql);
        }

        public List<ETL_Model.etl_task_info> GetList()
        {
            String sql = "select * from etl_task_info";
            return _logger.GetList<ETL_Model.etl_task_info>(sql);
        }

        public int Insert(ETL_Model.etl_task_info m)
        {
            string sql = $"insert into etl_task_info  values(uuid(),'{m.name}','{(int)m.weight}','1','0','0','0','0.00','0','0','0',0,0,0,0,0,0,0,'json',0,'{m.create_by}','{DateTime.Now}','',{DateTime.Now})";
            return _logger.CUD(sql,m);
        }

        public ETL_Model.etl_task_info TheFill(string id)
        {
            string sql = $"select * from etl_task_info where id = '{id}'";
            return _logger.Fant<ETL_Model.etl_task_info>(sql);
        }

        public ETL_Model.etl_task_info TheFill(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(ETL_Model.etl_task_info model)
        {
            string sql = "update etl_task_info set ";
            return _logger.CUD(sql);
        }
    }
}
