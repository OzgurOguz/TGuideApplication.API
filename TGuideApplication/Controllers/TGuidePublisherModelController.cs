using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TGuideApplication.Core.IRepository;

namespace TGuideApplication.Controllers
{
    [Route("api/[controller]")]
    public class TGuidePublisherModelController : Controller
    {
        private readonly IPersonInfoRepository _personInfoRepository;

        public TGuidePublisherModelController(IPersonInfoRepository personInfoRepository)
        {
            _personInfoRepository = personInfoRepository;
        }

        [HttpGet]
        public void TGuidePublisherModelRepository()
        {

            var aa = "aa"; //return _personInfoRepository.TGuidePublisherModelRepository();
        }
    }
}
