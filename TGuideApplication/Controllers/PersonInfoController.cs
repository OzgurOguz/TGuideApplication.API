﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TGuideApplication.Core.IRepository;
using TGuideApplication.Core.Models;
using TGuideApplication.MessageQueue;

namespace TGuideApplication.Controllers
{
    [Route("api/[controller]")]
    public class PersonInfoController : Controller
    {
        private readonly IPersonInfoRepository _personInfoRepository;

        public PersonInfoController(IPersonInfoRepository personInfoRepository)
        {
            _personInfoRepository = personInfoRepository;
        }

        [HttpGet]
        public Task<string> Get(string id)
        {
            if (id == null)
                return this.GetPersonInfo();

            return GetPersonInfoById(id);
        }

        private async Task<string> GetPersonInfo()
        {
            var personInfo = await _personInfoRepository.GetAllDataAsync();
            return JsonConvert.SerializeObject(personInfo);
        }

        [HttpGet("{id}")]
        public Task<string> GetById(string id)
        {
            return GetPersonInfoById(id);
        }

        private async Task<string> GetPersonInfoById(string id)
        {
            var personInfo = await _personInfoRepository.GetDataAsync(id);
            return JsonConvert.SerializeObject(personInfo);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PersonInfo personInfo)
        {
            await _personInfoRepository.AddDataAsync(personInfo);
            return Created(String.Empty, personInfo);
        }

        [HttpPut("{id}")]
        public async Task<string> Update(string id, [FromBody] PersonInfo personInfo)
        {
            if (string.IsNullOrEmpty(id)) return "Invalid id";
            await _personInfoRepository.UpdateDataAsync(id, personInfo);
            return "Ok";
        }

        [HttpDelete("{id}")]
        public async Task<string> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return "Invalid id";
            await _personInfoRepository.DeleteDataAsync(id);
            return "Ok";
        }


        [HttpDelete]
        public async Task<string> DeleteAll()
        {
            await _personInfoRepository.DeleteAllDataAsync();
            return "";
        }


    }
}