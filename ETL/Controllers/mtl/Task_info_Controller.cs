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
        public IActionResult insert(ETL_Model.Jian a)
        {
            int n = _task.Insert(a);

            return Ok(new { data = n });
        }

        /// <summary>
        /// 显示任务管理
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/task_info/show")]
        public IActionResult show(string name = "", int zt = -1, int quanz = 0)
        {
            var ar = _task.GetList();
            List<Jian> ls = null;


            if (ar != null)
            {
                ar = (from x in ar
                      where (
                            (string.IsNullOrEmpty(name) ? true : x.name.Contains(name))
                            && ((zt != -1 ? (int)x.status == (int)zt : true))
                            && ((quanz != 0 ? x.weight == ((weight)quanz) : true))
                            )
                      select x).ToList();
            }
            if (zt != -1)
            {
                ar = ar.Where(x => x.statuss == ((status)zt).ToString()).ToList();
            }
            if (quanz != 0)
            {
                ar = ar.Where(x => x.weight == ((weight)quanz)).ToList();
            }


            return Ok(new { data = ar });
        }

        [HttpPut("/api/task_info/fill")]
        public IActionResult fill(string id)
        {
            var ar = _task.TheFill(id);
            return Ok(new { data = ar });
        }

        [HttpDelete("/api/task_info/del")]
        public IActionResult dele(string id)
        {
            int i = _task.Delete(id);
            return Ok(new { data = i });
        }
    }
}
