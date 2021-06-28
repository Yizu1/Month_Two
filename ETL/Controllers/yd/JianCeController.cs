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
        private readonly IJianCeRepository<Jian> _Jian;
        public JianCeController(IJianCeRepository<Jian> Jian)
        {
            _Jian = Jian;
        }
        [Route("api/JianCeShow")]
        [HttpGet]
        public IActionResult Show()
        {
            List<Jian> list = _Jian.Show();
            return Ok(new { code=0,msg="",data=list});
        }
    }
}
