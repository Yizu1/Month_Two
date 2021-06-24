using ETL_IRepository.IEngine;
using ETL_Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETL.Controllers.yd
{
    public class EngineController : Controller
    {
        private readonly IEngineRepository<Engine> _Engine;
        public EngineController(IEngineRepository<Engine> Engine)
        {
            _Engine = Engine;
        }
        [Route("api/EngineShow")]
        [HttpGet]
        public IEnumerable<Engine> Show(string name4, string name1, int id)
        {
            IEnumerable<Engine> list = _Engine.GetList();
            if (!string.IsNullOrEmpty(name4))
            {
                list = list.Where(m => m.Name.Contains(name4)).ToList();
            }
            if (!string.IsNullOrEmpty(name1))
            {
                list = list.Where(m => m.IId.Contains(name1)).ToList();
            }
            if (id > 0)
            {
                list = list.Where(m => m.Tid.Equals(id)).ToList();
            }
            return list;
        }
        [Route("api/EngineDel")]
        [HttpPost]
        public IActionResult Del(string ids)
        {
            ids = ids.TrimEnd(',');
            var  list = _Engine.Delete(ids);
            return Ok(list);
        }
        [Route("api/EngineFan")]
        [HttpGet]
        public IActionResult Fan(string id)
        {
            return Ok(_Engine.TheFill(id));
        }
        [Route("/api/EngineAdd")]
        [HttpPost]
        public IActionResult Add(Engine i)
        {
            int h = _Engine.Insert(i);
            return Ok(new { sate = h > 0 ? true : false, msg = h > 0 ? "操作成功" : "操作失败" });
        }
        [Route("/api/EngineUpd")]
        [HttpPost]
        public IActionResult Upd(Engine i)
        {
            int h = _Engine.Update(i);
            return Ok(new { sate = h > 0 ? true : false, msg = h > 0 ? "操作成功" : "操作失败" });
        }
    }
}
