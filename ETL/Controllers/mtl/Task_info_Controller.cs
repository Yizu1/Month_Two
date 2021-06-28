using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETL.Controllers.mtl
{
    using ETL_Model;
    [Route("api/[controller]")]
    [ApiController]
    public class Task_info_Controller : ControllerBase
    {
        private ETL_IRepository.Ietl_task_infoRepository _task { get; set; }

        public Task_info_Controller(ETL_IRepository.Ietl_task_infoRepository task)
        {
            _task = task;
        }



        /// <summary>
        /// 添加任务
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        [HttpPost("/api/task_info/insert")]
        public async Task<int> insert(ETL_Model.etl_task_info a)
        {
            int n =await _task.Insert(a);

            return n;
        }

        /// <summary>
        /// 显示任务管理
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/task_info/show")]
        public async Task<List<etl_task_info>> show(string name = "", int zt = -1, int quanz = 0)
        {
            var ar =await _task.GetList();
            List<etl_task_info> ls = null;


            if (ar != null)
            {
                ar = (from x in ar
                      where (
                       ((zt != -1 ? (int)x.status == (int)zt : true))
                            && ((quanz != 0 ? x.weight == ((weight)quanz) : true))
                            && (string.IsNullOrEmpty(name) ? true : x.name.Contains(name))
                            
                            )
                      select x).ToList();
            } 
            return ar;
        }

        [HttpPut("/api/task_info/fill")]
        public async Task<etl_task_info> fill(string id)
        {
            var ar =await _task.TheFill(id);
            return ar;
        }

        [HttpDelete("/api/task_info/del")]
        public async Task<int>  dele(string id)
        {
            int i =await _task.Delete(id);
            return  i ;
        }

        [HttpPost("/api/task_info/upt")]
        public async Task<int> upt(string id)
        {
            int i = await _task.Upt(id);
            return i;
        }
    }
}
