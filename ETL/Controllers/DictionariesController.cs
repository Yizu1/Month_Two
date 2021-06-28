using ETL_IRepository;
using ETL_Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETL.Controllers
{
    [ApiController]
    public class DictionariesController : ControllerBase
    {
        /// <summary>
        /// 依赖注入
        /// </summary>
        private readonly IdictionariesRepository _idictionariesRepository;
        public DictionariesController(IdictionariesRepository idictionariesRepository)
        {
            _idictionariesRepository = idictionariesRepository;
        }

        //显示
        [HttpGet]
        [Route("/api/GetDictionaries")]
        public IActionResult GetDictionaries(int pid=-1)
        {
            List<dictionaries> list = _idictionariesRepository.GetList();

            foreach (var s in list)
            {
                s.hasChildren = list.Where(x => x.PName == s.Id).Count() > 0;
            }

            if (pid != -1)
            {
                list = list.Where(x => pid != -1 ? x.PName == pid : true).ToList();
            }

            return Ok(new
            {
                msg = "所有数据",
                code = 0,
                data = list
            });
        }

        //新增
        [HttpPost]
        [Route("/api/AddDictionaries")]
        public int AddDictionaries(dictionaries model)
        {
            return _idictionariesRepository.Insert(model);
        }

        //删除
        [HttpPost]
        [Route("/api/DelDictionaries")]
        public int DelDictionaries(string id)
        {
            return _idictionariesRepository.Delete(id);
        }

        //反填
        [HttpGet]
        [Route("/api/FanDictionaries")]
        public dictionaries FanDictionaries(string id)
        {
            return _idictionariesRepository.TheFill(id);
        }

        //修改
        [HttpPut]
        [Route("/api/UpdateDictionaries")]
        public int UpdateDictionaries(dictionaries model)
        {
            return _idictionariesRepository.Update(model);
        }
    }
}
