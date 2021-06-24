using ETL_IRepository;
using ETL_Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETL.Controllers
{
    public class TidLxinController : Controller
    {
        private readonly ITidLxinRepository<TidLxin> _TidLxin;
        public TidLxinController(ITidLxinRepository<TidLxin> TidLxin)
        {
            _TidLxin = TidLxin;
        }
        [Route("api/TidLxinBang")]
        [HttpGet]
        public IActionResult Bang()
        {
            List<TidLxin> list = _TidLxin.Bang();
            return Ok(new { msg="",code=0,data=list});
        }
    }
}
