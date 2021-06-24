using ETL_IRepository;
using ETL_Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETL.Controllers.yd
{
    public class Tid1LxinController : Controller
    {
        private readonly ITid1LxinRepository<Tid1Lxin> _Tid1Lxin;
        public Tid1LxinController(ITid1LxinRepository<Tid1Lxin> Tid1Lxin)
        {
            _Tid1Lxin = Tid1Lxin;

        }
        [Route("api/Tid1LxinBang")]
        [HttpGet]
        public IActionResult Bang()
        {
            List<Tid1Lxin> list = _Tid1Lxin.Bang();
            return Ok(new { msg = "", code = 0, data = list });
        }
    }
}
