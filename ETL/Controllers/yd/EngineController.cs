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
        private readonly IEngineRizhiRepository<engineRizhi> _engineRizhi;
        public EngineController(IEngineRepository<Engine> Engine, IEngineRizhiRepository<engineRizhi> engineRizhi)
        {
            _Engine = Engine;
            _engineRizhi = engineRizhi;
        }

        [Route("api/EngineShow")]
        [HttpGet]
        public async Task<List<Engine>> Show(string name4, string name1, int id)
        {

            List<Engine> list = await _Engine.GetList();
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
        public async Task<int> Del(string ids)
        {
            //之前看的await一个方法加一个就行，两个应该就是同时运行
            ids = ids.TrimEnd(',');
            var list = await _Engine.Delete(ids) ;
            var s = _engineRizhi.Rizhi(new engineRizhi { create_by = "1", create_time = DateTime.Now, update_by = "2", update_time = DateTime.Now });
            return list ;
           
         }
        [Route("api/EngineFan")]
        [HttpGet]
        public async Task<Engine> Fan(string id)
        {
            Engine list = await _Engine.TheFill(id);
            var ss=  _engineRizhi.Rizhi(new engineRizhi { create_by = "1", create_time = DateTime.Now, update_by = "2", update_time = DateTime.Now });
            return list;
        }
        [Route("/api/EngineAdd")]
        [HttpPost]
        public async Task<int> Add(Engine i)
        {
            var h = await Task.FromResult(_Engine.Insert(i));
            var ss= _engineRizhi.Rizhi(new engineRizhi { create_by = "1", create_time = DateTime.Now, update_by = "2", update_time = DateTime.Now });
            return h.Result;
        }
        [Route("/api/EngineUpd")]
        [HttpPost]
        public async Task<int> Upd(Engine i)
        {
            var h = await Task.FromResult(_Engine.Update(i));
            var ss= _engineRizhi.Rizhi(new engineRizhi { create_by = "1", create_time = DateTime.Now, update_by = "2", update_time = DateTime.Now });
            return h.Result;
        }
    }
}
