using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TGuideApplication.Core.IMessageQueue;
using TGuideApplication.Core.IRepository;
using TGuideApplication.Core.Models;
using TGuideApplication.Filters;
using TGuideApplication.MessageQueue;

namespace TGuideApplication.Controllers
{
    [Route("api/[controller]")]
    public class PersonInfoController : Controller
    {
        private readonly IPersonInfoRepository _personInfoRepository;
        public IPublisher _publisher;

        public PersonInfoController(IPersonInfoRepository personInfoRepository, IPublisher publisher)
        {
            this._personInfoRepository = personInfoRepository;
            this._publisher = publisher;
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

        [ServiceFilter(typeof(NotFoundFilterPersonInfo))]
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

        [ValidationFilter]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PersonInfo personInfo)
        {
            await _personInfoRepository.AddDataAsync(personInfo);
            _publisher.Publisher();

            return Created(String.Empty, personInfo);
        }

        [ValidationFilter]
        [ServiceFilter(typeof(NotFoundFilterPersonInfo))]
        [HttpPut("{id}")]
        public async Task<string> Update(string id, [FromBody] PersonInfo personInfo)
        {
            await _personInfoRepository.UpdateDataAsync(id, personInfo);
            _publisher.Publisher();

            return "Updated";
        }

        [ServiceFilter(typeof(NotFoundFilterPersonInfo))]
        [HttpDelete("{id}")]
        public async Task<string> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return "Invalid id";
            await _personInfoRepository.DeleteDataAsync(id);
            _publisher.Publisher();

            return "Deleted";
        }

        [HttpDelete]
        public async Task<string> DeleteAll()
        {
            await _personInfoRepository.DeleteAllDataAsync();
            _publisher.Publisher();

            return "Deleted";
        }

    }
}