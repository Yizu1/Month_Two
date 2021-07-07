using ETL_IRepository.role;
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
    public class RoleControllers : ControllerBase
    {
        //注入
        private readonly IRoleRepository _roleRepository;

        public RoleControllers(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }


        /// <summary>
        /// 显示查询
        /// </summary>
        /// <returns></returns> 
        [HttpGet]
        [Route("/api/RoleShow")]
        public IActionResult Show(string nm)
        {
            //显示数据
            var list = _roleRepository.RoleShow(nm);
            if (!string.IsNullOrEmpty(nm))
            {
                list = list.Where(x => x.rname.Contains(nm)).ToList();
            }          
            //返回
            return Ok(new { msg = "", code = 0, data = list });
        }

        /// <summary>
        /// 角色反填
        /// </summary>
        /// <returns></returns> 
        [HttpGet]
        [Route("/api/RoleFan")]
        public IActionResult Fan(int id)
        {
            //显示数据
            var fan = _roleRepository.Fan(id);
            var f = fan[0];
            //返回
            return Ok(new { msg = "", code = 0, data = f });
        }

        /// <summary>
        /// 角色添加
        /// </summary>
        /// <returns></returns> 
        [HttpPost]
        [Route("/api/RoleAdd")]
        public IActionResult Add(ETL_Model.Admin.role re)
        {
            //显示数据
            var add = _roleRepository.RoleAdd(re);
            //返回
            return Ok(new { msg = "", code = 0, data = add });
        }

        /// <summary>
        /// 角色修改
        /// </summary>
        /// <returns></returns> 
        [HttpPost]
        [Route("/api/RoleUpt")]
        public IActionResult Upt(ETL_Model.Admin.role re)
        {
            //显示数据
            var upt = _roleRepository.RoleUpt(re);
            //返回
            return Ok(new { msg = "", code = 0, data = upt });
        }

        /// <summary>
        /// 角色删除
        /// </summary>
        /// <returns></returns> 
        [HttpPost]
        [Route("/api/RoleDelete")]
        public IActionResult Delete(int id)
        {
            //显示数据
            var del = _roleRepository.RoleDelete(id);
            //返回
            return Ok(new { msg = "", code = 0, data = del });
        }
    }
}
