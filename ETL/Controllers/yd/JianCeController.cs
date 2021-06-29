using ETL_IRepository.IEngine;
using ETL_Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETL.Controllers.yd
{
    public class JianCeController : Controller
    {
        private readonly IJianCeRepository<etl_task_info> _Jian;
        public JianCeController(IJianCeRepository<etl_task_info> Jian)
        {
            _Jian = Jian;
        }
        [Route("api/JianCeShow")]
        [HttpGet]
        public IActionResult Show()
        {
            List<etl_task_info> list = _Jian.Show();
            return Ok(new { code=0,msg="",data=list});
        }
    }
}
