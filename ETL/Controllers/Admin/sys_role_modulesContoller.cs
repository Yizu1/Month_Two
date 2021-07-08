﻿
using ETL_IRepository.sys_role_modules;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETL.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class sys_role_modulesContoller : ControllerBase
    {
        private readonly Isys_role_modulesRepository _sys_role_modulesRepository;
        public sys_role_modulesContoller(Isys_role_modulesRepository sys_role_modulesRepository)
        {
            _sys_role_modulesRepository = sys_role_modulesRepository;
        }
        [Route("/api/Addss")]
        [HttpPost]
        public int Adds(ETL_Model.Admin.sys_role_modules m)
        {
            return _sys_role_modulesRepository.Adds(m);
        }
        [Route("/api/Uptss")]
        [HttpPost]
        public int Uptuser(ETL_Model.Admin.sys_role_modules a)
        {

            return _sys_role_modulesRepository.Uptuser(a);

        }
        [Route("/api/Uptft")]
        [HttpPost]
        public List<ETL_Model.Admin.sys_role_modules> Uptft(string id)
        {
            return _sys_role_modulesRepository.Uptft(id);
        }
        [Route("/api/chas")]
        [HttpPost]
        public IActionResult cha(string id)
        {
            object ls = _sys_role_modulesRepository.cha(id);
            if(ls==null)
            {
                return Ok(-1);
            }
            else
            {
                string ss = ls.ToString();
                string[] arr = ss.Split(',');
                return Ok(arr);
            }
        }
    }
}
