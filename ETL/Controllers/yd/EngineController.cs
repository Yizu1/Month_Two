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
        public async Task<List<Engine>>  Show(string name4,string name1,int id)
        {
           
                 List<Engine> list =  _Engine.GetList();
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
                return list ;
           
            
        }
        [Route("api/EngineDel")]
        [HttpPost]
        public async Task<int> Del(string ids)
        {
            ids = ids.TrimEnd(',');
            var  list = _Engine.Delete(ids);
            return list;
        }
        [Route("api/EngineFan")]
        [HttpGet]
        public async Task<Engine> Fan(string id)
        {
            Engine list = _Engine.TheFill(id);
            return list;
        }
        [Route("/api/EngineAdd")]
        [HttpPost]
        public async Task<int> Add(Engine i)
        {
            int h = _Engine.Insert(i);
            return h;
        }
        [Route("/api/EngineUpd")]
        [HttpPost]
        public async Task<int> Upd(Engine i)
        {
            int h = _Engine.Update(i);
            return h;
        }
    }
}
