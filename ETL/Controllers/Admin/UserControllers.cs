using ETL_IRepository.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETL_Model.Admin;

namespace ETL.Controllers.Admin
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserControllers : ControllerBase
    {
        //注入
        private readonly IUserRepository _userRepository;

        public UserControllers(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        /// <summary>
        /// 显示查询
        /// </summary>
        /// <returns></returns> 
        [HttpGet]
        [Route("/api/UserShow")]
        public IActionResult Show(string nm,string shou,string um)
        {
            //显示数据
            var list = _userRepository.UserShow(nm, shou, um);
            if (!string.IsNullOrEmpty(nm))
            {
                list = list.Where(x => x.cName.Contains(nm)).ToList();
            }
            if (!string.IsNullOrEmpty(shou))
            {
                list = list.Where(x => x.phone.Equals(shou)).ToList();
            }
            if (!string.IsNullOrEmpty(um))
            {
                list = list.Where(x => x.user_name.Contains(um)).ToList();
            }
            //返回
            return Ok(new { msg = "", code = 0, data = list });
        }

        /// <summary>
        /// 绑定下拉
        /// </summary>
        /// <returns></returns> 
        [HttpGet]
        [Route("/api/UserBangd")]
        public IActionResult Bangd()
        {
            //显示数据
            var bangd = _userRepository.UserBangd();         
            //返回
            return Ok(new { msg = "", code = 0, data = bangd });
        }

        /// <summary>
        /// 反填
        /// </summary>
        /// <returns></returns> 
        [HttpGet]
        [Route("/api/UserFan")]
        public IActionResult Fan(int id)
        {
            //显示数据
            var fan = _userRepository.Fan(id);
            var f = fan[0];
            //返回
            return Ok(new { msg = "", code = 0, data = f });
        }

        /// <summary>
        /// 用户添加
        /// </summary>
        /// <returns></returns> 
        [HttpPost]
        [Route("/api/UserAdd")]
        public IActionResult Add(consumer cm)
        {
            //显示数据
            var add = _userRepository.UserAdd(cm);           
            //返回
            return Ok(new { msg = "", code = 0, data = add });
        }

        /// <summary>
        /// 用户修改
        /// </summary>
        /// <returns></returns> 
        [HttpPost]
        [Route("/api/UserUpt")]
        public IActionResult Upt(consumer cm)
        {
            //显示数据
            var upt = _userRepository.UserUpt(cm);
            //返回
            return Ok(new { msg = "", code = 0, data = upt });
        }

        /// <summary>
        /// 禁用状态
        /// </summary>
        /// <returns></returns> 
        [HttpPost]
        [Route("/api/UserUptState")]
        public IActionResult UptState(int id)
        {
            //显示数据
            var state = _userRepository.UptState(id);
            //返回
            return Ok(new { msg = "", code = 0, data = state });
        }

        /// <summary>
        /// 启用状态
        /// </summary>
        /// <returns></returns> 
        [HttpPost]
        [Route("/api/UserOpenState")]
        public IActionResult OpenState(int id)
        {
            //显示数据
            var state = _userRepository.UptState(id);
            //返回
            return Ok(new { msg = "", code = 0, data = state });
        }

        /// <summary>
        /// 用户删除
        /// </summary>
        /// <returns></returns> 
        [HttpPost]
        [Route("/api/UserDelete")]
        public IActionResult Delete(int id)
        {
            //显示数据
            var del = _userRepository.UserDelete(id);
            //返回
            return Ok(new { msg = "", code = 0, data = del });
        }
    }
}
