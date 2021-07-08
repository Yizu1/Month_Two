using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETL_IRepository.sys_role;

namespace ETL.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class sys_rolesController : ControllerBase
    {
        private readonly Isys_roleRepository _sys_roleRepository;
        public sys_rolesController(Isys_roleRepository sys_roleRepository)
        {
            _sys_roleRepository = sys_roleRepository;
        }
        [Route("/api/ShowRoles")]
        [HttpGet]
        public IActionResult ShowRoles(string sname = "")
        {
            try
            {
                var ls = _sys_roleRepository.ShowRoles();
                if (!string.IsNullOrEmpty(sname))
                {
                    ls = ls.Where(x => x.role_name.Contains(sname)).ToList();
                }
                return Ok(new
                {
                    data = ls,
                    code = 0,
                    msg = ""

                });
            }
            catch (Exception)
            {

                throw;
            }


        }
        [Route("/api/DelRoles")]
        [HttpPost]
        public int DelRoles(string id)
        {
            try
            {
                return _sys_roleRepository.DelRoles(id);
            }
            catch (Exception)
            {

                throw;
            }

        }
        [Route("/api/insertRoles")]
        [HttpPost]
        public int insertRoles(ETL_Model.Admin.sys_role a)
        {
            try
            {
                int i = _sys_roleRepository.insertRoles(a);
                return i;
            }
            catch (Exception  ex)
            {
                string n = ex.Message;
                return 0;
                throw;
            }


        }
        [Route("/api/UpdateRoles")]
        [HttpPost]
        public int UpdateRoles([FromForm] ETL_Model.Admin.sys_role a)
        {
            try
            {
                int i = _sys_roleRepository.UpdateRoles(a);
                return i;
            }
            catch (Exception)
            {

                throw;
            }
        }
      

     
    }
}
