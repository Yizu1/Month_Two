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
        private readonly IJianCeRepository<JianCe> _JianCe;
        public JianCeController(IJianCeRepository<JianCe> JianCe)
        {
            _JianCe = JianCe;
        }
        [Route("api/JianCeShow")]
        [HttpGet]
        public IActionResult Show()
        {
            List<JianCe> list = _JianCe.Show();
            return Ok(new { code=0,msg="",data=list});
        }
    }
}
