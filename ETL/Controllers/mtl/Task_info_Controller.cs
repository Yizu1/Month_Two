using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETL.Controllers.mtl
{
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
        public IActionResult show()
        {
            var ar = _task.GetList();
            return Ok(new { data = ar });
        }

        [HttpPut("/api/task_info/fill")]
        public IActionResult fill(string id)
        {
            var ar = _task.TheFill(id);
            return Ok(new { data = ar });
        }

    }
}
